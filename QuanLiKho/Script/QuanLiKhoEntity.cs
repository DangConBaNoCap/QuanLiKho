using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKho
{
    class QuanLiKhoEntity
    {
    }

    public class EC_tblHangHoa
    {
        private string _HHMa;

        public string HHMa
        {
            get { return _HHMa; }
            set { _HHMa = value; }
        }
        private string _HHTen;

        public string HHTen
        {
            get { return _HHTen; }
            set { _HHTen = value; }
        }

        private string _HHGia;

        public string HHGia
        {
            get { return _HHGia; }
            set { _HHGia = value; }
        }
        private string _DVMa;

        public string DVMa
        {
            get { return _DVMa; }
            set { _DVMa = value; }
        }
        private string _KMa;

        public string KMa
        {
            get { return _KMa; }
            set { _KMa = value; }
        }
        private string _NPPMa;

        public string NPPMa
        {
            get { return _NPPMa; }
            set { _NPPMa = value; }
        }
        private string _HHTonHienTai;

        public string HHTonHienTai
        {
            get { return _HHTonHienTai; }
            set { _HHTonHienTai = value; }
        }
        private string _NMa;

        public string NMa
        {
            get { return _NMa; }
            set { _NMa = value; }
        }
    }

    public class EC_tblDonVi
    {
        private string _DVMa;

        public string DVMa
        {
            get { return _DVMa; }
            set { _DVMa = value; }
        }
        private string _DVTen;

        public string DVTen
        {
            get { return _DVTen; }
            set { _DVTen = value; }
        }
        private string _DVGhiChu;

        public string DVGhiChu
        {
            get { return _DVGhiChu; }
            set { _DVGhiChu = value; }
        }             
    }


    public class EC_tblNPP
    {
        private string _NPPMa;

        public string NPPMa
        {
          get { return _NPPMa; }
          set { _NPPMa = value; }
        }
        private string _NPPTen;

        public string NPPTen
        {
          get { return _NPPTen; }
          set { _NPPTen = value; }
        }
        private string _NPPDiaChi;

        public string NPPDiaChi
        {
            get { return _NPPDiaChi; }
            set { _NPPDiaChi = value; }
        }
        private string _NPPMaSoThue;

        public string NPPMaSoThue
        {
            get { return _NPPMaSoThue; }
            set { _NPPMaSoThue = value; }
        }
        private string _DienThoai;

        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }
        private string _NPPGhiChu;

        public string NPPGhiChu
        {
            get { return _NPPGhiChu; }
            set { _NPPGhiChu = value; }
        }
    }


    public class EC_tblNhom
    {
        private string _NMa;

        public string NMa
        {
            get { return _NMa; }
            set { _NMa = value; }
        }
        private string _NTen;

        public string NTen
        {
            get { return _NTen; }
            set { _NTen = value; }
        }
        private string _NGhiChu;

        public string NGhiChu
        {
            get { return _NGhiChu; }
            set { _NGhiChu = value; }
        }
        private string _KMa;

        public string KMa
        {
            get { return _KMa; }
            set { _KMa = value; }
        }
    }

    public class EC_tblKho
    {
        private string _KMa;

        public string KMa
        {
            get { return _KMa; }
            set { _KMa = value; }
        }
        private string _KTen;

        public string KTen
        {
            get { return _KTen; }
            set { _KTen = value; }
        }
        private string _KNguoiLienHe;

        public string KNguoiLienHe
        {
            get { return _KNguoiLienHe; }
            set { _KNguoiLienHe = value; }
        }
        private string _KDiaChi;

        public string KDiaChi
        {
            get { return _KDiaChi; }
            set { _KDiaChi = value; }
        }
        private string _KDienThoai;

        public string KDienThoai
        {
            get { return _KDienThoai; }
            set { _KDienThoai = value; }
        }
        private string _KNguoiQuanLi;

        public string KNguoiQuanLi
        {
            get { return _KNguoiQuanLi; }
            set { _KNguoiQuanLi = value; }
        }
        private string _KDienGiai;

        public string KDienGiai
        {
            get { return _KDienGiai; }
            set { _KDienGiai = value; }
        }
    }

    public class EC_tblNhapKho
    {
        private string _HHMa;

        public string HHMa
        {
            get { return _HHMa; }
            set { _HHMa = value; }
        }
        private string _KMa;

        public string KMa
        {
            get { return _KMa; }
            set { _KMa = value; }
        }
        private string _DVMa;

        public string DVMa
        {
            get { return _DVMa; }
            set { _DVMa = value; }
        }
        private string _NKMa;

        public string NKMa
        {
            get { return _NKMa; }
            set { _NKMa = value; }
        }
        private string _NKSL;

        public string NKSL
        {
            get { return _NKSL; }
            set { _NKSL = value; }
        }
        private string _HHGia;

        public string HHGia
        {
            get { return _HHGia; }
            set { _HHGia = value; }
        }
        private string _NKThanhTien;

        public string NKThanhTien
        {
            get { return _NKThanhTien; }
            set { _NKThanhTien = value; }
        }
        private string _NKNgay;

        public string NKNgay
        {
            get { return _NKNgay; }
            set { _NKNgay = value; }
        }
    }
    public class EC_tblXuatKho
    {
        private string _HHMa;

        public string HHMa
        {
            get { return _HHMa; }
            set { _HHMa = value; }
        }
        private string _KMa;

        public string KMa
        {
            get { return _KMa; }
            set { _KMa = value; }
        }
        private string _DVMa;

        public string DVMa
        {
            get { return _DVMa; }
            set { _DVMa = value; }
        }
        private string _XKMa;

        public string XKMa
        {
            get { return _XKMa; }
            set { _XKMa = value; }
        }
        private string _XKSL;

        public string XKSL
        {
            get { return _XKSL; }
            set { _XKSL = value; }
        }
        private string _XKGia;

        public string XKGia
        {
            get { return _XKGia; }
            set { _XKGia = value; }
        }
        private string _KHMa;

        public string KHMa
        {
            get { return _KHMa; }
            set { _KHMa = value; }
        }
        private string _XKNgay;

        public string XKNgay
        {
            get { return _XKNgay; }
            set { _XKNgay = value; }
        }

        private string _XKThanhTien;

        public string XKThanhTien
        {
            get { return _XKThanhTien; }
            set { _XKThanhTien = value; }
        }            
    }

    public class EC_tblKhachHang
    {

        private string _KHMa;

        public string KHMa
        {
            get { return _KHMa; }
            set { _KHMa = value; }
        }
        private string _KHTen;

        public string KHTen
        {
            get { return _KHTen; }
            set { _KHTen = value; }
        }
        private string _KHDiaChi;

        public string KHDiaChi
        {
            get { return _KHDiaChi; }
            set { _KHDiaChi = value; }
        }
        private string _KHMaSoThue;

        public string KHMaSoThue
        {
            get { return _KHMaSoThue; }
            set { _KHMaSoThue = value; }
        }
        private string _KHDienThoai;

        public string KHDienThoai
        {
            get { return _KHDienThoai; }
            set { _KHDienThoai = value; }
        }

        private string _KHGhiChu;

        public string KHGhiChu
        {
            get { return _KHGhiChu; }
            set { _KHGhiChu = value; }
        }
    }
}
