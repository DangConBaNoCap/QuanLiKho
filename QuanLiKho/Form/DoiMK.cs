using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QuanLiKho
{
    public partial class DoiMK : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private KetNoiCSDL con = new KetNoiCSDL();

        public DoiMK()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMKHT.Text == con.GetValue("select pas from tblLuuMK where num='1'", 0).Trim())
                {
                    if (txtMKMoi.Text == txtNLMK.Text)
                    {
                        string user = con.GetValue("select name from tblLuuMK where num='1'", 0);
                        con.ThucThiCauLenhSQL("update tblPhanQuyen set Password='" + txtMKMoi.Text + "' where Username='" + user + "'");

                        MessageBox.Show("Đã thay đổi mật khẩu");
                        this.Dispose();
                    }
                    else MessageBox.Show("Nhập lại mật khẩu không đúng");
                }
                else MessageBox.Show("Mật khẩu không đúng. Nhập lại!","Thông Báo");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienMK.Checked)
            {
                //dua ve dang binh thuong
                txtMKHT.Properties.PasswordChar='\0';
                txtMKMoi.Properties.PasswordChar='\0';
                txtNLMK.Properties.PasswordChar='\0';
            }
            else
            {
                txtMKHT.Properties.PasswordChar = '*';
                txtMKMoi.Properties.PasswordChar = '*';
                txtNLMK.Properties.PasswordChar = '*';
            }
        }



    }
}