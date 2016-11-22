using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiKho
{
    class SQL_Kho
    {
        KetNoiCSDL cn = new KetNoiCSDL();

        //ham them du lieu
        public void ThemDuLieu(EC_tblKho et)
        {
            cn.ThucThiCauLenhSQL("INSERT INTO tblKho (KMa, KTen, KNguoiLienHe, KDiaChi, KDienThoai, KNguoiQuanLi, KDienGiai) VALUES "+
                "(N'" + et.KMa + "',N'" + et.KTen + "',N'" + et.KNguoiLienHe + "',N'" + et.KDiaChi + "',N'" + et.KDienThoai + "',N'" + et.KNguoiQuanLi + "',N'" + et.KDienGiai + "')");

        }
        //ham sua
        public void SuaDuLieu(EC_tblDonVi et)
        {
            //cn.ThucThiCauLenhSQL("UPDATE tblDonVi SET DVTen =N'" + et.DVTen + "', DVGhiChu =N'" + et.DVGhiChu + "' WHERE DVMa= N'" + et.DVMa + "'");

        }
        //ham xoa
        public void XoaDuLieu(EC_tblKho et)
        {
            cn.ThucThiCauLenhSQL("DELETE from tblKho WHERE KTen=N'" + et.KTen + "'");

        }
        //ham lay du lieu
        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable("SELECT * from tblKho " + DieuKien);
        }
    }
}
