using System;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using MiSchool.Classes;
using MiSchool.UserControls;

namespace MiSchool.Forms
{
    public partial class frmViolations : DevExpress.XtraEditors.XtraForm
    {
        //Factory fac=new Factory();
        private void LoadData()
        {
            //try
            //{

            //    // Get data and cast it to datatable
            //    var dt = new Classes.DataAccessLayer().Select($"SELECT tblViolations.ViolationId, tblClasses.ClassName, tblDivision.DivisionName, tblStudents.StudentName, tblViolations.Uniform, tblViolations.Trouble, tblViolations.Date FROM tblViolations INNER JOIN tblStudents ON tblViolations.StudentId = tblStudents.StudentId INNER JOIN tblClasses ON tblViolations.ClassId = tblClasses.ClassId INNER JOIN tblDivision ON tblViolations.DivisionId = tblDivision.DivisionId ");
            //    // Set datasource in datagridview to datatable

            //    if (dt.Rows != null && dt.Rows.Count > 0)
            //    {
            //        gridControl2.DataSource = dt;

            //        // Set the Header text
            //        gridControl2.ForceInitialize();
            //        gridView2.PopulateColumns();
            //        gridView2.Columns["ClassName"].Caption = @"الصف";
            //        gridView2.Columns["DivisionName"].Caption = @"الشعبة";
            //        gridView2.Columns["StudentName"].Caption = @"اسم الطالب";
            //        gridView2.Columns["Uniform"].Caption = @"زي مدرسي";
            //        gridView2.Columns["Trouble"].Caption = @"مشاغبة";
            //        gridView2.Columns["Date"].Caption = @"التاريخ";
            //        gridView2.Columns["ViolationId"].Visible = false;



            //    }
            //    IdColumn();

            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}
        }

        public frmViolations()
        { 
                InitializeComponent();

        }

        private void IdColumn()
        {
            var col = gridView2.Columns.Add();
            col.FieldName = "م";
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width=25;
            col.Fixed = FixedStyle.Left;
            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView2.CustomUnboundColumnData += gridView2_CustomUnboundColumnData;
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex+1;
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "طباعة":
                    gridControl2.ShowRibbonPrintPreview();
                    break;

                case "اضافة":
                    frmViolationsAdd frm = new frmViolationsAdd();
                    frm.ShowDialog();
                    break;

                case "PDF تصدير الى":
                    SaveFileDialog svg1 = new SaveFileDialog();
                    svg1.Filter = "PDF Files|*.pdf";
                    svg1.FilterIndex = 0;
                    if (svg1.ShowDialog() == DialogResult.OK)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView View = gridControl2.MainView
                            as DevExpress.XtraGrid.Views.Grid.GridView;
                        if (View != null)
                        {
                            View.OptionsPrint.ExpandAllDetails = true;
                            View.ExportToPdf(svg1.FileName);
                        }
                    }

                    break;

                case "تصدير الى اكسيل":
                    SaveFileDialog svg2 = new SaveFileDialog();
                    svg2.Filter = "Excel Files|*.xlsx";
                    svg2.FilterIndex = 0;
                    if (svg2.ShowDialog() == DialogResult.OK)
                    {
                        PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                        pcl.Component = gridControl2;
                        pcl.PrintingSystem.ExportOptions.Xlsx.SheetName = "Report";
                        pcl.CreateDocument();
                        pcl.PrintingSystem.ExportToXlsx(svg2.FileName);
                    }
                    break;

                case "تصدير الى وورد":
                    SaveFileDialog svg3 = new SaveFileDialog();
                    svg3.Filter = "Word Files|*.docx";
                    svg3.FilterIndex = 0;
                    if (svg3.ShowDialog() == DialogResult.OK)
                    {
                        PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                        pcl.Component = gridControl2;
                        pcl.CreateDocument();
                        pcl.PrintingSystem.ExportToDocx(svg3.FileName);
                    }
                    break;

                case "تحديث":
                    LoadData();
                    break;
                case "حذف":
                    if (XtraMessageBox.Show("هل أنت متأكد من الحذف؟", "تحذير", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        System.Data.DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                        string id = row[0].ToString();
                        //fac.DeleteViolations(int.Parse(id));
                        XtraMessageBox.Show("تم الحذف بنجاح");
                        LoadData();
                    }
                    break;


            }
        }

        private void frmViolations_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm));  
            LoadData();
            SplashScreenManager.CloseForm();
        }

        private void frmViolations_Load(object sender, EventArgs e)
        {

        }
    }
}