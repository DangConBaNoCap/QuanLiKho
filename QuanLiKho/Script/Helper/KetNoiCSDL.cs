using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiKho
{
    internal class KetNoiCSDL
    {
        public static SqlConnection connect;
        public static string server = @".\SQLEXPRESS";

        //ham o ket noi toi csdl
        public static void MoKetNoi()
        {
            if (KetNoiCSDL.connect == null)
            {
                try
                {
                    //KetNoiCSDL.connect = new SqlConnection(@"Server=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|KhoHangHoa.mdf;Database=KhoHangHoa;Trusted_Connection=Yes;");

                    KetNoiCSDL.connect = new SqlConnection("Server=" + server + ";Initial Catalog=QuanLiKho;Integrated Security=SSPI;");
                }
                catch
                {
                }
            }

            if (KetNoiCSDL.connect.State != ConnectionState.Open)
                KetNoiCSDL.connect.Open();
        }

        //ham dong ket noi
        public static void DongKetNoi()
        {
            if (KetNoiCSDL.connect != null)
            {
                if (KetNoiCSDL.connect.State == ConnectionState.Open)
                {
                    KetNoiCSDL.connect.Close();
                }
            }
        }

        //ham thuc thi cac cau lenh sql
        //insert, update, delete

        public void ThucThiCauLenhSQL(string strSQL)
        {
            try
            {
                MoKetNoi();
                SqlCommand sqlcmd = new SqlCommand(strSQL, connect);
                sqlcmd.ExecuteNonQuery();
                DongKetNoi();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Error: " + e.Message, "Cảnh báo");
            }
        }

        public DataTable GetDataTable(string strSQL)//select
        {
            try
            {
                MoKetNoi();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, connect);
                sqlda.Fill(dt);
                DongKetNoi();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public string GetValue(string strSQL, int k)//select
        {
            string temp = null;
            MoKetNoi();
            SqlCommand sqlcmd = new SqlCommand(strSQL, connect);
            SqlDataReader sqldr = sqlcmd.ExecuteReader();
            while (sqldr.Read())
            {
                temp = sqldr[k].ToString(); //tra ve cot k trong bang
            }
            DongKetNoi();
            return temp;
        }

        public SqlDataAdapter GetCmd(string strSQL)
        {
            //MoKetNoi();

            SqlDataAdapter sql = new SqlDataAdapter(strSQL, connect);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sql);

            sql.InsertCommand = cmd.GetInsertCommand();
            sql.UpdateCommand = cmd.GetUpdateCommand();
            sql.DeleteCommand = cmd.GetDeleteCommand();

            return sql;
        }

        public void DongKetNoiMetho()
        {
            DongKetNoi();
        }

        public void UpdateHangHoa(DataTable src, string type)
        {
            if (type == "NhapKho")
            {
                for (int i = 0; i < src.Rows.Count; i++)
                {
                    //lay luong con
                    string strSQL = "select HHTonHienTai from tblHangHoa where HHMa=N'" + src.Rows[i][0].ToString() + "'";
                    int SoLuong = (int)(float.Parse(GetValue(strSQL, 0)));

                    //update
                    //XtraMessageBox.Show(src.Rows[i][5].ToString());
                    SoLuong = SoLuong + (int)(float.Parse(src.Rows[i][5].ToString()));

                    strSQL = "update tblHangHoa set HHTonHienTai='" + SoLuong.ToString() + "' where HHMa='" + src.Rows[i][0].ToString().Trim() + "'";

                    ThucThiCauLenhSQL(strSQL);
                }
            }
            else if (type == "XuatKho")
            {
                for (int i = 0; i < src.Rows.Count; i++)
                {
                    //lay luong con
                    string strSQL = "select HHTonHienTai from tblHangHoa where HHMa=N'" + src.Rows[i][0].ToString() + "'";
                    int SoLuong = (int)(float.Parse(GetValue(strSQL, 0)));
                    //update
                    //XtraMessageBox.Show(src.Rows[i][5].ToString());

                    if (SoLuong < (int)(float.Parse(src.Rows[i][4].ToString())))
                    {
                        DialogResult kq = XtraMessageBox.Show(src.Rows[i][1].ToString() + " chỉ còn " + SoLuong.ToString() + ". Bạn có muốn tiếp tục xuất?", "Thông Báo", MessageBoxButtons.YesNo);
                        if (kq == DialogResult.OK)
                        {
                            SoLuong = SoLuong - (int)(float.Parse(src.Rows[i][4].ToString()));

                            strSQL = "update tblHangHoa set HHTonHienTai='" + SoLuong.ToString() + "' where HHMa='" + src.Rows[i][0].ToString().Trim() + "'";

                            ThucThiCauLenhSQL(strSQL);
                        }
                        else continue;
                    }
                    else
                    {
                        SoLuong = SoLuong - (int)(float.Parse(src.Rows[i][4].ToString()));

                        strSQL = "update tblHangHoa set HHTonHienTai='" + SoLuong.ToString() + "' where HHMa='" + src.Rows[i][0].ToString().Trim() + "'";

                        ThucThiCauLenhSQL(strSQL);
                    }
                }
            }
        }
    }
}