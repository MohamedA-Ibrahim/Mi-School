using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraEditors;
using MiSchool.Classes;

namespace MiSchool.HelperForms
{

    public partial class frmImportFromExcel : DevExpress.XtraEditors.XtraForm
    {
        private bool Truncate = false;
        BackgroundWorker bgw=new BackgroundWorker();

        
        public frmImportFromExcel()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            
            bgw.DoWork += Bgw_DoWork;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblPercent.Text = String.Format("{0} %", e.ProgressPercentage);
            lblProgress.Text = String.Format("تمت اضافة : {0} طلاب", e.UserState);

        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportFromExcel();

            //Thread newThread = new Thread(new ThreadStart(ImportFromExcel));
            //newThread.SetApartmentState(ApartmentState.STA);
            //newThread.Start();

        }

        private void ImportFromExcel()
        {
            try
            {
                if (Truncate == true)
                {
                    var dt = new DataAccessLayer().Excute("TRUNCATE Table tblStudents");
                }


                string AppPath = System.Windows.Forms.Application.StartupPath;


                // Create a  new workbook
                Workbook workbook = new Workbook();

                // Load the selected file from openFiledialog into the workbook
                workbook.LoadDocument(AppPath + "\\Students.xlsx", DocumentFormat.Xlsx);

                //Load the file intro the first worksheet
                Worksheet worksheet = workbook.Worksheets[0];

                //Get the range of data used
                CellRange range = worksheet.GetUsedRange();

                // Remove spaces around the data
                int firstColumnIndex = range.LeftColumnIndex;
                int firstRowIndex = range.TopRowIndex;
                if (firstColumnIndex > 0)
                    worksheet.Columns.Remove(0, firstColumnIndex);
                if (firstRowIndex > 0)
                    worksheet.Rows.Remove(0, firstRowIndex);

                // Create a datatable to transfer the data to 
                DataTable datatable = worksheet.CreateDataTable(range, true);

                //Select the datatable as a place to send the data to
                DataTableExporter exporter = worksheet.CreateDataTableExporter(range, datatable, true);

                //Set not to convert empty cells
                exporter.Options.ConvertEmptyCells = false;


                //exporter.Options.DefaultCellValueToColumnTypeConverter.SkipErrorValues = false;

                //Begin the process of importing data
                exporter.Export();



                //Loops into each row to insert into database
                for (int i = 0; i < datatable.Rows.Count; i++)
                {

                    DataAccessLayer dal = new DataAccessLayer();
                    SqlParameter[] param = new SqlParameter[7];

                    param[0] = new SqlParameter("@StudentName", SqlDbType.NVarChar, 50);
                    param[0].Value = datatable.Rows[i]["اسم الطالب"].ToString();

                    param[1] = new SqlParameter("@ClassName", SqlDbType.NVarChar, 50);
                    param[1].Value = datatable.Rows[i]["الصف"].ToString();

                    param[2] = new SqlParameter("@DivisionName", SqlDbType.NVarChar, 50);
                    param[2].Value = datatable.Rows[i]["الشعبة"].ToString();

                    param[3] = new SqlParameter("@BusName", SqlDbType.NVarChar, 50);
                    param[3].Value = datatable.Rows[i]["رقم الباص"].ToString();

                    param[4] = new SqlParameter("@Num1", SqlDbType.NVarChar, 50);
                    param[4].Value = datatable.Rows[i]["رقم 1"].ToString();

                    param[5] = new SqlParameter("@Num2", SqlDbType.NVarChar, 50);
                    param[5].Value = datatable.Rows[i]["رقم 2"].ToString();

                    param[6] = new SqlParameter("@Notes", SqlDbType.NVarChar, 400);
                    param[6].Value = datatable.Rows[i]["ملاحظات"].ToString();

                    dal.ExcuteCommand(
                        "INSERT INTO tblStudents ( StudentName, ClassId,DivisionId,BusName,Num1,Num2,Notes ) VALUES(@StudentName, " +
                        "(SELECT  ClassId FROM [tblClasses] WHERE ClassName = @ClassName), " +
                        "(SELECT  DivisionId FROM tblDivision WHERE ClassId =(SELECT  ClassId FROM [tblClasses] WHERE ClassName = @ClassName) and DivisionName=@DivisionName)," +
                        " @BusName,@Num1,@Num2,@Notes)", param);

                    System.Threading.Thread.Sleep(500);
                    int Percents = (i * 100) / datatable.Rows.Count;
                    bgw.ReportProgress(Percents, i);
                    }
                progressBar1.Value = progressBar1.Maximum;
                lblPercent.Text = @"100 %";
                MessageBox.Show(@"تم الاضافة بنجاح");


                
            }
            catch (Exception ex)
            {
                BussinessLayer.Aexception(ex.Message,
                    $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
                MessageBox.Show(ex.Message);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked) Truncate = true;

            else if (checkBox1.CheckState == CheckState.Unchecked) Truncate = false;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void lblPercent_Click(object sender, EventArgs e)
        {

        }

        private void lblProgress_Click(object sender, EventArgs e)
        {

        }
    }
}