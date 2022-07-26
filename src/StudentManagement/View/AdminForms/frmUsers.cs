using System;
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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout.Utils;
using MiSchool.Classes;

namespace MiSchool.HelperForms
{
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {
        //Factory fac = new Factory();

        private void LoadData()
        {
            //try
            //{

            //    // Set datasource in datagridview to datatable
            //    gridControl1.DataSource =fac.GetUsers();

            //    // Set the Header text
            //    gridControl1.ForceInitialize();
            //    gridView1.PopulateColumns();
            //    gridView1.Columns["UserName"].Caption = @"معرف المستخدم";
            //    gridView1.Columns["UserNickName"].Caption = @"اسم المستخدم";
            //    gridView1.Columns["UserRole"].Caption = @"صلاحيات المستخدم";
            //    gridView1.Columns["UserId"].Visible = false;



            //}
            //catch (Exception ex)
            //{
            //    BussinessLayer.Aexception(ex.Message,
            //        $"{Name}>>{MethodBase.GetCurrentMethod().Name}>>{ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}");
            //    MessageBox.Show(ex.Message);
            //}
            IdColumn();

        }


        public frmUsers()
        {
            InitializeComponent();
            LoadData();
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

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "اضافة")
            {
                frnUsersAddEdit frm= new frnUsersAddEdit();

                frm.btnOk.Text = "اضافة";
                frm.state = "add";
                frm.layoutControlItem7.Visibility = LayoutVisibility.Never;
                frm.layoutControlItem4.Enabled = true;
                    
                frm.ShowDialog();
            }
           else if (e.Button.Properties.Caption == "تعديل")
            {
                frnUsersAddEdit frm= new frnUsersAddEdit();

                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                frm.UserId = int.Parse(row[0].ToString());
                frm.txtUserName.Text = row[1].ToString();
                frm.txtUserNickName.Text = row[2].ToString();
                frm.ComboBoxEditUserRoles.EditValue = row[3].ToString();
                frm.Text="تعديل بيانات" + row[2].ToString();
                frm.btnOk.Text = "تعديل";
                frm.state = "update";
                    
                frm.ShowDialog();
            }
            else if (e.Button.Properties.Caption == "حذف")
            {
                if (XtraMessageBox.Show("هل أنت متأكد من الحذف؟", "تحذير", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    string id = row[0].ToString();
                    //fac.DeleteUser(int.Parse(id));
                    XtraMessageBox.Show("تم الحذف بنجاح");
                    LoadData();
                }
            }

            else if (e.Button.Properties.Caption == "تحديث")
            {
                LoadData();

            }



        }
    }
}