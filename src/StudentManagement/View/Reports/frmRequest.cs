using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using MiSchool.Classes;
using DevExpress.XtraReports.Parameters;
namespace MiSchool.Reports
{
    public partial class frmRequest : DevExpress.XtraEditors.XtraForm
    {
        private void LoadClasses()
        {
            //try
            //{
            //    //Set the datasource of the combobox
            //    cmbClass.DataSource = new DataAccessLayer().Select("SELECT [ClassId] , [ClassName] FROM [tblClasses] ");

            //    // Sets the display member
            //    cmbClass.DisplayMember = "ClassName";

            //    // Sets the value member
            //    cmbClass.ValueMember = "ClassId";


               
            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}
        }

        public frmRequest()
        {
            //try
            //{
            //    InitializeComponent();
            //    LoadClasses();
            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void healthRequest_Load(object sender, EventArgs e)
        {
            cmbClass.Text = @"اختر الصف";

            cmbDivision.Text = @"اختر الشعبة";

            cmbStudent.Text = @"اختر الطالب";
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    // Set the datasorce of the combobox
            //    cmbDivision.DataSource=new DataAccessLayer().Select("Select * from [tblDivision] where ClassId='"+cmbClass.SelectedValue+"'");

            //    // Set the display member of the combobox
            //    cmbDivision.DisplayMember = "DivisionName";

            //    // Set the value member of the combobox
            //    cmbDivision.ValueMember = "DivisionId";
            //    //cmbDivision.SelectedIndex = -1;
            //    cmbDivision.Text = @"اختر الشعبة";
            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    cmbStudent.DataSource=new DataAccessLayer().Select("Select StudentId,StudentName From tblStudents Where DivisionId = '" + cmbDivision.SelectedValue.ToString() + "'and ClassId = '" + cmbClass.SelectedValue.ToString() + "'");
            //    cmbStudent.DisplayMember = "StudentName";
            //    cmbStudent.ValueMember = "StudentId";
            //    cmbStudent.Text = @"اختر الطالب";
            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (!BussinessLayer.ValidateCombobox(cmbClass, "الصف ")) return;
            //if (!BussinessLayer.ValidateCombobox(cmbDivision, " الشعبة ")) return;
            //if (!BussinessLayer.ValidateCombobox(cmbStudent, "اسم الطالب ")) return;

            switch (this.Text)
            {
                case "طلب تحويل طبي":

                    // Create a report instance.
                    var report =new HealthRequestReport();

                    // Obtain a parameter, and set its value.
                    report.Parameters["ParameterClass"].Value = cmbClass.Text;
                    report.Parameters["ParameterDivision"].Value = cmbDivision.Text;
                    report.Parameters["ParameterStudent"].Value = cmbStudent.Text;

                    if (Properties.Settings.Default.Database == "school")
                    {
                        //report.Parameters["SchoolNameEnglish"].Value = "Ikhlas Private School";

                    }
                    else if (Properties.Settings.Default.Database == "school2")
                    {
                        report.Parameters["SchoolNameEnglish"].Value = "مدرسة الاخلاص الأهلية الابتدائية المشتركة";

                    }
                    else if (Properties.Settings.Default.Database == "school3")
                    {
                        report.Parameters["SchoolNameArabic"].Value = "مدرسة الإخلاص الأهلية متوسط -ثانوي للبنات";

                    }

                    report.Parameters["ParameterClass"].Visible = false;
                    report.Parameters["ParameterDivision"].Visible = false;
                    report.Parameters["ParameterStudent"].Visible = false;


                    // Show the report's print preview.
                    report.ShowPreview();
                    break;

                case "طلب استدعاء ولي الأمر":

                    // Create a report instance.
                    var report2 =new ParentsReport();

                    // Obtain a parameter, and set its value.
                    report2.Parameters["ParameterClass"].Value = cmbClass.Text;
                    report2.Parameters["ParameterDivision"].Value = cmbDivision.Text;
                    report2.Parameters["ParameterStudent"].Value = cmbStudent.Text;

                    if (Properties.Settings.Default.Database == "school")
                    {
                        report2.Parameters["SchoolNameEnglish"].Value = "Ikhlas Private School";
                        report2.Parameters["SchoolNameArabic"].Value = "مدرسة الإخلاص الأهلية";
                        report2.Parameters["SchoolType"].Value = "ابتدائي - متوسط - ثانوي ( بنين )";
                    }
                    else if (Properties.Settings.Default.Database == "school2")
                    {
                        report2.Parameters["SchoolNameEnglish"].Value = "Ikhlas Private School";
                        report2.Parameters["SchoolNameArabic"].Value = "مدرسة الإخلاص الأهلية المشتركة";
                        report2.Parameters["SchoolType"].Value = "ابتدائي";
                    }
                    else if (Properties.Settings.Default.Database == "school3")
                    {
                        report2.Parameters["SchoolNameEnglish"].Value = "Ikhlas Private School ";
                        report2.Parameters["SchoolNameArabic"].Value = "مدرسة الإخلاص الأهلية";
                        report2.Parameters["SchoolType"].Value = "متوسط - ثانوي (بنات)";
                    }



                    report2.Parameters["ParameterClass"].Visible = false;
                    report2.Parameters["ParameterDivision"].Visible = false;
                    report2.Parameters["ParameterStudent"].Visible = false;
                    report2.Parameters["SchoolNameEnglish"].Visible = false;
                    report2.Parameters["SchoolNameArabic"].Visible = false;
                    report2.Parameters["SchoolType"].Visible = false;


                    // Show the report's print preview.
                    report2.ShowPreview();
                    break;
            }
            
           

           
        }

      
    }
}