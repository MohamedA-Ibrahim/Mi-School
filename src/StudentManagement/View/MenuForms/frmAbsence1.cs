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
using DevExpress.Skins;


namespace MiSchool.RecordsForms
{
    public partial class frmAbsence1 : DevExpress.XtraEditors.XtraForm
    {
        //private Factory fac = new Factory();

        private void LoadData()
        {

                //// Get data and cast it to datatable

                //var dt = new Classes.DataAccessLayer().Select($"SELECT tblAbsence.AbsenceId, tblClasses.ClassName, tblDivision.DivisionName, tblStudents.StudentName, tblAbsence.date FROM tblAbsence INNER JOIN tblClasses ON tblAbsence.ClassId = tblClasses.ClassId INNER JOIN tblDivision ON tblAbsence.DivisionId = tblDivision.DivisionId INNER JOIN tblStudents ON tblAbsence.StudentId = tblStudents.StudentId ");
                //if (dt.Rows != null && dt.Rows.Count > 0)
                //{
                //    // Set datasource in datagridview to datatable
                //    gridControl1.DataSource = dt;

                //    // Set the Header text
                //    gridControl1.ForceInitialize();
                //    gridView1.PopulateColumns();
                //    gridView1.Columns["ClassName"].Caption = @"الصف";
                //    gridView1.Columns["DivisionName"].Caption = @"الشعبة";
                //    gridView1.Columns["StudentName"].Caption = @"اسم الطالب";
                //    gridView1.Columns["date"].Caption = @"التاريخ";
                //    gridView1.Columns["AbsenceId"].Visible = false;
                //}
                //IdColumn();



        }

        public frmAbsence1()
        {
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();

            InitializeComponent();
       

        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "طباعة":
                    gridControl1.ShowRibbonPrintPreview();
                        break;

                case "اضافة" :

                    frmAbsenceAdd frm=new frmAbsenceAdd();
                    frm.ShowDialog();
                    break;

                case "PDF تصدير الى":
                    SaveFileDialog svg1 = new SaveFileDialog();
                    svg1.Filter = "PDF Files|*.pdf";
                    svg1.FilterIndex = 0;
                    if (svg1.ShowDialog() == DialogResult.OK)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView
                            as DevExpress.XtraGrid.Views.Grid.GridView;
                        if (View != null) {
                            View.OptionsPrint.ExpandAllDetails = true;
                            View.ExportToPdf(svg1.FileName );
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
                        pcl.Component = gridControl1;
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
                        pcl.Component = gridControl1;
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
                        System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                        string id = row[0].ToString();
                        //fac.DeleteAbsence(int.Parse(id));
                        XtraMessageBox.Show("تم الحذف بنجاح");
                        LoadData();
                    }
                    break;


            }


        }

        private void IdColumn()
        {
            var col = gridView1.Columns.Add();
            col.FieldName = "م";
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Width=25;
            col.Fixed = FixedStyle.Left;
            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = e.ListSourceRowIndex+1;
        }

        private void frmAbsence1_Load(object sender, EventArgs e)
        {

        }

        private void frmAbsence1_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm));  
            LoadData();        
            SplashScreenManager.CloseForm();
        }
    }
}