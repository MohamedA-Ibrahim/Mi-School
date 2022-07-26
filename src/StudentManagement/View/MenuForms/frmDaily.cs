﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using MiSchool.Classes;
using MiSchool.UserControls;

namespace MiSchool.Forms
{
    public partial class frmDaily : DevExpress.XtraEditors.XtraForm
    {
        private bool RowsExist;
        //Factory fac = new Factory();

        private void LoadRepository()
        {
            if (RowsExist == true)
            {
                gridView2.Columns["ClassName"].OptionsColumn.AllowEdit = false;
                gridView2.Columns["DivisionName"].OptionsColumn.AllowEdit = false;
                gridView2.Columns["StudentName"].OptionsColumn.AllowEdit = false;
                gridView2.Columns["Date"].OptionsColumn.AllowEdit = false;

                // Problem Column
                RepositoryItemMemoExEdit repMemoEdit1 = new RepositoryItemMemoExEdit();
                repMemoEdit1.ReadOnly = true;
                gridControl2.RepositoryItems.Add(repMemoEdit1);
                (gridControl2.MainView as GridView).Columns["Problem"].ColumnEdit = repMemoEdit1;

                //Solution Column
                RepositoryItemMemoExEdit repMemoEdit2 = new RepositoryItemMemoExEdit();
                repMemoEdit2.ReadOnly = true;
                gridControl2.RepositoryItems.Add(repMemoEdit2);
                (gridControl2.MainView as GridView).Columns["Solution"].ColumnEdit = repMemoEdit2;
            }
            else return;

                 


        }

        private void LoadData()
        {
            //try
            //{
                
            //    // Get data and cast it to datatable
            //    var dt = new Classes.DataAccessLayer().Select($"SELECT tblDailySituations.DailyId, tblClasses.ClassName, tblDivision.DivisionName, tblStudents.StudentName, tblDailySituations.Problem, tblDailySituations.Solution, tblDailySituations.Date FROM tblDailySituations INNER JOIN tblClasses ON tblDailySituations.ClassId = tblClasses.ClassId INNER JOIN tblDivision ON tblDailySituations.DivisionId = tblDivision.DivisionId INNER JOIN tblStudents ON tblDailySituations.StudentId = tblStudents.StudentId");
            //    // Set datasource in datagridview to datatable

            //    if (dt.Rows != null && dt.Rows.Count > 0)
            //    {
            //        RowsExist = true;
            //        gridControl2.DataSource = dt;

            //        // Set the Header text
            //        gridControl2.ForceInitialize();
            //        gridView2.PopulateColumns();
            //        gridView2.Columns["ClassName"].Caption = @"الصف";
            //        gridView2.Columns["DivisionName"].Caption = @"الشعبة";
            //        gridView2.Columns["StudentName"].Caption = @"اسم الطالب";
            //        gridView2.Columns["Problem"].Caption = @"المشكلة";
            //        gridView2.Columns["Solution"].Caption = @"جهود الأخصائي";
            //        gridView2.Columns["Date"].Caption = @"التاريخ";
            //        gridView2.Columns["DailyId"].Visible = false;



            //    }
            //    else RowsExist = false;
            //    IdColumn();

            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}
        }

        public frmDaily()
        {
            //try
            //{
            //    InitializeComponent();

            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}
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

                case "اضافة" :
                    frmDailyAdd frm=new frmDailyAdd();
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
                    LoadRepository();
                    break;
                case "حذف":
                    if (XtraMessageBox.Show("هل أنت متأكد من الحذف؟", "تحذير", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        System.Data.DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                        string id = row[0].ToString();
                        //fac.DeleteDaily(int.Parse(id));
                        XtraMessageBox.Show("تم الحذف بنجاح");
                        LoadData();
                    }
                    break;


            }
        }

        private void frmDaily_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm));  
            LoadData();
            LoadRepository();
            SplashScreenManager.CloseForm();
        }
    }
}