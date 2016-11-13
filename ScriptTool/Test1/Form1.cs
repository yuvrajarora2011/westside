using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

namespace Test1
{
    public partial class Form1 : Form
    {
        #region Properties and variables       
        public SqlConnection conn;
        private string connStr;
        public string filetext;
        public string FilePath { get; set; }

        bool allowCommit = false; 

        public Form1()
        {
            InitializeComponent();
            allowCommit = ConfigurationManager.AppSettings["AllowCommit"] == "true";

            btnrunc.Visible = allowCommit;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtException.Visible = false;
        }
        
        public string connectionString
        {
            get { return connStr; }
            set { connStr = value; }
        }

        public bool isMultitenant
        {
            get { return chkMultitenant.Checked; }
        }

        #endregion

        #region validation events
        //Client Side Validations
        private void txtServerName_LayoutUpdated(object sender, EventArgs e)
        {
            if (txtServerName.Text == "")
            {
                txtServerName.Focus();
                MessageBox.Show("Please Enter The Server Name");
                return;
            }
            else
            {
                txtDatabaseName.Focus();
            }
            return;
        }

        private void txtDatabaseName_LayoutChanged(object sender, EventArgs e)
        {
            if (txtDatabaseName.Text == "" && txtServerName.Text.Length > 0)
            {
                txtDatabaseName.Focus();
                MessageBox.Show("Please Enter The Database Name");
                return;
            }
            else
            {
                txtUserID.Focus();
            }
            return;
        }

        private void txtUserID_LayoutChanged(object sender, EventArgs e)
        {
            if (txtUserID.Text == "" && txtDatabaseName.Text.Length>0)
            {
                txtUserID.Focus();
                MessageBox.Show("Enter User Id");
                return;
            }
            else
            {
                txtPassword.Focus();
            }
            return;
        }      

        private void txtpassword_LayoutChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" && txtUserID.Text.Length>0)
            {
                txtPassword.Focus();
                MessageBox.Show("Please enter Password");
                return;
            }
            else
            {
                txtPath.Focus();
            }
            return;
        }

        //Exception Textbox Visibility
        private void txtException_TextChanged(object sender, EventArgs e)
        {
            if (txtException.Visible == false)
            {
                txtException.Visible = true;
            } 
        }

        

        #endregion

        #region Form events and methods
        //Browse Button
        private void button2_Click(object sender, EventArgs e)
        {
            txtPath.Focus();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "sql files(*.sql)|*.sql";
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
                FilePath = txtPath.Text;
                try
                {
                    string text = File.ReadAllText(FilePath);
                    size = text.Length;
                    filetext = text;
                }
                catch (Exception exception)
                {
                    txtException.Text = exception.Message;
                }
                Console.WriteLine(size);
            }
        }

      //Run Button
        private void button1_Click(object sender, EventArgs e)
        {
            scripttest();
        }

        private void btnrunc_Click(object sender, EventArgs e)
        {
            scripttest(true);
        }

        private void scripttest(bool isCommit=false)
        {
            bool result = false;
            string expmsg = "";
            string experror = "";
            var connectionState = "";
            if (string.IsNullOrWhiteSpace(txtServerName.Text) || string.IsNullOrWhiteSpace(txtDatabaseName.Text) || string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("Please enter all the mandatory fields.");
                return;
            }

            try
            {
                string datasource = txtServerName.Text;
                string initialcatalog = txtDatabaseName.Text;
                string user = txtUserID.Text;
                string password = txtPassword.Text;
                //Connection String
                connStr = "Data source=" + datasource + ";Initial Catalog=" + initialcatalog + ";user id=" + user +
                          ";password=" + password;
                conn = new SqlConnection(connStr);
                //If Script File is Empty
                if (string.IsNullOrWhiteSpace(filetext) && !string.IsNullOrWhiteSpace(txtPath.Text))
                {
                    Clock.Stop();
                    lblerrorlist.Visible = false;
                    lblerrordesc.Visible = false;
                    txtException.Visible = false;
                    MessageBox.Show("Script file does not contain any script");
                    return;
                }
                //Multitenancy Check
                if (!isMultitenant && txtDatabaseName.Text.ToLower().Contains("global") && !string.IsNullOrWhiteSpace(txtUserID.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please check Mutitenancy if global database is used.");
                    return;
                }
                else if (isMultitenant && !txtDatabaseName.Text.ToLower().Contains("global"))
                {
                    MessageBox.Show("Please uncheck Mutitenancy if not using the global database.");
                    lblerrorlist.Visible = false;
                    lblerrordesc.Visible = false;
                    txtException.Visible = false;
                    return;
                }

                conn.Open();
                ConnectionState conState = conn.State;
                var insUtil = new InstallUtility();
                connectionState = conState.ToString();

                //Execute Scripts when Connection Open
                if (conState == ConnectionState.Open)
                {
                    lblerrordesc.Text = "";
                    txtException.Visible = false;
                    result = insUtil.ExecuteScripts("System.Data.SqlClient", isMultitenant, connectionString, FilePath,
                                          ref expmsg, ref experror,isCommit);

                    if (!result)
                    {
                        lblerrorlist.Visible = true;
                        txtException.Visible = true;
                        lblerrordesc.Visible = true;
                        lblerrordesc.Text = txtException.Text = experror;
                        txtException.Text = expmsg;
                        return;
                    }
                    this.Clock.Start();
                }

                if (!string.IsNullOrWhiteSpace(expmsg))
                {
                    Clock.Stop();
                    lblerrorlist.Visible = true;
                    txtException.Visible = true;
                    lblerrordesc.Visible = true;
                    txtException.Text = expmsg;
                    lblerrordesc.Text = experror;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "Login failed for user 'qatest'.")
                {
                    MessageBox.Show("Invalid connection string credentials.");
                    return;
                }
                MessageBox.Show(ex.Message);
            }
        }

        //Timer Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            fn_prbar_();
            if (sender == Clock)
            {
                lblprogress.Text = GetTime();
            }
        }

        //Calculating Clock Time
        public string GetTime()
        {
            string TimeInString = "";
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            TimeInString = (hour < 10) ? "0" + hour.ToString() : hour.ToString();
            TimeInString += ":" + ((min < 10) ? "0" + min.ToString() : min.ToString());
            TimeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            return TimeInString;
        }

        //Create the function for progress bar:_
        public void fn_prbar_()
        {
            progressBar1.Increment(1);

            if (progressBar1.Value == progressBar1.Maximum)
            {
                Clock.Stop();
                MessageBox.Show("Database scripts executed");
                progressBar1.Value = 0;
            }
        }
        #endregion


      
       
    }
}
