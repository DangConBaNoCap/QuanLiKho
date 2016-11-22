using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiKho
{
    class SQL_tblKhachHang
    {
        KetNoiCSDL cn = new KetNoiCSDL();

        //ham them du lieu
        public void ThemDuLieu(EC_tblKhachHang et)
        {
            cn.ThucThiCauLenhSQL("INSERT INTO tblKhachHang (KHMa, KHTen, KHDiaChi, KHMaSoThue, KHDienThoai) VALUES (N'" + et.KHMa + "',N'" + et.KHTen + "',"+
                "N'" + et.KHDiaChi + "',N'" + et.KHMaSoThue + "',N'" + et.KHDienThoai + "')");

        }
        //ham sua
        public void SuaDuLieu(EC_tblKhachHang et)
        {
            cn.ThucThiCauLenhSQL("UPDATE tblKhachHang SET KHTen =N'" + et.KHTen + "', KHDiaChi =N'" + et.KHDiaChi + "', KHMaSoThue =N'" + et.KHMaSoThue + "',"+
                " KHDienThoai =N'" + et.KHDienThoai + "' WHERE KHMa= N'" + et.KHMa + "'");

        }
        //ham xoa
        public void XoaDuLieu(EC_tblKhachHang et)
        {
            cn.ThucThiCauLenhSQL("DELETE from tblKhachHang WHERE KHTen=N'" + et.KHTen + "'");

        }
        //ham lay du lieu
        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable("SELECT * from tblKhachHang " + DieuKien);
        }
    }
}
