using System;
using System.Reflection;
using System.Windows.Forms;
using MiSchool.Classes;
namespace MiSchool.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!BussinessLayer.ValidateCombobox(cmbSchool, " المدرسة")) return;

                bool Login = Factory.Login(txtUser.Text, txtPassword.Text);
                if (Login == true)
                {
                    if (Properties.Settings.Default.UserRole == "root" || Properties.Settings.Default.UserRole == "admin")
                    {
                        MainForm.getMainForm.ribbonPageGroupRecords.Enabled = true;
                        MainForm.getMainForm.ribbonPageGroupRequest.Enabled = true;
                        MainForm.getMainForm.barBtnClasses.Enabled = true;
                        MainForm.getMainForm.barBtnUsers.Enabled = true;
                        MainForm.getMainForm.barBtnLogout.Enabled = true;
                        MainForm.getMainForm.barBtnLogin.Enabled = false;

                        this.Close();
                    }
                    else if (Properties.Settings.Default.UserRole == "client")
                    {
                        MainForm.getMainForm.ribbonPageGroupRecords.Enabled = true;
                        MainForm.getMainForm.ribbonPageGroupRequest.Enabled = true;
                        MainForm.getMainForm.barBtnClasses.Enabled = true;
                        MainForm.getMainForm.barBtnLogout.Enabled = true;
                        MainForm.getMainForm.barBtnLogin.Enabled = false;
                        this.Close();
                    }

                    MainForm.getMainForm.barHeaderUser.Caption = string.Format("تم تسجيل الدخول بواسطة : {0}", Properties.Settings.Default.UserNickName);

                    if (Properties.Settings.Default.Database == "school")
                    {
                        MainForm.getMainForm.barHeaderSchoolName.Caption = @"مدرسه الاخلاص الاهلية بنين  ابتدائي - متوسط - ثانوي";
                    }
                    else if (Properties.Settings.Default.Database == "school2")
                    {
                        MainForm.getMainForm.barHeaderSchoolName.Caption = @"الاخلاص الاهلية الابتدائية المشتركة";

                    }
                    else if (Properties.Settings.Default.Database == "school3")
                    {
                        MainForm.getMainForm.barHeaderSchoolName.Caption = @"مدرسة الاخلاص الاهلية متوسط - ثانوي بنات";

                    }

                }


            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }
           
            

        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchool.Text == @"مدرسه الاخلاص الاهلية بنين  ابتدائي - متوسط - ثانوي")
            {
                Properties.Settings.Default.Database = "school";
            }
            else if(cmbSchool.Text == @"الاخلاص الاهلية الابتدائية المشتركة")
            {
                Properties.Settings.Default.Database = "school2";

            }
            else if (cmbSchool.Text == @"مدرسة الاخلاص الاهلية متوسط - ثانوي بنات")
            {
                Properties.Settings.Default.Database = "school3";

            }

        }
    }
}