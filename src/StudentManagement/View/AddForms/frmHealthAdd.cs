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
    public partial class frmHealthAdd : DevExpress.XtraEditors.XtraForm
    {

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

        public frmHealthAdd()
        {
            try
            {
                InitializeComponent();

                LoadClasses();

                // Set the value of the dateedit control to the current date
                date.EditValue = DateTime.Now;
                date.Properties.Mask.MaskType = MaskType.DateTime;
                date.Properties.Mask.EditMask = @"dd/MM/yyyy";

                //Set the nulltext to custom text

                //Set the null text of the combobox to custom text

            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }
        }

        private void frmHealthAdd_Load(object sender, EventArgs e)
        {
            cmbClass.Text = @"اختر الصف";

            cmbDivision.Text = @"اختر الشعبة";

            comboBox1.Text = @"اختر الطالب";
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
                comboBox1.DataSource=new DataAccessLayer().Select("Select StudentId,StudentName From tblStudents Where DivisionId = '" + cmbDivision.SelectedValue.ToString() + "'and ClassId = '" + cmbClass.SelectedValue.ToString() + "'");
                comboBox1.DisplayMember = "StudentName";
                comboBox1.ValueMember = "StudentId";
                comboBox1.Text = @"اختر الطالب";
            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                var str = new DataAccessLayer().Select(
                    $"INSERT INTO [tblHealthConditions] ([StudentId],[ClassId],[DivisionId],[Condition],[Date]) VALUES ('{comboBox1.SelectedValue}','{cmbClass.SelectedValue}','{cmbDivision.SelectedValue}','{cmbCondition.Text}','{date.EditValue}')");

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
            this.Close();
        }
    }
}