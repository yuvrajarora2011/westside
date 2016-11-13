namespace Test1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblSerName = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.lblUsrId = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkMultitenant = new System.Windows.Forms.CheckBox();
            this.drpProvider = new System.Windows.Forms.ComboBox();
            this.lblProName = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblerrormsg1 = new System.Windows.Forms.Label();
            this.lblerrormsg2 = new System.Windows.Forms.Label();
            this.lblerrormsg3 = new System.Windows.Forms.Label();
            this.lblerrormsg4 = new System.Windows.Forms.Label();
            this.lblerrormsg5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblprogress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtException = new System.Windows.Forms.TextBox();
            this.lblerrorlist = new System.Windows.Forms.Label();
            this.lblerrordesc = new System.Windows.Forms.Label();
            this.Clock = new System.Windows.Forms.Timer(this.components);
            this.btnrunc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(150, 79);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(199, 20);
            this.txtServerName.TabIndex = 0;
            this.txtServerName.Leave += new System.EventHandler(this.txtServerName_LayoutUpdated);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(150, 115);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(199, 20);
            this.txtDatabaseName.TabIndex = 1;
            this.txtDatabaseName.Leave += new System.EventHandler(this.txtDatabaseName_LayoutChanged);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(150, 153);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(199, 20);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Leave += new System.EventHandler(this.txtUserID_LayoutChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(199, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Leave += new System.EventHandler(this.txtpassword_LayoutChanged);
            // 
            // lblSerName
            // 
            this.lblSerName.AutoSize = true;
            this.lblSerName.ForeColor = System.Drawing.Color.Black;
            this.lblSerName.Location = new System.Drawing.Point(24, 79);
            this.lblSerName.Name = "lblSerName";
            this.lblSerName.Size = new System.Drawing.Size(72, 13);
            this.lblSerName.TabIndex = 4;
            this.lblSerName.Text = "Server Name ";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(24, 115);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(84, 13);
            this.lblDbName.TabIndex = 5;
            this.lblDbName.Text = "Database Name";
            // 
            // lblUsrId
            // 
            this.lblUsrId.AutoSize = true;
            this.lblUsrId.Location = new System.Drawing.Point(24, 153);
            this.lblUsrId.Name = "lblUsrId";
            this.lblUsrId.Size = new System.Drawing.Size(43, 13);
            this.lblUsrId.TabIndex = 6;
            this.lblUsrId.Text = "User ID";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(24, 190);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(56, 13);
            this.lblPwd.TabIndex = 7;
            this.lblPwd.Text = "Password ";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(145, 277);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(131, 23);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "Run && Roll Back";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(24, 228);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(59, 13);
            this.lblPath.TabIndex = 10;
            this.lblPath.Text = "Script Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(150, 228);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(296, 20);
            this.txtPath.TabIndex = 11;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(482, 227);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(92, 23);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkMultitenant
            // 
            this.chkMultitenant.AutoSize = true;
            this.chkMultitenant.Location = new System.Drawing.Point(150, 254);
            this.chkMultitenant.Name = "chkMultitenant";
            this.chkMultitenant.Size = new System.Drawing.Size(86, 17);
            this.chkMultitenant.TabIndex = 14;
            this.chkMultitenant.Text = "IsMultitenant";
            this.chkMultitenant.UseVisualStyleBackColor = true;
            // 
            // drpProvider
            // 
            this.drpProvider.Enabled = false;
            this.drpProvider.FormattingEnabled = true;
            this.drpProvider.Items.AddRange(new object[] {
            "System.Data.SqlClient",
            "Oracle.DataAccess.Client"});
            this.drpProvider.Location = new System.Drawing.Point(150, 43);
            this.drpProvider.Name = "drpProvider";
            this.drpProvider.Size = new System.Drawing.Size(131, 21);
            this.drpProvider.TabIndex = 15;
            this.drpProvider.Text = "SqlClient";
            // 
            // lblProName
            // 
            this.lblProName.Location = new System.Drawing.Point(24, 46);
            this.lblProName.Name = "lblProName";
            this.lblProName.Size = new System.Drawing.Size(84, 33);
            this.lblProName.TabIndex = 16;
            this.lblProName.Text = "Provider Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(150, 358);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(564, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 17;
            // 
            // lblerrormsg1
            // 
            this.lblerrormsg1.AutoSize = true;
            this.lblerrormsg1.ForeColor = System.Drawing.Color.Crimson;
            this.lblerrormsg1.Location = new System.Drawing.Point(446, 86);
            this.lblerrormsg1.Name = "lblerrormsg1";
            this.lblerrormsg1.Size = new System.Drawing.Size(0, 13);
            this.lblerrormsg1.TabIndex = 18;
            // 
            // lblerrormsg2
            // 
            this.lblerrormsg2.AutoSize = true;
            this.lblerrormsg2.ForeColor = System.Drawing.Color.Crimson;
            this.lblerrormsg2.Location = new System.Drawing.Point(446, 122);
            this.lblerrormsg2.Name = "lblerrormsg2";
            this.lblerrormsg2.Size = new System.Drawing.Size(0, 13);
            this.lblerrormsg2.TabIndex = 19;
            // 
            // lblerrormsg3
            // 
            this.lblerrormsg3.AutoSize = true;
            this.lblerrormsg3.ForeColor = System.Drawing.Color.Crimson;
            this.lblerrormsg3.Location = new System.Drawing.Point(446, 160);
            this.lblerrormsg3.Name = "lblerrormsg3";
            this.lblerrormsg3.Size = new System.Drawing.Size(0, 13);
            this.lblerrormsg3.TabIndex = 20;
            // 
            // lblerrormsg4
            // 
            this.lblerrormsg4.AutoSize = true;
            this.lblerrormsg4.ForeColor = System.Drawing.Color.Crimson;
            this.lblerrormsg4.Location = new System.Drawing.Point(446, 197);
            this.lblerrormsg4.Name = "lblerrormsg4";
            this.lblerrormsg4.Size = new System.Drawing.Size(0, 13);
            this.lblerrormsg4.TabIndex = 21;
            // 
            // lblerrormsg5
            // 
            this.lblerrormsg5.AutoSize = true;
            this.lblerrormsg5.ForeColor = System.Drawing.Color.Crimson;
            this.lblerrormsg5.Location = new System.Drawing.Point(446, 233);
            this.lblerrormsg5.Name = "lblerrormsg5";
            this.lblerrormsg5.Size = new System.Drawing.Size(0, 13);
            this.lblerrormsg5.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(92, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(109, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "*";
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Location = new System.Drawing.Point(24, 368);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(0, 13);
            this.lblprogress.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(66, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(76, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(82, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "*";
            // 
            // txtException
            // 
            this.txtException.HideSelection = false;
            this.txtException.Location = new System.Drawing.Point(150, 399);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtException.Size = new System.Drawing.Size(564, 193);
            this.txtException.TabIndex = 13;
            this.txtException.TextChanged += new System.EventHandler(this.txtException_TextChanged);
            // 
            // lblerrorlist
            // 
            this.lblerrorlist.AutoSize = true;
            this.lblerrorlist.Location = new System.Drawing.Point(24, 315);
            this.lblerrorlist.Name = "lblerrorlist";
            this.lblerrorlist.Size = new System.Drawing.Size(48, 13);
            this.lblerrorlist.TabIndex = 29;
            this.lblerrorlist.Text = "Error List";
            this.lblerrorlist.Visible = false;
            // 
            // lblerrordesc
            // 
            this.lblerrordesc.AutoSize = true;
            this.lblerrordesc.ForeColor = System.Drawing.Color.Red;
            this.lblerrordesc.Location = new System.Drawing.Point(147, 315);
            this.lblerrordesc.Name = "lblerrordesc";
            this.lblerrordesc.Size = new System.Drawing.Size(0, 13);
            this.lblerrordesc.TabIndex = 30;
            // 
            // Clock
            // 
            this.Clock.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnrunc
            // 
            this.btnrunc.Location = new System.Drawing.Point(313, 277);
            this.btnrunc.Name = "btnrunc";
            this.btnrunc.Size = new System.Drawing.Size(153, 23);
            this.btnrunc.TabIndex = 31;
            this.btnrunc.Text = "Run && Commit";
            this.btnrunc.UseVisualStyleBackColor = true;
            this.btnrunc.Visible = false;
            this.btnrunc.Click += new System.EventHandler(this.btnrunc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 604);
            this.Controls.Add(this.btnrunc);
            this.Controls.Add(this.lblerrordesc);
            this.Controls.Add(this.lblerrorlist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblprogress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblerrormsg5);
            this.Controls.Add(this.lblerrormsg4);
            this.Controls.Add(this.lblerrormsg3);
            this.Controls.Add(this.lblerrormsg2);
            this.Controls.Add(this.lblerrormsg1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblProName);
            this.Controls.Add(this.drpProvider);
            this.Controls.Add(this.chkMultitenant);
            this.Controls.Add(this.txtException);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblUsrId);
            this.Controls.Add(this.lblDbName);
            this.Controls.Add(this.lblSerName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.txtServerName);
            this.Name = "Form1";
            this.Text = "Script Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblSerName;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.Label lblUsrId;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkMultitenant;
        private System.Windows.Forms.ComboBox drpProvider;
        private System.Windows.Forms.Label lblProName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblerrormsg1;
        private System.Windows.Forms.Label lblerrormsg5;
        private System.Windows.Forms.Label lblerrormsg4;
        private System.Windows.Forms.Label lblerrormsg3;
        private System.Windows.Forms.Label lblerrormsg2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.Label lblerrordesc;
        private System.Windows.Forms.Label lblerrorlist;
        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.Button btnrunc;
    }
}

