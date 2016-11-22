using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace QuanLiKho
{
    class SQL_tblHangHoa
    {
        KetNoiCSDL cn = new KetNoiCSDL();

        //ham them du lieu
        public void ThemDuLieu(EC_tblHangHoa et)
        {
            cn.ThucThiCauLenhSQL("INSERT INTO tblHangHoa (HHMa, HHTen, HHGia, DVMa, KMa, NPPMa, HHTonHienTai, NMa, HHThanhTien) VALUES (N'"+et.HHMa+"'"+
                ",N'" + et.HHTen + "',N'" + et.HHGia + "',N'" + et.DVMa + "',N'" + et.KMa + "',N'" + et.NPPMa + "',N'" + et.HHTonHienTai + "',N'" + et.NMa + "',("+et.HHTonHienTai+"*"+et.HHGia+"))");

        }
        //ham sua
        public void SuaDuLieu(EC_tblHangHoa et)
        {
            cn.ThucThiCauLenhSQL("UPDATE tblHangHoa SET HHTen =N'" + et.HHTen + "', HHGia =N'" + et.HHGia + "', DVMa =N'" + et.DVMa + "', NPPMa =N'" + et.NPPMa + "',"
            +"HHTonHienTai =N'" + et.HHTonHienTai + "', NMa =N'" + et.NMa + "', KMa =N'" + et.KMa + "' WHERE HHMa=N'"+et.HHMa+"'");

        }
        //ham xoa
        public void XoaDuLieu(EC_tblHangHoa et)
        {
            cn.ThucThiCauLenhSQL("DELETE from tblHangHoa WHERE HHMa=N'" + et.HHMa + "'");

        }
        //ham lay du lieu
        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable("SELECT * from tblHangHoa " + DieuKien);
        }
    }
}
