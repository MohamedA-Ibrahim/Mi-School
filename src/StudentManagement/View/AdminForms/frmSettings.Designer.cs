namespace MiSchool.HelperForms
{
    partial class frmSettings
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnConnectionCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnConnectionSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtUserPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtDatabaseName = new DevExpress.XtraEditors.TextEdit();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lbStatus = new DevExpress.XtraEditors.LabelControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbPercent = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSavePath = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.lbStatusRestore = new DevExpress.XtraEditors.LabelControl();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.lbPercentRestore = new DevExpress.XtraEditors.LabelControl();
            this.btnRestoreBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtRestorePath = new DevExpress.XtraEditors.TextEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSavePath.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestorePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(361, 282);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnConnectionCancel);
            this.xtraTabPage1.Controls.Add(this.btnConnectionSave);
            this.xtraTabPage1.Controls.Add(this.txtUserPassword);
            this.xtraTabPage1.Controls.Add(this.txtUserName);
            this.xtraTabPage1.Controls.Add(this.txtDatabaseName);
            this.xtraTabPage1.Controls.Add(this.txtServerName);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(359, 257);
            this.xtraTabPage1.Text = "قاعدة البيانات";
            // 
            // btnConnectionCancel
            // 
            this.btnConnectionCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnConnectionCancel.Appearance.Options.UseFont = true;
            this.btnConnectionCancel.Location = new System.Drawing.Point(22, 197);
            this.btnConnectionCancel.Name = "btnConnectionCancel";
            this.btnConnectionCancel.Size = new System.Drawing.Size(75, 23);
            this.btnConnectionCancel.TabIndex = 9;
            this.btnConnectionCancel.Text = "الغاء";
            this.btnConnectionCancel.Click += new System.EventHandler(this.btnConnectionCancel_Click);
            // 
            // btnConnectionSave
            // 
            this.btnConnectionSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnConnectionSave.Appearance.Options.UseFont = true;
            this.btnConnectionSave.Location = new System.Drawing.Point(133, 197);
            this.btnConnectionSave.Name = "btnConnectionSave";
            this.btnConnectionSave.Size = new System.Drawing.Size(75, 23);
            this.btnConnectionSave.TabIndex = 8;
            this.btnConnectionSave.Text = "حفظ";
            this.btnConnectionSave.Click += new System.EventHandler(this.btnConnectionSave_Click);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(22, 145);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtUserPassword.Properties.Appearance.Options.UseFont = true;
            this.txtUserPassword.Properties.PasswordChar = '*';
            this.txtUserPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserPassword.Size = new System.Drawing.Size(186, 22);
            this.txtUserPassword.TabIndex = 7;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(22, 106);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserName.Size = new System.Drawing.Size(186, 22);
            this.txtUserName.TabIndex = 6;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(22, 67);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDatabaseName.Properties.Appearance.Options.UseFont = true;
            this.txtDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDatabaseName.Size = new System.Drawing.Size(186, 22);
            this.txtDatabaseName.TabIndex = 5;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(22, 28);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtServerName.Properties.Appearance.Options.UseFont = true;
            this.txtServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerName.Size = new System.Drawing.Size(186, 22);
            this.txtServerName.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(215, 148);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 17);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "كلمة المرور :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(215, 109);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(102, 17);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "اسم المستخدم :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(214, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(117, 17);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "اسم قاعدة البيانات :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(214, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "اسم السيرفر :";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lbStatus);
            this.xtraTabPage2.Controls.Add(this.progressBar1);
            this.xtraTabPage2.Controls.Add(this.lbPercent);
            this.xtraTabPage2.Controls.Add(this.btnSaveBrowse);
            this.xtraTabPage2.Controls.Add(this.btnSave);
            this.xtraTabPage2.Controls.Add(this.labelControl5);
            this.xtraTabPage2.Controls.Add(this.txtSavePath);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageEnabled = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(359, 257);
            this.xtraTabPage2.Text = "انشاء نسخة احتياطية";
            this.xtraTabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage2_Paint);
            // 
            // lbStatus
            // 
            this.lbStatus.Location = new System.Drawing.Point(13, 171);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(31, 13);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "Status";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(41, 123);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // lbPercent
            // 
            this.lbPercent.Location = new System.Drawing.Point(160, 152);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(20, 13);
            this.lbPercent.TabIndex = 5;
            this.lbPercent.Text = "0 %";
            // 
            // btnSaveBrowse
            // 
            this.btnSaveBrowse.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnSaveBrowse.Appearance.Options.UseFont = true;
            this.btnSaveBrowse.Location = new System.Drawing.Point(12, 67);
            this.btnSaveBrowse.Name = "btnSaveBrowse";
            this.btnSaveBrowse.Size = new System.Drawing.Size(70, 23);
            this.btnSaveBrowse.TabIndex = 3;
            this.btnSaveBrowse.Text = ". . .";
            this.btnSaveBrowse.Click += new System.EventHandler(this.btnSaveBrowse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(13, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "انشاء";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(97, 29);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(251, 18);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "قم بتحديد مسار حفظ النسخة الاحتياطية";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(97, 67);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtSavePath.Properties.Appearance.Options.UseFont = true;
            this.txtSavePath.Size = new System.Drawing.Size(240, 24);
            this.txtSavePath.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.lbStatusRestore);
            this.xtraTabPage3.Controls.Add(this.progressBar2);
            this.xtraTabPage3.Controls.Add(this.lbPercentRestore);
            this.xtraTabPage3.Controls.Add(this.btnRestoreBrowse);
            this.xtraTabPage3.Controls.Add(this.btnRestore);
            this.xtraTabPage3.Controls.Add(this.labelControl6);
            this.xtraTabPage3.Controls.Add(this.txtRestorePath);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.PageEnabled = false;
            this.xtraTabPage3.Size = new System.Drawing.Size(359, 257);
            this.xtraTabPage3.Text = "استعادة النسخة الاحتياطية";
            // 
            // lbStatusRestore
            // 
            this.lbStatusRestore.Location = new System.Drawing.Point(11, 180);
            this.lbStatusRestore.Name = "lbStatusRestore";
            this.lbStatusRestore.Size = new System.Drawing.Size(31, 13);
            this.lbStatusRestore.TabIndex = 11;
            this.lbStatusRestore.Text = "Status";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(35, 127);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(283, 23);
            this.progressBar2.TabIndex = 10;
            // 
            // lbPercentRestore
            // 
            this.lbPercentRestore.Location = new System.Drawing.Point(154, 156);
            this.lbPercentRestore.Name = "lbPercentRestore";
            this.lbPercentRestore.Size = new System.Drawing.Size(20, 13);
            this.lbPercentRestore.TabIndex = 9;
            this.lbPercentRestore.Text = "0 %";
            // 
            // btnRestoreBrowse
            // 
            this.btnRestoreBrowse.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnRestoreBrowse.Appearance.Options.UseFont = true;
            this.btnRestoreBrowse.Location = new System.Drawing.Point(11, 74);
            this.btnRestoreBrowse.Name = "btnRestoreBrowse";
            this.btnRestoreBrowse.Size = new System.Drawing.Size(70, 23);
            this.btnRestoreBrowse.TabIndex = 8;
            this.btnRestoreBrowse.Text = ". . .";
            this.btnRestoreBrowse.Click += new System.EventHandler(this.btnRestoreBrowse_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnRestore.Appearance.Options.UseFont = true;
            this.btnRestore.Location = new System.Drawing.Point(11, 209);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(82, 27);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "استعادة";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(84, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(252, 18);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "قم بتحديد مسار وجود النسخة الاحتياطية";
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Location = new System.Drawing.Point(96, 74);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtRestorePath.Properties.Appearance.Options.UseFont = true;
            this.txtRestorePath.Size = new System.Drawing.Size(240, 24);
            this.txtRestorePath.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 282);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاعدادات";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSavePath.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRestorePath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton btnConnectionCancel;
        private DevExpress.XtraEditors.SimpleButton btnConnectionSave;
        private DevExpress.XtraEditors.TextEdit txtUserPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtDatabaseName;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtSavePath;
        private DevExpress.XtraEditors.SimpleButton btnSaveBrowse;
        private DevExpress.XtraEditors.SimpleButton btnRestoreBrowse;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtRestorePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.LabelControl lbStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraEditors.LabelControl lbPercent;
        private DevExpress.XtraEditors.LabelControl lbStatusRestore;
        private System.Windows.Forms.ProgressBar progressBar2;
        private DevExpress.XtraEditors.LabelControl lbPercentRestore;
    }
}