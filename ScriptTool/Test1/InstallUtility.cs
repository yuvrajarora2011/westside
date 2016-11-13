/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * 
 * C O P Y R I G H T    N O T I C E
 * 
 * Copyright (c) 2000-2006 Acidaes Solutions Pvt. Ltd. All Rights Reserved.
 * 
 * This code is a part of the source code used by Acidaes Solution Private Limited for its product "CRMnext".
 * You may not, directly or indirectly, use, disclose, distribute, print or copy this code or any part of it.
 * 
 * This code contains confidential information and/or may contain information protected by intellectual property 
 * rights or other rights. This code shall/may not be construed to constitute any commitment from 
 * Acidaes Solutions Private Limited or its subsidiaries or affiliates except when expressly agreed to in a 
 * separate written agreement.
 * 
 * AUTHORS:                           DATE:
 * 
 * REVISION: $Revision: 10085 $
 * LAST MODIFIED BY: $Author: prakasht $ on $Date: 2008-05-19 09:47:08 +0530 (Mon, 19 May 2008) $  
 * 
 * R E V I S I O N  H I S T O R Y:
 * 
 * DATE      CHANGED BY               COMMENT     
 * 
 *  
 * C O D E  R E V I E W  H I S T O R Y: 
 * 
 * DATE      REVIEWED BY              COMMENT     
 *  
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Configuration;

namespace Test1
{
    public class InstallUtility : Form1
    {
       
        public string errormsg="";
        private string providerType = "System.Data.SqlClient";
        private DbTransaction transaction;
        string msg = "";
        int olderBatch = 0;
        DateTime olderBatchExecutedOn = DateTime.MinValue;

        int fromBatch = 0;
        int lastBatch = 0;

        protected DbProviderFactory GetProviderFactory(string providerType)
        {
            return DbProviderFactories.GetFactory(providerType);
        }

        public bool ExecuteScripts(string providerType, bool isMultitenant,string connectionString, string filePath, ref  string expmsg,ref string experror, bool isCommit)
        {
            
            bool result = false;
            string msg = "";
            var exceptionList = new ArrayList();

            try
            {
                //For Single-tenant
                if (!isMultitenant)
                {
                    result = ExecuteScripts(connectionString, providerType, filePath, ref expmsg,ref experror,isCommit);
                    if (!string.IsNullOrWhiteSpace(experror))
                        exceptionList.Add(experror);
                    return result;
                }

                //Multi-tenant
                foreach (string connectionStrings in GetConnectionStrings(providerType, isMultitenant, connectionString))
                {
                    connectionString = connectionStrings;
                    result = ExecuteScripts(connectionString, providerType, filePath, ref expmsg, ref experror, isCommit);
                    if (!string.IsNullOrWhiteSpace(expmsg))
                        exceptionList.Add(expmsg);
                }

                var msgArray=(string[])exceptionList.ToArray(typeof(string));
                msg = string.Join(" ", msgArray);
                
            }
            catch (Exception ex)
            {
                msg=string.Format("{0}{1}",msg,ex.Message);
            }

            expmsg =string.Format("{0}{1}",msg.ToString(),experror);
            return result;
        }

        private string[] GetConnectionStrings(string providerType, bool isMultitenant, string connectionString)
        {
            if (isMultitenant)
            {
                Acidaes.Deployment.DeploymentManagerConfig.DeploymentConfigDatabaseString = connectionString;

                if (providerType == "System.Data.SqlClient")
                {
                    Acidaes.Deployment.DeploymentManagerConfig.ProviderName = "System.Data.SqlClient";
                }

                Acidaes.Deployment.DeploymentManagerConfig.IsMultiTenant = true;
                return Acidaes.Deployment.DeploymentManager.GetAllConnections();

            }

            return new string[] { };
        }
        
        public bool ExecuteScripts(string connectionString, string providerType, string filePath, ref string expmsg,ref string experror, bool isCommit)
        {
            bool result = true;

            DbProviderFactory provider = GetProviderFactory(providerType);
            var connection = provider.CreateConnection();
            string statusMsg = "";
           
            try
            {
                olderBatch = ScriptUtility.GetBatchNumber(connectionString, out olderBatchExecutedOn, false, 0,
                                                          providerType);
                connection.ConnectionString = connectionString;
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                result = ExecuteScript(filePath, ref statusMsg);
                DateTime now = DateTime.MinValue;
                fromBatch = ScriptUtility.GetBatchNumber(connectionString, out now, true, olderBatch, providerType);
                lastBatch = ScriptUtility.GetBatchNumber(connectionString, out now, false, olderBatch, providerType);
           
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                errormsg=ex.InnerException.Message;
                
                result = false;
            }
            finally
            {
               if (transaction != null)
                {
                    if (isCommit)
                    {
                        transaction.Commit();
                    }
                    else
                        transaction.Rollback();

                }
                connection.Close();
                transaction.Dispose();
            }

            expmsg = msg;
            experror = string.Format("{0}{1}", errormsg, statusMsg);

            return result;
        }

        public bool ExecuteScript(string filePath, ref string msg)
        {
            ScriptUtility utilty = new ScriptUtility();
            return utilty.ExecuteSql(transaction, filePath, ref msg, providerType);
        }
    }
}




