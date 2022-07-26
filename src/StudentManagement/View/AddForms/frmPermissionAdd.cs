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
using DevExpress.XtraEditors.Mask;
using MiSchool.Classes;

namespace MiSchool.UserControls
{
    public partial class frmPermissionAdd : DevExpress.XtraEditors.XtraForm
    {
        private string reason=null;

        private void LoadClasses()
        {
            try
            {
                //Set the datasource of the combobox
                cmbClass.DataSource = new DataAccessLayer().Select("SELECT [ClassId] , [ClassName] FROM [tblClasses] ");

                // Sets the display member
                cmbClass.DisplayMember = "ClassName";

                // Sets the value member
                cmbClass.ValueMember = "ClassId";


               
            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }
        }

        public frmPermissionAdd()
        {
            try
            {
                InitializeComponent();

                LoadClasses();

                // Set the value of the dateedit control to the current date
                date.EditValue = DateTime.Now;
                date.Properties.Mask.MaskType = MaskType.DateTime;
                date.Properties.Mask.EditMask = @"dd/MM/yyyy";


            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }

        }

        private void frmPermissionAdd_Load(object sender, EventArgs e)
        {
            cmbClass.Text = @"اختر الصف";

            cmbDivision.Text = @"اختر الشعبة";

            cmbStudent.Text = @"اختر الطالب";
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Set the datasorce of the combobox
                cmbDivision.DataSource=new DataAccessLayer().Select("Select * from [tblDivision] where ClassId='"+cmbClass.SelectedValue+"'");

                // Set the display member of the combobox
                cmbDivision.DisplayMember = "DivisionName";

                // Set the value member of the combobox
                cmbDivision.ValueMember = "DivisionId";
                //cmbDivision.SelectedIndex = -1;
                cmbDivision.Text = @"اختر الشعبة";
            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbStudent.DataSource=new DataAccessLayer().Select("Select StudentId,StudentName From tblStudents Where DivisionId = '" + cmbDivision.SelectedValue.ToString() + "'and ClassId = '" + cmbClass.SelectedValue.ToString() + "'");
                cmbStudent.DisplayMember = "StudentName";
                cmbStudent.ValueMember = "StudentId";
                cmbStudent.Text = @"اختر الطالب";
            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReason.Text == "أخرى")
            {
                txtReason.Enabled = true;
                reason = txtReason.Text;
            }
            else
            {
                reason = cmbReason.Text;
                txtReason.Enabled = false;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                var str = new DataAccessLayer().Select(
                    $"INSERT INTO [tblPermission] ([StudentId],[ClassId],[DivisionId],[date],[Reason]) VALUES ('{cmbStudent.SelectedValue}','{cmbClass.SelectedValue}','{cmbDivision.SelectedValue}','{date.EditValue}','{reason}')");

                //Show a messagebox
                MessageBox.Show("تم الحفظ بنجاح");



            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}