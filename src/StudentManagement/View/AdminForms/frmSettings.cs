using System;
using System.Reflection;
using System.Windows.Forms;

using MiSchool.Classes;

namespace MiSchool.HelperForms
{
    public partial class frmSettings : DevExpress.XtraEditors.XtraForm
    {
        //DataAccessLayer dal = new DataAccessLayer();

        #region  Constructor

        public frmSettings()
        {
            InitializeComponent();
            GetConnection();
        }

        #endregion

        #region ConnectionTab

        public void GetConnection()
        {
            txtServerName.Text = Properties.Settings.Default.Server;
            txtDatabaseName.Text = Properties.Settings.Default.Database;
            txtUserName.Text = Properties.Settings.Default.DatabaseUser;
            txtUserPassword.Text = Properties.Settings.Default.DatabasePassword;

        }

        private void btnConnectionSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = txtServerName.Text;
            Properties.Settings.Default.Database = txtDatabaseName.Text;
            Properties.Settings.Default.DatabaseUser = txtUserName.Text;
            Properties.Settings.Default.DatabasePassword = txtUserPassword.Text;
        }

        private void btnConnectionCancel_Click(object sender, EventArgs e)
        {
            txtServerName.Text = Properties.Settings.Default.Server;
            txtDatabaseName.Text = Properties.Settings.Default.Database;
            txtUserName.Text = Properties.Settings.Default.DatabaseUser;
            txtUserPassword.Text = Properties.Settings.Default.DatabasePassword;

        }

        #endregion

        #region BackupTab
        private void btnSaveBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) txtSavePath.Text = folderBrowserDialog1.SelectedPath;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;


                string BackupPath = txtSavePath.Text + "\\school " + DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToShortTimeString().Replace(':', '-') + ".bak";
                //Server dbServer = new Server(new ServerConnection(Properties.Settings.Default.Server, Properties.Settings.Default.DatabaseUser, Properties.Settings.Default.DatabasePassword));
                //Backup dbBackup = new Backup() {Action = BackupActionType.Database,Database = Properties.Settings.Default.Database };
                //dbBackup.Devices.AddDevice(BackupPath,DeviceType.File);
                //dbBackup.Initialize = true;
                //dbBackup.PercentComplete += DbBackup_PercentComplete;
                //dbBackup.Complete += DbBackup_Complete;
                //dbBackup.SqlBackupAsync(dbServer);


        }

        //private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        lbStatus.Invoke((MethodInvoker) delegate
        //        {
        //            lbStatus.Text = e.Error.Message;

        //        });
        //    }
        //}

        //private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        //{
        //    progressBar1.Invoke((MethodInvoker) delegate
        //    {
        //        progressBar1.Value = e.Percent;
        //        progressBar1.Update();

        //    });
        //    lbPercent.Invoke((MethodInvoker) delegate
        //    {
        //        lbPercent.Text = $"{e.Percent}%";

        //    });

        //}



        #endregion

        #region RestoreTab

        private void btnRestore_Click(object sender, EventArgs e)
        {

            progressBar2.Value = 0;

                //Server dbServer = new Server(new ServerConnection(Properties.Settings.Default.Server, Properties.Settings.Default.DatabaseUser, Properties.Settings.Default.DatabasePassword));
                //Restore dbRestore = new Restore() { Action = RestoreActionType.Database, ReplaceDatabase = true, NoRecovery = false, Database = Properties.Settings.Default.Database };
                //dbRestore.Devices.AddDevice(txtRestorePath.Text, DeviceType.File);
                //dbRestore.PercentComplete += DbRestore_PercentComplete;
                //dbRestore.Complete += DbRestore_Complete;
                //dbRestore.SqlRestoreAsync(dbServer);


        }

        //private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        lbStatusRestore.Invoke((MethodInvoker)delegate
        //        {
        //            lbStatusRestore.Text = e.Error.Message;

        //        });
        //    }
        //}

        //private void DbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        //{
        //    progressBar2.Invoke((MethodInvoker)delegate
        //    {
        //        progressBar2.Value = e.Percent;
        //        progressBar2.Update();

        //    });
        //    lbPercentRestore.Invoke((MethodInvoker)delegate
        //    {
        //        lbPercentRestore.Text = $"{e.Percent}%";

        //    });
        //}

        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) txtRestorePath.Text = openFileDialog1.FileName;
        }



        #endregion



        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserRole == "admin")
            {
                xtraTabPage2.PageEnabled = true;
                xtraTabPage3.PageEnabled = true;

            }
        }
    }
}