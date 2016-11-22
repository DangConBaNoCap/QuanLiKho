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
using DevExpress.XtraEditors;




namespace QuanLiKho
{
    
    public partial class DangNhap : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private KetNoiCSDL con = new KetNoiCSDL();

        
        //name ủe
        private string lbNameUser = "Quyền ";

        public DangNhap()
        {
            InitializeComponent();

            

            //init
            try
            {
                if (con.GetValue("select checked from tblLuuMK where num like '1'", 0).Trim() == "True")
                {
                    checkLuuMK.EditValue = true;
                    txtUser.Text = con.GetValue("select name from tblLuuMK where num like '1'", 0).Trim();
                    txtPas.Text = con.GetValue("select pas from tblLuuMK where num like '1'", 0).Trim();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Error: " + e.Message+ "\n\nVui lòng tạo CSDL", "Cảnh báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            string username = txtUser.Text;
            string pas = txtPas.Text;

            TaoCSDL tempConnec = new TaoCSDL();
            //tempConnec.PutSql("connec.txt",@"Server=" + KetNoiCSDL.server + ";Initial Catalog=KhoHangHoa;Integrated Security=SSPI;");

            try
            {
                //MessageBox.Show(KetNoiCSDL.server + pas);
                

                string temp=con.GetValue("select Password from tblPhanQuyen where Username = '" + username + "'", 0).Trim();

                
                if (pas==temp)
                {
                    
                    con.ThucThiCauLenhSQL("update tblLuuMK set name='" + username + "', pas='" + pas + "' where num='1'");
                    if (checkLuuMK.Checked)
                    {
                        con.ThucThiCauLenhSQL("update tblLuuMK set checked='True' where num='1'");
                    }
                    else con.ThucThiCauLenhSQL("update tblLuuMK set checked='False' where num='1'");
                    this.Hide();

                    lbNameUser += username;
                    DateTime currentTime = DateTime.Now;

                    con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'',N'Đăng Nhập','" +
                        string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser + "')");

                    FormMain formmain = new FormMain();
                    formmain.ShowDialog();

                    
                    if (formmain.DangXuat()==true)
                    {
                        try
                        {
                            formmain.Close();

                            lbNameUser = "Quyền ";
                            this.Show();

                        }
                        catch(Exception ex)
                        {
                            XtraMessageBox.Show("Error: " + ex.Message + "\n     Vui lòng tạo CSDL");
                        }
                        
                    }
                    else if (formmain.DangXuat() == false)
                    {
                        this.Dispose();
                    }

                    
                }
                else XtraMessageBox.Show("Mật khẩu sai hoặc tài khoản đã bị xóa");
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Không thể kết nối"+ex.Message);
            }
        }

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = @"huongdan.mp4";

            LoadVideo temp = new LoadVideo(path);

            temp.ShowDialog();
        }

        private void btnTaoCSDL_Click(object sender, EventArgs e)
        {
            TaoCSDL temp = new TaoCSDL();

            temp.ShowDialog();
        }



        private void checkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienMK.Checked)
            {
                //dua ve dang binh thuong
                txtPas.Properties.PasswordChar = '\0';
            }
            else
            {
                txtPas.Properties.PasswordChar = '*';
            }
        }


 
    }
}