using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiKho
{
    class SQL_NPP
    {

        KetNoiCSDL cn = new KetNoiCSDL();

        //ham them du lieu
        public void ThemDuLieu(EC_tblNPP et)
        {
            cn.ThucThiCauLenhSQL("INSERT INTO tblNPP (NPPMa, NPPTen, NPPDiaChi, NPPMaSoThue, NPPDienThoai, NPPGhiChu) VALUES " +
                "(N'" + et.NPPMa + "',N'" + et.NPPTen + "',N'" + et.NPPDiaChi + "',N'" + et.NPPMaSoThue + "',N'" + et.DienThoai + "',N'" + et.NPPGhiChu + "')");

        }
        //ham sua
        public void SuaDuLieu(EC_tblDonVi et)
        {
            //cn.ThucThiCauLenhSQL("UPDATE tblDonVi SET DVTen =N'" + et.DVTen + "', DVGhiChu =N'" + et.DVGhiChu + "' WHERE DVMa= N'" + et.DVMa + "'");

        }
        //ham xoa
        public void XoaDuLieu(EC_tblNPP et)
        {
            cn.ThucThiCauLenhSQL("DELETE from tblNPP WHERE NPPTen=N'" + et.NPPTen + "'");

        }
        //ham lay du lieu
        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable("SELECT * from tblNPP " + DieuKien);
        }
    }
}
