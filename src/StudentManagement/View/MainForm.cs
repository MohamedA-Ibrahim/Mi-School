using DevExpress.XtraBars;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MiSchool.Forms;
using MiSchool.Reports;

namespace MiSchool
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {


        #region  To control Form

        private static MainForm frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static MainForm getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new MainForm();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }

                return frm;
            }
        }

        #endregion


        private void FirstTime()
        {
            const string REGISTRY_KEY = @"HKEY_CURRENT_USER\MIB School";
            const string REGISTY_VALUE = "FirstRun";
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_VALUE, 0)) == 0)
            {
                //barBtnSettings.Enabled = true;
                barHeaderUser.Caption = @"مرحبا بك , من فضلك قم بضبط اعدادت الاتصال";
                //Change the value since the program has run once now
                Microsoft.Win32.Registry.SetValue(REGISTRY_KEY, REGISTY_VALUE, 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            if (frm == null) frm = this;
            FirstTime();
            //Todo uninstall registry key FirstTime when uninstalling




        }

        #endregion

        #region RecordsForms
        // Opening the records forms

        private void barBtnAbsence_ItemClick(object sender, ItemClickEventArgs e)
        {
            RecordsForms.frmAbsence1 frm = new RecordsForms.frmAbsence1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barBtnBuses_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmBuses frm = new Forms.frmBuses();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barBtnDaily_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmDaily frm = new Forms.frmDaily();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barBtnHealth_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmHealth frm = new Forms.frmHealth();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barBtnInfraction_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmViolations frm = new Forms.frmViolations();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barBtnLate_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmDelay frm = new Forms.frmDelay();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barbtnPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmPermission frm = new Forms.frmPermission();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barBtnParents_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmParents frm = new Forms.frmParents();
            frm.MdiParent = this;
            frm.Show();
        }



        #endregion



        private void btnHealth_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRequest req = new frmRequest();
            req.Text = @"طلب تحويل طبي";
            req.ShowDialog();

        }




        private void btnParents_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRequest req = new frmRequest();
            req.Text = @"طلب استدعاء ولي الأمر";
            req.ShowDialog();
        }


        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {

            frnStudentsList frm = new frnStudentsList();

            frm.MdiParent = this;
            frm.Show();


        }



        private void barBtnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();

        }

        private void barBtnAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
           frmAbout frm=new frmAbout();
            frm.ShowDialog();

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    barCurrentTime.Caption = DateTime.Now.ToString();

        //}

        private void barBtnUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.ShowDialog();
        }

        private void barBtnSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSettings frm=new frmSettings();
            frm.ShowDialog();

        }

        private void barBtnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            ribbonPageGroupRecords.Enabled = false;
            ribbonPageGroupRequest.Enabled = false;
            //barBtnStudentReport.Enabled = false;
            barBtnClasses.Enabled = false;
            barBtnUsers.Enabled = false;
            barBtnSettings.Enabled = false;
            barBtnLogin.Enabled = true;
            barBtnLogout.Enabled = false;
        }

        private void barBtnUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {


        }

    }
}