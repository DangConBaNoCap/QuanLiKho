using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiKho
{
    class SQL_tblXuatKho
    {
        KetNoiCSDL cn = new KetNoiCSDL();

        //ham them du lieu
        public void ThemDuLieu(EC_tblXuatKho et)
        {
            cn.ThucThiCauLenhSQL("INSERT INTO tblXuatKho (HHMa, KMa, DVMa, XKMa, XKSL, XKGia, KHMa, XKNgay,XKThanhTien) VALUES (N'" + et.HHMa + "',N'" + et.KMa + "'"+
                ",N'" + et.DVMa + "',N'" + et.XKMa + "',N'" + et.XKSL + "',N'" + et.XKGia + "',N'" + et.KHMa + "',N'" + et.XKNgay + "',(" + et.XKSL +"*"+ et.XKGia +"))");

        }
        //ham sua
        public void SuaDuLieu(EC_tblXuatKho et)
        {
            cn.ThucThiCauLenhSQL("UPDATE tblXuatKho SET HHMa =N'" + et.HHMa + "', KMa =N'" + et.KMa + "', DVMa =N'" + et.DVMa + "', XKSL =N'" + et.XKSL + "', XKGia =N'" + et.XKGia + "', KHMa =N'" + et.KHMa + "',"+
                " XKNgay =N'" + et.XKNgay + "',XKThanhTien=N'"+et.XKThanhTien+", WHERE XKMa=N'" + et.XKMa + "'");

        }
        //ham xoa
        public void XoaDuLieu(EC_tblXuatKho et)
        {
            cn.ThucThiCauLenhSQL("DELETE from tblXuatKho WHERE XKMa=N'" + et.XKMa + "'");

        }
        //ham lay du lieu
        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable("SELECT * from tblXuatKho " + DieuKien);
        }

        public DataTable LayKhachHang(string DieuKien)
        {
            return cn.GetDataTable("SELECT KHMa,KHTen from tblKhachHang " + DieuKien);
        }
        public DataTable LayHangHoaDonViKho(string DieuKien)
        {
            return cn.GetDataTable("SELECT HHMa,DVMa,KMa from tblHangHoa " + DieuKien);
        }

        //kiem tra luong hang ton

        public int KiemTra(string mahh, string maxk)
        {
            return int.Parse(cn.GetValue("SELECT count(*) from tblXuatKho where XKMa='" + maxk + "' and HHMa=N'",4));
        }
    }
}
