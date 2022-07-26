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
    public partial class frmViolationsAdd : DevExpress.XtraEditors.XtraForm
    {

        private string uniform = "";
        private string trouble = "";

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

        public frmViolationsAdd()
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

        private void frmViolationsAdd_Load(object sender, EventArgs e)
        {
            cmbClass.Text = @"اختر الصف";

            cmbDivision.Text = @"اختر الشعبة";

            cmbStudent.Text = @"اختر الطالب";
        }

        //Todo Improve checkboxes
        private void CheckBoxes()
        {
            
            if (checkedListBoxControl1.CheckedItems.Count > 0)
            {
                for (int i = 0; i < checkedListBoxControl1.CheckedItems.Count; i++)
                {
                    if (uniform == "")
                    {
                        uniform = checkedListBoxControl1.CheckedItems[i].ToString();
                    }
                    else
                    {
                        uniform += "," + checkedListBoxControl1.CheckedItems[i].ToString();
                    }
                }
            }
            else
            {
                uniform = "";
            }


            if (checkedListBoxControl2.CheckedItems.Count > 0)
            {
                for (int i = 0; i < checkedListBoxControl2.CheckedItems.Count; i++)
                {
                    if (trouble == "")
                    {
                        trouble = checkedListBoxControl2.CheckedItems[i].ToString();
                    }
                    else
                    {
                        trouble += "," + checkedListBoxControl2.CheckedItems[i].ToString();
                    }
                }
            }
            else
            {
                trouble = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                CheckBoxes();
                var str = new DataAccessLayer().Select(
                    $"INSERT INTO [tblViolations] ([StudentId],[ClassId],[DivisionId],[Date],[Uniform],[Trouble]) VALUES ('{cmbStudent.SelectedValue}','{cmbClass.SelectedValue}','{cmbDivision.SelectedValue}','{date.EditValue}','{uniform}','{trouble}')");

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