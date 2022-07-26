using System;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using MiSchool.Classes;
using DevExpress.XtraReports.UI;
using MiSchool.Reports;
using System.Collections.Generic;
using MiSchool.Model;
using MiSchool.Controller;

namespace MiSchool.Forms
{
    public partial class frnStudentsList : DevExpress.XtraEditors.XtraForm
    {
        List<CLS_Classroom> classrooms = new List<CLS_Classroom>();
        List<CLS_Section> sections = new List<CLS_Section>();


        public frnStudentsList()
        {
            InitializeComponent();
        }

        private void LoadClasses()
        {
            cmdClassroom cmd = new cmdClassroom();
            classrooms= cmd.GetAllClass();
            cmbClass.DataSource = classrooms;
            cmbClass.DisplayMember = "ClassName";
            cmbClass.ValueMember = "ClassId";
        }

        private void LoadDivisions()
        {

            cmdSection cmd = new cmdSection();
            string s = cmbClass.SelectedValue.ToString();

            int id = int.Parse(s);

            cmbDivision.DataSource = cmd.GetSectionByClassId(id);
            cmbDivision.DisplayMember = "SectionName";
            cmbDivision.ValueMember = "SectionId";
            cmbDivision.SelectedIndex = -1;
        }

        private void LoadStudents()
        {

        }

        private void frnStudentsList_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm));
            LoadClasses();
            AddIdColumn();
            //cmbClass.SelectedIndex = -1;
            //cmbDivision.SelectedIndex = -1;
            SplashScreenManager.CloseForm();
        }

        private void frnStudentsList_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserRole == "admin" || Properties.Settings.Default.UserRole == "root")
            {
                windowsUIButtonPanelMain.Buttons["حذف"].Properties.Enabled = true;
                windowsUIButtonPanelMain.Buttons["استيراد الطلاب"].Properties.Enabled = true;
            }

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadDivisions();
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudents();
        }


        private void AddIdColumn()
        {
            var col = gridView1.Columns.Add();
            col.FieldName = "م";
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width = 25;
            col.Fixed = FixedStyle.Left;
            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
        }

        private void gridView1_CustomUnboundColumnData(object sender,DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            //string button = e.Button.Properties.Caption;

            //if (button == "طباعة")
            //{
            //    gridControl1.ShowRibbonPrintPreview();
            //}
            //else if (button == "اضافة")
            //{

            //    frmStudentsAddEdit frm = new frmStudentsAddEdit();
            //    frm.ShowDialog();
            //}
            //else if (button == "تعديل")
            //{
            //    frmStudentsAddEdit frn = new frmStudentsAddEdit();

            //    System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            //    frn.StudentId = int.Parse(row[0].ToString());
            //    frn.txtStudentName.Text = row[1].ToString();
            //    frn.txtBus.Text = row[2].ToString();
            //    frn.txtNum1.Text = row[3].ToString();
            //    frn.txtNum2.Text = row[4].ToString();
            //    frn.memoEditNotes.Text = row[5].ToString();

            //    frn.cmbClass.SelectedValue = cmbClass.SelectedValue;
            //    frn.cmbDivision.SelectedValue = cmbDivision.SelectedValue;

            //    frn.cmbClass.Enabled = false;
            //    frn.cmbDivision.Enabled = false;

            //    frn.Text = @"تعديل بيانات" + row[2].ToString();
            //    frn.btnAdd.Text = @"تعديل";
            //    frn.state = "update";

            //    frn.ShowDialog();
            //}
            //else if (button == "PDF تصدير الى")
            //{
            //    SaveFileDialog svg1 = new SaveFileDialog();
            //    svg1.Filter = "PDF Files|*.pdf";
            //    svg1.FilterIndex = 0;
            //    if (svg1.ShowDialog() == DialogResult.OK)
            //    {
            //        DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView
            //            as DevExpress.XtraGrid.Views.Grid.GridView;
            //        if (View != null)
            //        {
            //            View.OptionsPrint.ExpandAllDetails = true;
            //            View.ExportToPdf(svg1.FileName);
            //        }
            //    }
            //}
            //else if (button == "تصدير الى اكسيل")
            //{
            //    SaveFileDialog svg2 = new SaveFileDialog();
            //    svg2.Filter = "Excel Files|*.xlsx";
            //    svg2.FilterIndex = 0;
            //    if (svg2.ShowDialog() == DialogResult.OK)
            //    {
            //        PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
            //        pcl.Component = gridControl1;
            //        pcl.PrintingSystem.ExportOptions.Xlsx.SheetName = "Report";
            //        pcl.CreateDocument();
            //        pcl.PrintingSystem.ExportToXlsx(svg2.FileName);
            //    }
            //}
            //else if (button == "تصدير الى وورد")
            //{
            //    SaveFileDialog svg3 = new SaveFileDialog();
            //    svg3.Filter = "Word Files|*.docx";
            //    svg3.FilterIndex = 0;
            //    if (svg3.ShowDialog() == DialogResult.OK)
            //    {
            //        PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
            //        pcl.Component = gridControl1;
            //        pcl.CreateDocument();
            //        pcl.PrintingSystem.ExportToDocx(svg3.FileName);
            //    }
            //}
            //else if (button == "تحديث")
            //{
            //    LoadStudents();
            //}
            //else if (button == "حذف")
            //{
            //    if (XtraMessageBox.Show("هل أنت متأكد من الحذف؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        System.Data.DataRow roww = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //        string id = roww[0].ToString();
            //        //fac.DeleteStudent(int.Parse(id));
            //        XtraMessageBox.Show("تم الحذف بنجاح");
            //        LoadStudents();
            //    }
            //}
            //else if (button == "استيراد الطلاب")
            //{
            //    string AppPath = System.Windows.Forms.Application.StartupPath;
            //    //string AppPath = System.AppDomain.CurrentDomain.BaseDirectory;
            //    System.Diagnostics.Process.Start(AppPath + "\\Students.xlsx");

            //    frmImportFromExcel frmImport = new frmImportFromExcel();
            //    frmImport.ShowDialog();
            //}
            //else if (button == "تقرير الطالب")
            //{
            //    System.Data.DataRow rowww = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //    string studentId = rowww[0].ToString();

            //    //Create a report instance.
            //    var report = new StudentReport();

            //    //Obtain a parameter, and set its value.
            //    report.Parameters["ParameterStudentId"].Value = studentId;
            //    report.Parameters["ParameterStudentId"].Visible = false;

            //    //Show the report's print preview.
            //    report.ShowPreview();
            //}
        }
    }
}