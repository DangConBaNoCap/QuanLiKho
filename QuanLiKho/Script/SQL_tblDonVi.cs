using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiKho
{
    public class SQL_tblDonVi
    {
        KetNoiCSDL cn = new KetNoiCSDL();

        //ham them du lieu
        public void ThemDuLieu(EC_tblDonVi et)
        {
            cn.ThucThiCauLenhSQL("INSERT INTO tblDonVi (DVMa, DVTen, DVGhiChu) VALUES (N'" + et.DVMa + "',N'" + et.DVTen + "',N'" + et.DVGhiChu + "')");

        }
        //ham sua
        public void SuaDuLieu(EC_tblDonVi et)
        {
            cn.ThucThiCauLenhSQL("UPDATE tblDonVi SET DVTen =N'" + et.DVTen + "', DVGhiChu =N'" + et.DVGhiChu + "' WHERE DVMa= N'"+et.DVMa+"'");

        }
        //ham xoa
        public void XoaDuLieu(EC_tblDonVi et)
        {
            cn.ThucThiCauLenhSQL("DELETE from tblDonVi WHERE DVTen=N'" + et.DVTen + "'");

        }
        //ham lay du lieu
        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable("SELECT * from tblDonVi " + DieuKien);
        }

    }
}
