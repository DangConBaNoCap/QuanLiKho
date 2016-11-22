using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.OleDb;

namespace QuanLiKho
{
    class ExportToExcel
    {
        public string filePath;

        public DialogResult openDialog()
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "Excel 97-2003 files (*.xls)|*.xls",
                InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                Multiselect = false,
                Title = "Quản Lí Kho - Chọn tập tin Excel",
                CheckFileExists = true,
                CheckPathExists = true
            };
            DialogResult dr = openfiledialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.Abort || dr == System.Windows.Forms.DialogResult.Cancel || dr == System.Windows.Forms.DialogResult.Ignore)
            {
                return DialogResult.Cancel;
            }
            else
            {
                filePath = openfiledialog.FileName;
                return DialogResult.OK;
            }
        }

        /// <summary>
        /// Xuất dữ liệu từ gridControl
        /// </summary>
        /// <param name="fType">Kiểu dữ liệu cần xuất ra</param>
        public void exportFile(string fType, DevExpress.XtraGrid.GridControl gridControl1)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    CheckPathExists = true,
                    InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                    OverwritePrompt = true,
                    Title = "Xuất dữ liệu thành tập tin định dạng " + fType,
                    Filter = fType + "|" + fType
                };
                DialogResult dr = sfd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK || dr == System.Windows.Forms.DialogResult.Yes)
                {
                    switch (fType)
                    {
                        case "*.html":
                            gridControl1.ExportToHtml(sfd.FileName);
                            break;
                        case "*.pdf":
                            gridControl1.ExportToPdf(sfd.FileName);
                            break;
                        case "*.txt":
                            gridControl1.ExportToText(sfd.FileName);
                            break;
                        case "*.xls":
                            gridControl1.ExportToXls(sfd.FileName);
                            break;
                        case "*.xlsx":
                            gridControl1.ExportToXlsx(sfd.FileName);
                            break;
                        case "*.rtf":
                            gridControl1.ExportToRtf(sfd.FileName);
                            break;
                        default:
                            break;
                    }
                    dr = MessageBox.Show("Xuất dữ liệu thành công! Bạn có muốn mở tập tin vừa xuất ra không?", "Xác nhận mở tập tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static object OpenFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy tập tin.");
                return null;
            }
            var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", filePath);
            var adapter = new OleDbDataAdapter("select * from [Sheet1$]", connectionString);
            var ds = new DataSet();
            string tableName = "excelData";
            adapter.Fill(ds, tableName);
            DataTable data = ds.Tables[tableName];
            return data;
        }


    }
}
