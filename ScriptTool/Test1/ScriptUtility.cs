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
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Windows.Forms;

namespace Test1
{
    public class ScriptUtility : Form1
    {
        
        public bool ExecuteSql(DbTransaction transaction, string path, ref string msg, string providerType)
        {
            this.dbTransaction = transaction;
            this.dbConnection = transaction.Connection;

            string sql = "";

            StreamReader reader = null;
            int previouBatch = -1;
            DateTime executedOn = DateTime.MinValue;
            try
            {
                reader = File.OpenText(path);
                string textSql = reader.ReadToEnd().Replace("  ", " ");

                previouBatch = GetBatchNumber(out executedOn, false, 0, providerType, dbConnection);

                int index = FindBatchNumber(textSql, previouBatch);

                if (index > 1)
                {
                    textSql = textSql.Substring(index);

                    index = textSql.IndexOf("/*22D2AFA6-B86C-48c9-A990-32E391869E0F*/");
                    sql = textSql.Substring(index);
                }
                else
                    sql = "";


            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            if (string.IsNullOrWhiteSpace(sql))
            {
                msg = "Either no script eixts or script file does not contain last batch executed on or next batch to excute script. Please check batch number or file contents.";
                return false;
            }
            
            return ExecuteSql(sql, previouBatch, executedOn, ref msg, providerType, dbConnection);
        }


        private static int FindBatchNumber(string textSql, int batchNumber)
        {
            int index = textSql.IndexOf("buildversion) values (" + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);

            if (index == -1)
            {
                index = textSql.IndexOf("buildversion) values ( " + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            if (index == -1)
            {
                index = textSql.IndexOf("buildversion)\r\nvalues (" + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }

            if (index == -1)
            {
                index = textSql.IndexOf("buildversion)\r\nvalues ( " + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            if (index == -1)
            {
                index = textSql.IndexOf("buildversion)\r\n values (" + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            if (index == -1)
            {
                index = textSql.IndexOf("buildversion)\r\n values ( " + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            if (index == -1)
            {
                index = textSql.IndexOf("buildversion) \r\nvalues (" + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            if (index == -1)
            {
                index = textSql.IndexOf("buildversion) \r\nvalues ( " + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            if (index == -1)
            {
                index = textSql.IndexOf("buildversion) \r\n values (" + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            if (index == -1)
            {
                index = textSql.IndexOf("buildversion) \r\n values ( " + batchNumber.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }
            return index;
        }

        protected DbConnection dbConnection = null;
        protected DbTransaction dbTransaction = null;

        private bool ExecuteSql(string sql, int previousBatch, DateTime executedOn, ref string msg, string providerType, DbConnection connection)
        {
            string[] sqlBlocks;
            var currentbatch = "";
            string dataBaseName = "";

            Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            sqlBlocks = sql.Split(new string[] { "/*22D2AFA6-B86C-48c9-A990-32E391869E0F*/" }, StringSplitOptions.RemoveEmptyEntries);

            if (providerType.Equals("Oracle.DataAccess.Client", StringComparison.InvariantCultureIgnoreCase))
            {
                regex = new Regex("^/", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }

            DbProviderFactory provider = GetProviderFactory(providerType);
            var cmd = provider.CreateCommand();
            cmd.Connection = connection;
            cmd.Transaction = dbTransaction;

            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;

            dataBaseName = cmd.Connection.Database;

            string lastbatch = previousBatch.ToString();

            foreach (string sqlBlock in sqlBlocks)
            {
                try
                {
                    if (sqlBlock.Length == 0)
                        continue;

                    string pattern = @"/\*(.*?)\*/";
                    string noComments = Regex.Replace(sqlBlock, pattern,
                     me =>
                     {
                         if (me.Value.StartsWith("/*"))
                             return me.Value.StartsWith("//") ? Environment.NewLine : "";
                         return me.Value;
                     },
                     RegexOptions.Singleline);


                    string[] blocks = regex.Split(noComments);

                    foreach (string block in blocks)
                    {
                        if (block.Length != 0)
                        {
                            if (!string.IsNullOrWhiteSpace(block))
                            {
                                currentbatch = GetBatchNumber(block, providerType);
                                cmd.CommandText = block;
                                cmd.ExecuteNonQuery();

                                if (!string.IsNullOrWhiteSpace(currentbatch))
                                    lastbatch = currentbatch;
                            }
                        }
                      
                    }
                }
                catch (Exception e)
                {
                    string message = string.Format("Some error occured sql block immediate after batch number {0} at database {2}" + "\n" + "{1}.", lastbatch, sqlBlock, dataBaseName);
                    throw new Exception(message, e);
                }
            }
            return true;
        }

       private string GetBatchNumber(string block, string providerType)
        {
          
            string batch = "";
            int index = 0;
            index = block.IndexOf("INSERT INTO BatchHistory (BatchNumber, ScriptedBy, ScriptedOn, BuildVersion) VALUES (");

            if (index > 0)
            {
                 

                block = block.Replace("INSERT INTO BatchHistory (BatchNumber, ScriptedBy, ScriptedOn, BuildVersion) VALUES (", "");

                batch = block.Substring(0, block.IndexOf(',')).Trim();
            }

            return batch;
        }

        private int GetBatchNumber(out DateTime excutedOn, bool isAsc, int preBatch, string providerType, DbConnection connection)
        {
            excutedOn = DateTime.MinValue;

            DbProviderFactory provider = GetProviderFactory(providerType);
            DbCommand command = provider.CreateCommand();
            command.Connection = connection;
            command.Transaction = dbTransaction;

            command.CommandText =
                string.Format(
                    "select top 1 BatchNumber,ScriptedOn from BatchHistory with(nolock) where BatchNumber > {0} order by BatchNumber {1}",
                    preBatch, (isAsc) ? "asc" : "desc");
            
            DbDataReader reader = command.ExecuteReader();
            int batchNumber = -1;
            if (reader.Read())
            {
                batchNumber = Convert.ToInt32(reader.GetValue(0));
               
                excutedOn = reader.GetDateTime(1).AddMinutes(330);
            }
            reader.Close();
            return batchNumber;
        }

        protected static DbProviderFactory GetProviderFactory(string providerType)
        {
            providerType = "System.Data.SqlClient";
            return DbProviderFactories.GetFactory(providerType);
        }

        internal static int GetBatchNumber(string connectionString, out DateTime excutedOn, bool isAsc, int preBatch, string providerType)
        {
            DbProviderFactory provider = GetProviderFactory(providerType);
            var connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            DbCommand command = connection.CreateCommand();
            command.CommandText =
                string.Format(
                    "select top 1 BatchNumber,ScriptedOn from BatchHistory with(nolock) where BatchNumber > {0} order by BatchNumber {1}",
                    preBatch, (isAsc) ? "asc" : "desc");

            DbDataReader reader = command.ExecuteReader();

            excutedOn = DateTime.MinValue;
            int batchNumber = -1;
            if (reader.Read())
            {
                batchNumber = Convert.ToInt32(reader.GetValue(0));
                excutedOn = reader.GetDateTime(1).AddMinutes(330);
            }

            reader.Close();

            return batchNumber;
        }
    }
}
