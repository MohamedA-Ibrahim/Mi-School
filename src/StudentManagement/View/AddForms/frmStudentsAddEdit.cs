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
using DevExpress.XtraSpreadsheet.Import;
using MiSchool.Classes;

namespace MiSchool.AddForms
{
    public partial class frmStudentsAddEdit : DevExpress.XtraEditors.XtraForm
    {

        public int StudentId;
        public string state = "add";

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



        public frmStudentsAddEdit()
        {
            InitializeComponent();
            LoadClasses();

            if (state == "add")
            {
                cmbClass.SelectedIndex = -1;
                cmbDivision.SelectedIndex = -1;
            }


        }

        private void frmStudentsAddُEdit_Load(object sender, EventArgs e)
        {

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Set the datasorce of the combobox
                cmbDivision.DataSource = new DataAccessLayer().Select("Select * from [tblDivision] where ClassId='" + cmbClass.SelectedValue + "'");

                // Set the display member of the combobox
                cmbDivision.DisplayMember = "DivisionName";

                // Set the value member of the combobox
                cmbDivision.ValueMember = "DivisionId";

                cmbDivision.SelectedIndex = -1;

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
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            try
            {
                if (state == "add")
                {
                    var str = new DataAccessLayer().Select(
                        $"INSERT INTO [tblStudents] ([StudentName],[ClassId],[DivisionId],[BusName],[Num1],[Num2],[Notes]) VALUES ('{txtStudentName.Text}','{cmbClass.SelectedValue}','{cmbDivision.SelectedValue}','{txtBus.Text}','{txtNum1.Text}','{txtNum2.Text}','{memoEditNotes.Text}')");

                    //Show a messagebox
                    MessageBox.Show(@"تم الاضافة بنجاح");

                    txtStudentName.ResetText();
                    cmbClass.ResetText();
                    cmbDivision.ResetText();
                    txtBus.ResetText();
                    txtNum1.ResetText();
                    txtNum2.ResetText();
                    memoEditNotes.ResetText();


                }
                else if (state == "update")
                {
                    var str = new DataAccessLayer().Select(
                        $"Update [tblStudents] set StudentName = '{txtStudentName.Text}', BusName = '{txtBus.Text}', Num1 = '{txtNum1.Text}', Num2 = '{txtNum2.Text}', Notes = '{memoEditNotes.Text}' where StudentId = '{StudentId}'");
                    MessageBox.Show(@"تم التعديل بنجاح");
                }





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

        private void txtStudentName_Validated(object sender, EventArgs e)
        {
            try
            {
                if (state == "add")
                {
                    var dt = new DataAccessLayer().Select($"select StudentId from tblStudents where StudentName='{txtStudentName.Text}' ");
                    if (dt.Rows.Count > 0)
                    {
                        XtraMessageBox.Show("هذا الاسم موجود مسبقا");
                        txtStudentName.Focus();
                        txtStudentName.SelectionStart = 0;

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
    }
}