using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using MiSchool.Classes;

namespace MiSchool.HelperForms
{
    public partial class frnUsersAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public int UserId;
        public string state = "add";
        //private Factory fac = new Factory();


        public frnUsersAddEdit()
        {

            InitializeComponent();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

                //if (state == "add")
                //{
               
                //    fac.AddUser(txtUserName.Text,txtUserPass.Text,txtUserNickName.Text,ComboBoxEditUserRoles.EditValue.ToString());
                //    XtraMessageBox.Show("تم الاضافة بنجاح");

                //}
                //else if (state == "update")
                //{
                //    if (checkEdit1.Checked == true)
                //    {
                //        fac.EditUser(UserId,txtUserName.Text,txtUserPass.Text,txtUserNickName.Text,ComboBoxEditUserRoles.EditValue.ToString());
                //        XtraMessageBox.Show("تم التعديل  بنجاح");

                //    }
                //    else
                //    {
                //        fac.EditUserPassword(UserId,txtUserName.Text,txtUserNickName.Text,ComboBoxEditUserRoles.EditValue.ToString());
                //        XtraMessageBox.Show("تم التعديل بنجاح");
                //    }
                //}


                
              
        }

        private void txtUserName_Validated(object sender, EventArgs e)
        {

                //if (state == "add")
                //{

                //    bool isExit= fac.VeriftUserName(txtUserName.Text);
                //    if (isExit == true)
                //    {
                //        XtraMessageBox.Show("هذا المعرف موجود مسبقا");
                //        txtUserName.Focus();
                //        txtUserName.SelectionStart = 0;

                //    }

                
                //} 

            



        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.CheckState == CheckState.Checked) layoutControlItem4.Enabled = true;

            else if(checkEdit1.CheckState ==CheckState.Unchecked)layoutControlItem4.Enabled = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frnUsersAddEdit_Load(object sender, EventArgs e)
        {
           

        }
    }
}