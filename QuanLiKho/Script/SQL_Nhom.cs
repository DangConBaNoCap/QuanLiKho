using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiKho
{
    class SQL_Nhom
    {
        KetNoiCSDL cn = new KetNoiCSDL();

        //ham them du lieu
        public void ThemDuLieu(EC_tblNhom et)
        {
            cn.ThucThiCauLenhSQL("INSERT INTO tblNhom (NMa, NTen, NGhiChu, KMa) VALUES " +
                "(N'" + et.NMa + "',N'" + et.NTen + "',N'" + et.NGhiChu + "',N'" + et.KMa + "')");

        }
        //ham sua
        public void SuaDuLieu(EC_tblDonVi et)
        {
            //cn.ThucThiCauLenhSQL("UPDATE tblDonVi SET DVTen =N'" + et.DVTen + "', DVGhiChu =N'" + et.DVGhiChu + "' WHERE DVMa= N'" + et.DVMa + "'");

        }
        //ham xoa
        public void XoaDuLieu(EC_tblNhom et)
        {
            cn.ThucThiCauLenhSQL("DELETE from tblNhom WHERE NTen=N'" + et.NTen + "'");

        }
        //ham lay du lieu
        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable("SELECT * from tblNhom " + DieuKien);
        }
    }
}
