using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.Layout;
using DevExpress.XtraEditors;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using DevExpress.Charts;
using System.Configuration;

namespace QuanLiKho
{
    public enum state
    {
        StateNK,
        StateXK,
        StateTK
    }

    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static state StateManager;
        KetNoiCSDL con = new KetNoiCSDL();

        //dem so luong tab con hien thi
        private int vSoXtraTab = 1;

        //khai bao cac thu tuc xuat kho
        SQL_tblXuatKho sqlXK = new SQL_tblXuatKho();
        EC_tblXuatKho ecXK = new EC_tblXuatKho();



        //khai bao cac thu tuc khach hang
        SQL_tblKhachHang sqlKH = new SQL_tblKhachHang();

        //dang nhap, dang xuat
        private bool active = false;


        //lay dong chon trong bang phan quyen
        private string userSelect;

        //dung cho bo loc bao cao
        private string stateBC;

        //phan quyen
        private bool xoaDL = true;

        //Thoi gian bieu do
        private string start;
        private string end;

        //nhap kho
        private string dateState = "tuan";
        private string cmdTime;

        private string start1;
        private string end1;

        //Xuat kho
        private string cmdTime1;
        private string stateQL;

        public FormMain()
        {
            InitializeComponent();

            //tat tat ca cac xtraTab
            //======================================================================
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (xtraTabMain.TabPages[i].Text != "Nhập Kho")
                    xtraTabMain.TabPages.Remove(xtraTabMain.TabPages[i]);
            }
            xtraTabMain.TabPages.Remove(xtraTPTonKho);
            xtraTabMain.TabPages.Remove(BDXK);
            xtraTabMain.TabPages.Remove(xtrapTPBoPhan);
            xtraTabMain.TabPages.Remove(xtraTPNhanVien);
            xtraTabMain.TabPages.Remove(xtraTPPhanQuyen);
            //======================================================================
            init();
            initDatabase();
            //initPQ();
        }

        private void initDatabase()
        {
            DataTable listKhachHang= con.GetDataTable("select * form tblKhachHang");
            comboBoxEditTenNK.Properties.DataSource = listKhachHang;
        }
        private void init()
        {
            active = false; //khong dang xuat

            //Nhap kho
            txtMaNPP.Enabled = false;
            txtGhiChuNK.Enabled = false;
            txtDiaChiNK.Enabled = false;
            txtDienThoaiNK.Enabled = false;
            comboBoxEditTenNK.Enabled = false;
            txtMaNK.Enabled = false;
            dateEditNK.Enabled = false;
            txtMSTNK.Enabled = false;
            gridControlNK.Enabled = false;

            btnCancelNK.Enabled = false;
            btnOKNK.Enabled = false;
            btnRefeshNK.Enabled = false;

            //xuat kho
            gridLookUpEditTenXK.Enabled = false;
            gridLookUpEditMaXK.Enabled = false;
            txtDiaChiXk.Enabled = false;
            txtDienThoaiXK.Enabled = false;
            txtGhiChuXK.Enabled = false;
            txtMaXK.Enabled = false;
            txtMSTXK.Enabled = false;
            dateEditNgayXK.Enabled = false;
            gridControlXK.Enabled = false;

            btnOKXK.Enabled = false;
            btnRefeshXK.Enabled = false;
            //btnCancelXK.Enabled = false;


            txtMaNK.ReadOnly = true;
            txtMaXK.ReadOnly = true;

            //bo phan
            //btnXoaBP.Enabled = false;
            btnThemBP.Enabled = false;
            btnRefeshBP.Enabled = false;

            //nhan vien
            //btnXoaNV.Enabled = false;
            btnThemNV.Enabled = false;
            btnRefeshNV.Enabled = false;

            //name ủe
            lbNameUser.Text += con.GetValue("select name from tblLuuMK where num='1'", 0);
        }


        //them tab
        private void AddXtraTab(DevExpress.XtraTab.XtraTabPage xtraTabName)
        {

            switch (xtraTabName.Text)
            {
                case "Nhập Kho":
                    StateManager = state.StateNK;
                    break;
                case "Xuất Kho":
                    StateManager = state.StateXK;
                    break;
                case "Tồn Kho":
                    StateManager = state.StateTK;
                    break;
            }

            xtraTabMain.SelectedTabPage = xtraTabName;


            //kiem tra xem tab da co chua
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (xtraTabName.Text == xtraTabMain.TabPages[i].Text)
                {
                    return;
                }
            }
            vSoXtraTab++;
            xtraTabMain.TabPages.Add(xtraTabName);
        }

        //xoa tab

        private void xtraTabMain_Close(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabControl TabControl = (DevExpress.XtraTab.XtraTabControl)sender;

            if (vSoXtraTab != 1)
            {
                xtraTabMain.SelectedTabPageIndex -= 1;
                DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
                TabControl.TabPages.Remove(arg.Page as DevExpress.XtraTab.XtraTabPage);
                vSoXtraTab--;
            }
            else XtraMessageBox.Show("Bạn không thể tắt tất cả các page!", "Cảnh báo");
        }

        private void barBtnNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //them tab
            AddXtraTab(xtraTPNhapKho);

            if (!(txtMaNK.Text == "" || txtDienThoaiNK.Text == "" || comboBoxEditTenNK.Text == "" || txtMaXK.Text == "" || txtDiaChiNK.Text == ""))
            {
                txtMaNPP.Enabled = false;
                txtGhiChuNK.Enabled = false;
                txtDiaChiNK.Enabled = false;
                txtDienThoaiNK.Enabled = false;
                comboBoxEditTenNK.Enabled = false;
                txtMaNK.Enabled = false;
                dateEditNK.Enabled = false;
                txtMSTNK.Enabled = false;

                btnCancelNK.Enabled = false;
                btnOKNK.Enabled = false;
                btnRefeshNK.Enabled = false;
            }


            //nhat ki 
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Nhập Kho',N'Xem','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");

            //MessageBox.Show(string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime));
        }

        private void barBtnXuatKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //them tab
            AddXtraTab(xtraTPXuaKho);



            if (!(txtDiaChiXk.Text == "" || txtMaXK.Text != "" || txtGhiChuXK.Text != "" || txtMSTXK.Text != "" || txtDienThoaiXK.Text != "" || txtMaNK.Text != "")) //dieu kien
            {
                //khoa dieu kien, chi mo khi an new
                gridLookUpEditTenXK.Enabled = false;
                gridLookUpEditMaXK.Enabled = false;
                txtDiaChiXk.Enabled = false;
                txtDienThoaiXK.Enabled = false;
                txtGhiChuXK.Enabled = false;
                txtMaXK.Enabled = false;
                txtMSTXK.Enabled = false;
                dateEditNgayXK.Enabled = false;
                gridControlXK.Enabled = false;

                btnOKXK.Enabled = false;
                btnRefeshXK.Enabled = false;
                btnCancelXK.Enabled = false;


            }

            //nhat ki 
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Xuất Kho',N'Xem','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");

        }

        private void barBtnTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //them tab
            AddXtraTab(xtraTPTonKho);



            DataTable temp = new DataTable();
            temp = con.GetDataTable("select a.HHMa,a.HHTen,a.HHGia,c.DVTen,b.KTen,e.NPPTen,a.HHTonHienTai,d.NTen,a.HHThanhTien " +
                "from tblHangHoa as a join tblKho as b ON a.KMa=b.KMa join tblDonVi as c on a.DVMa=c.DVMa join tblNhom as d ON a.NMa=d.NMa join tblNPP as e " +
                "on a.NPPMa=e.NPPMa ");
            //temp = con.GetDataTable("select * from tblHangHoa as a join tblKho as b on a.KMa=b.KMa join tblDonVi as c on a.DVMa=c.DVMa join tblNPP as d on a.NPPMa=d.NPPMa "+
            //    "join tblNhom as e on a.NMa=e.NMa");

            gridControlTK.DataSource = temp;

            //cac thanh cong cu
            lbName.Hide();
            gridNhom.Hide();
            gridNPP.Hide();
            gridHangHoa.Hide();
            gridKho.Hide();

            //nhat ki 
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Tồn Kho',N'Xem','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }


        private void barBtnBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //them tab
            AddXtraTab(xtraTPBaoCao);

            //hien nhap kho
            navBarGroup2_ItemChanged(sender, e);
            gridView12.ActiveFilterString = null;

            //nhat ki 
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Báo Cáo',N'Xem','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void btnNewXK_Click(object sender, EventArgs e)
        {
            gridLookUpEditTenXK.Enabled = true;
            gridLookUpEditMaXK.Enabled = true;
            txtDiaChiXk.Enabled = true;
            txtDienThoaiXK.Enabled = true;
            txtGhiChuXK.Enabled = true;
            txtMaXK.Enabled = true;
            txtMSTXK.Enabled = true;
            dateEditNgayXK.Enabled = true;


            btnRefeshXK.Enabled = true;



            gridLookUpEditTenXK.Text = "";
            gridLookUpEditMaXK.Text = "";
            txtDiaChiXk.Text = "";
            txtDienThoaiXK.Text = "";
            txtGhiChuXK.Text = "";
            txtMaXK.Text = "";
            txtMSTXK.Text = "";
            dateEditNgayXK.Text = "";
            gridControlXK.Text = "";

            DataTable temp = new DataTable();
            temp = con.GetDataTable("select * from tblXuatKhoTemp as a join tblHangHoa as b on a.HHMa=b.HHMa");
            gridControlXK.DataSource = temp;
            //lay ma xuat kho
            DataTable temp1 = new DataTable();
            temp1 = con.GetDataTable("select * from tblXuatKho");
            if (temp1.Rows.Count > 0)
            {
                string tempStr = temp1.Rows[temp1.Rows.Count - 1][3].ToString();

                int i = Convert.ToInt32(tempStr.Substring(2));
                i++;
                txtMaXK.Text = "XK" + i.ToString("0000");
            }
            else txtMaXK.Text = "XK0001";

            dateEditNgayXK.Text = DateTime.Today.ToString();
        }

        private void gridLookUpEditTenXK_EditValueChanged(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            if (gridLookUpEditTenXK.Text != "")
            {
                try
                {
                    string cmd = "SELECT * FROM tblKhachHang WHERE KHTen Like N'" + gridLookUpEditTenXK.Text + "'";
                    temp = con.GetDataTable(cmd);



                    txtDiaChiXk.Text = temp.Rows[0][2].ToString();
                    txtMSTXK.Text = temp.Rows[0][3].ToString();
                    txtDienThoaiXK.Text = temp.Rows[0][4].ToString();
                    //txtGhiChuXK.Text = temp.Rows[0][4].ToString();
                    gridLookUpEditMaXK.Text = temp.Rows[0][0].ToString();

                    gridControlXK.Enabled = true;

                    gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "KHMa", gridLookUpEditMaXK.Text);
                }
                catch
                {
                    XtraMessageBox.Show("Không có dữ liệu về khách hàng!", "Cảnh báo");
                }

            }


        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void btnRefeshXK_Click(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            temp = con.GetDataTable("select * from tblXuatKhoTemp as a join tblHangHoa as b on a.HHMa=b.HHMa");

            gridControlXK.DataSource = temp;

            //FormMain_Load(sender, e);
            btnCancelXK.Enabled = false;
        }

        private void btnOKXK_Click(object sender, EventArgs e)
        {

            if (SaveChane("tblXuatKhoTemp"))
            {
                XtraMessageBox.Show("Đã lưu!", "Thông Báo");
                btnOKXK.Enabled = false;
                if (xoaDL == true) btnCancelXK.Enabled = true;

                con.ThucThiCauLenhSQL("insert into tblXuatKho(HHMa, KMa, XKMa, DVMa, XKSL, XKGia, KHMa, XKNgay, XKThanhTien) select HHMa, KMa, XKMa, DVMa, XKSL, XKGia, KHMa, XKNgay, XKThanhTien from tblXuatKhoTemp");
                con.ThucThiCauLenhSQL("delete from tblXuatKhoTemp");
                //btnRefeshXK_Click(sender, e);
            }

        }

        private bool SaveChane(string cmd)
        {
            bool res = false;
            SqlDataAdapter sql = con.GetCmd("select * from " + cmd);
            try
            {
                if (cmd == "tblXuatKhoTemp")
                {
                    DataTable temp = gridControlXK.DataSource as DataTable;

                    sql.Update(temp.GetChanges());  //luu tat ca hung thay doi
                    con.UpdateHangHoa(temp, "XuatKho");
                }
                if (cmd == "tblNhapKhoTemp")
                {
                    DataTable temp = gridControlNK.DataSource as DataTable;

                    sql.Update(temp.GetChanges());  //luu tat ca hung thay doi
                    con.UpdateHangHoa(temp, "NhapKho");

                }

                res = true;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message);
                res = false;
            }
            finally
            {
                con.DongKetNoiMetho();
            }

            return res;
        }

        private void repositoryItemGridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //DataTable temp = new DataTable();
            //temp = con.GetDataTable("select HHMa,HHTen,KMa from tblHangHoa like 'HH0001'");
            //gridControlXK.DataSource = temp;


        }

        private void gridView6_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridView6.GetRowCellDisplayText(e.RowHandle, "XKMa").ToString() != "")
            {
                txtMaXK.Text = gridView6.GetRowCellDisplayText(e.RowHandle, "XKMa").ToString();
                dateEditNgayXK.EditValue = gridView6.GetRowCellDisplayText(e.RowHandle, "XKNgay").ToString();
            }
            else
            {
                DataTable temp = new DataTable();
                temp = con.GetDataTable("select * from tblXuatKhoTemp as a join tblHangHoa as b on a.HHMa=b.HHMa");

                //lay ma xuat kho

                DataTable temp1 = new DataTable();
                temp1 = con.GetDataTable("select * from tblXuatKho");

                if (temp.Rows.Count > 0)
                {
                    string tempStr = temp1.Rows[temp1.Rows.Count - 1][3].ToString();

                    int i = Convert.ToInt32(tempStr.Substring(2));
                    i++;
                    txtMaXK.Text = "XK" + i.ToString("0000");
                }
                else txtMaXK.Text = "XK0001";
            }


        }

        private void gridView6_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //tu dong them ma xuat kho
            string tempStr = txtMaXK.Text;

            int i = Convert.ToInt32(tempStr.Substring(2));
            i++;
            txtMaXK.Text = "XK" + i.ToString("0000");
        }

        private void btnNewNK_Click(object sender, EventArgs e)
        {
            txtMaNPP.Enabled = true;
            txtGhiChuNK.Enabled = true;
            txtDiaChiNK.Enabled = true;
            txtDienThoaiNK.Enabled = true;
            comboBoxEditTenNK.Enabled = true;
            txtMaNK.Enabled = true;
            dateEditNK.Enabled = true;
            txtMSTNK.Enabled = true;

            btnRefeshNK.Enabled = true;

            txtMaNPP.Text = "";
            txtGhiChuNK.Text = "";
            txtDiaChiNK.Text = "";
            txtDienThoaiNK.Text = "";
            comboBoxEditTenNK.Text = "";
            txtMaNK.Text = "";
            txtMSTNK.Text = "";



            DataTable temp = new DataTable();
            temp = con.GetDataTable("select * from tblNhapKhoTemp as a join tblHangHoa as b on a.HHMa=b.HHMa");
            gridControlNK.DataSource = temp;

            DataTable temp1 = new DataTable();
            temp1 = con.GetDataTable("select * from tblNhapKho");
            if (temp1.Rows.Count > 0)
            {
                //lay ma nhap kho
                string tempStr = temp1.Rows[temp1.Rows.Count - 1][3].ToString();

                int i = Convert.ToInt32(tempStr.Substring(2));
                i++;
                txtMaNK.Text = "NK" + i.ToString("0000");


            }
            else txtMaNK.Text = "NK0001";

            dateEditNK.Text = DateTime.Today.ToString();
        }

        private void comboBoxEditTenNK_EditValueChanged(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            if (comboBoxEditTenNK.Text != "")
            {
                try
                {
                    string cmd = "SELECT * FROM tblNPP WHERE NPPTen Like N'" + comboBoxEditTenNK.Text + "'";
                    temp = con.GetDataTable(cmd);

                    txtDiaChiNK.Text = temp.Rows[0][2].ToString();
                    txtMSTNK.Text = temp.Rows[0][3].ToString();
                    txtDienThoaiNK.Text = temp.Rows[0][4].ToString();
                    txtGhiChuXK.Text = temp.Rows[0][5].ToString();
                    txtMaNPP.Text = temp.Rows[0][0].ToString();


                    gridControlNK.Enabled = true;
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "NPPMa", txtMaNPP.Text);
                }
                catch
                {
                    XtraMessageBox.Show("Không có dữ liệu về nhà phân phối!", "Cảnh báo");
                }
            }
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //tu dong them ma nhap kho
            string tempStr = txtMaNK.Text;

            int i = Convert.ToInt32(tempStr.Substring(2));
            i++;
            txtMaXK.Text = "NK" + i.ToString("0000");
        }

        private void btnOKNK_Click(object sender, EventArgs e)
        {


            try
            {
                if (SaveChane("tblNhapKhoTemp"))
                {
                    XtraMessageBox.Show("Đã lưu!", "Thông Báo");
                    btnOKNK.Enabled = false;
                    if (xoaDL == true) btnCancelNK.Enabled = true;

                    con.ThucThiCauLenhSQL("insert into tblNhapKho(HHMa, KMa, DVMa, NKMa, NKNgay, NKSL, NKGia, NKThanhTien, NPPMa) select HHMa, KMa, DVMa, NKMa, NKNgay, NKSL, NKGia, NKThanhTien, NPPMa from tblNhapKhoTemp");
                    con.ThucThiCauLenhSQL("delete from tblNhapKhoTemp");
                    //btnRefeshNK_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void btnRefeshNK_Click(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            temp = con.GetDataTable("select * from tblNhapKhoTemp as a join tblHangHoa as b on a.HHMa=b.HHMa");

            gridControlNK.DataSource = temp;


            //FormMain_Load(sender, e);
            btnCancelNK.Enabled = false;
        }

        private void gridControlNK_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them temp = new Them("KhachHang");
            temp.ShowDialog();
            FormMain_Load(sender, e);

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Khách Hàng',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them temp = new Them("NPP");
            temp.ShowDialog();
            FormMain_Load(sender, e);

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Nhà Phân Phối',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them temp = new Them("Kho");
            temp.ShowDialog();
            FormMain_Load(sender, e);

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Kho Hàng',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them temp = new Them("DonVi");
            temp.ShowDialog();
            FormMain_Load(sender, e);

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Đơn Vị',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them temp = new Them("Nhom");
            temp.ShowDialog();
            FormMain_Load(sender, e);

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Nhóm',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them temp = new Them("HangHoa");
            temp.ShowDialog();
            FormMain_Load(sender, e);

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Hàng Hóa',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Them temp = new Them("NPP");
            temp.ShowDialog();
            FormMain_Load(sender, e);


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Them temp = new Them("KhachHang");
            temp.ShowDialog();
            FormMain_Load(sender, e);
        }

        private void barBtnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            active = false;
            Application.Exit();
        }

        public bool DangXuat()
        {
            return active; //true la dang xuat, false la thoat
        }

        private void barBtnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            active = true;

            this.Close();

            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Đăng Xuất',N'Xem','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");

            lbNameUser.Text = "Quyền ";
        }

        private void btnPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddXtraTab(xtraTPPhanQuyen);
            gridControlTTTK.DataSource = con.GetDataTable("select * from tblPhanQuyen");

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Phân Quyền',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");

        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {


            if (gridView9.OptionsView.NewItemRowPosition == DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None)
            {
                gridView9.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            }
            else
            {
                SqlDataAdapter sql = con.GetCmd("select * from tblPhanQuyen");

                DataTable temp = gridControlTTTK.DataSource as DataTable;

                try
                {
                    sql.Update(temp);

                    XtraMessageBox.Show("                   Đã thiết lập\nNếu thay đổi tài khoản đang hoạt động\n         vui lòng đăng nhập lại", "Thông Báo");
                }
                catch
                {
                    XtraMessageBox.Show("Nhập thiếu");
                    return;
                }
                //nhat ki
                DateTime currentTime = DateTime.Now;
                con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Phân Quyền',N'Sửa','" +
                   string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sql = con.GetCmd("select * from tblPhanQuyen");

            DataTable temp = gridControlTTTK.DataSource as DataTable;

            try
            {
                sql.Update(temp);

                XtraMessageBox.Show("                   Đã thiết lập\nNếu thay đổi tài khoản đang hoạt động\n         vui lòng đăng nhập lại", "Thông Báo");
            }
            catch
            {
                XtraMessageBox.Show("Nhập thiếu");
                return;
            }
            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Phân Quyền',N'Sửa','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            try
            {
                con.ThucThiCauLenhSQL("delete tblPhanQuyen where Username='" + userSelect + "'");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro: " + ex.Message, "Cảnh Báo");
                return;
            }
            XtraMessageBox.Show("Đã xóa", "Thông Báo");
            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Phân Quyền',N'Xóa','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");

            gridControlTTTK.DataSource = con.GetDataTable("select * from tblPhanQuyen");
        }

        private void gridView9_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            userSelect = gridView9.GetRowCellDisplayText(e.RowHandle, "Username").ToString();
        }


        private void initPQ()
        {
            DataTable temp = new DataTable();
            try
            {
                //lay user hien tai
                string user = con.GetValue("select name from tblLuuMK where num='1'", 0);
                //phan quyen
                temp = con.GetDataTable("select * from tblPhanQuyen where Username like '" + user + "'");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro: " + ex.Message, "Cảnh Báo");
                return;
            }
            //them dl

            if (temp.Rows[0][2].ToString().Trim() != "True")
            {
                btnNewNK.Enabled = false;
                btnNewXK.Enabled = false;


                grouplTTNPP.Enabled = false;
                groupTTKH.Enabled = false;

                navBarGroupThemNK.Visible = false;
                navBarGroupThemXK.Visible = false;

                btnNewBP.Enabled = false;
                btnNewNhanVien.Enabled = false;
            }
            //xoa dl
            if (temp.Rows[0][5].ToString().Trim() != "True")
            {
                btnCancelNK.Enabled = false;
                btnCancelXK.Enabled = false;

                btnXoaBP.Enabled = false;
                btnXoaNV.Enabled = false;

                xoaDL = false;

                btnXoaNhatKi.Enabled = false;

            }

            if (temp.Rows[0][3].ToString().Trim() != "True")
            {
                //btnPhanQuyen.Enabled = false;
                btnThemTK.Enabled = false;
            }

            //kho hang
            if (temp.Rows[0][6].ToString().Trim() != "True")
            {
                ribbonPageGroupQLK.Enabled = false;
                ribbonPageGroupHeThong.Enabled = false;
                ribbonPageGroupTI.Enabled = false;
            }
            //he thong

            if (temp.Rows[0][7].ToString().Trim() != "True")
            {
                ribbonPageGroupBaoMat.Enabled = false;
            }

            //danh muc 

            if (temp.Rows[0][8].ToString().Trim() != "True")
            {
                ribbonPageGroupTC.Enabled = false;
                ribbonPageGroupDT.Enabled = false;
                ribbonPageGroupKH.Enabled = false;
            }
            if (temp.Rows[0][9].ToString().Trim() != "True")
            {
                btnPhanQuyen.Enabled = false;
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoiMK temp = new DoiMK();
            temp.ShowDialog();

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Đổi Mật Khẩu',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void gridView2_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView2.GetRowCellDisplayText(e.RowHandle, "NKMa").ToString() != "")
            {
                txtMaNK.Text = gridView2.GetRowCellDisplayText(e.RowHandle, "NKMa").ToString();
                dateEditNK.EditValue = gridView2.GetRowCellDisplayText(e.RowHandle, "NKNgay").ToString();
            }
            else
            {
                DataTable temp = new DataTable();
                temp = con.GetDataTable("select * from tblNhapKhoTemp as a join tblHangHoa as b on a.HHMa=b.HHMa");

                DataTable temp1 = new DataTable();
                temp1 = con.GetDataTable("select * from tblNhapKho");
                if (temp1.Rows.Count > 0)
                {
                    //lay ma nhap kho
                    string tempStr = temp1.Rows[temp1.Rows.Count - 1][3].ToString();

                    int i = Convert.ToInt32(tempStr.Substring(2));
                    i++;
                    txtMaNK.Text = "NK" + i.ToString("0000");
                }
                else txtMaNK.Text = "NK0001";
            }

        }

        private void repositoryItemGridLookUpEdit2_Leave(object sender, EventArgs e)
        {
            string getHHMa = gridView2.GetRowCellDisplayText(gridView2.FocusedRowHandle, "HHMa");
            DataTable temp = new DataTable();
            try
            {
                temp = con.GetDataTable("select * from tblHangHoa where HHMa=N'" + getHHMa + "'");
            }
            catch
            {
                XtraMessageBox.Show("Mã nhập kho chưa đúng");
                return;
            }

            if (temp.Rows.Count != 0)
            {
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "HHTen", temp.Rows[0][1].ToString().Trim());
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "NKMa", txtMaNK.Text);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "NKNgay", dateEditNK.Text);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "NPPMa", txtMaNPP.Text);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "KMa", temp.Rows[0][4].ToString().Trim());
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "DVMa", temp.Rows[0][3].ToString().Trim());
            }



            if (txtMaNK.Text != "")
            {
                btnOKNK.Enabled = true;

            }
            else btnOKNK.Enabled = false;
        }

        private void repositoryItemGridLookUpEdit1_Leave(object sender, EventArgs e)
        {
            string getHHMa = gridView6.GetRowCellDisplayText(gridView6.FocusedRowHandle, "HHMa");
            DataTable temp = new DataTable();
            try
            {
                temp = con.GetDataTable("select * from tblHangHoa where HHMa=N'" + getHHMa + "'");
            }
            catch
            {
                XtraMessageBox.Show("Mã xuất kho chưa đúng");
                return;
            }

            if (temp.Rows.Count != 0)
            {
                gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "HHTen", temp.Rows[0][1].ToString().Trim());
                gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "KMa", temp.Rows[0][4].ToString().Trim());
                gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "DVMa", temp.Rows[0][3].ToString().Trim());
                gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "XKMa", txtMaXK.Text);
                gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "XKNgay", dateEditNgayXK.Text);
                gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "KHMa", gridLookUpEditMaXK.Text);
                txtGhiChuNK.Text = temp.Rows[0][4].ToString().Trim();
            }



            if (txtMaXK.Text != "")
            {
                btnOKXK.Enabled = true;

            }
            else
            {
                btnOKXK.Enabled = false;
            }
        }

        private void XKGiaEdit_Leave(object sender, EventArgs e)
        {
            string gia = gridView6.GetRowCellDisplayText(gridView6.FocusedRowHandle, "XKGia").Trim();
            string soluong = gridView6.GetRowCellDisplayText(gridView6.FocusedRowHandle, "XKSL").Trim();

            try
            {
                string tt = (int.Parse(soluong) * float.Parse(gia)).ToString();
                gridView6.SetRowCellValue(gridView6.FocusedRowHandle, "XKThanhTien", tt);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro: " + ex.Message, "Thông Báo");
            }
        }

        private void NKGiaEdit_Leave(object sender, EventArgs e)
        {
            string gia = gridView2.GetRowCellDisplayText(gridView2.FocusedRowHandle, "NKGia").Trim();
            string soluong = gridView2.GetRowCellDisplayText(gridView2.FocusedRowHandle, "NKSL").Trim();

            if (gia != "" && soluong != "")
            {
                try
                {
                    string tt = (Convert.ToInt32(gia) * Convert.ToInt32(soluong)).ToString();
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "NKThanhTien", tt);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Erro: " + ex.Message, "Thông Báo");
                }
            }
        }

        private void btnCancelNK_Click(object sender, EventArgs e)
        {
            if (gridControlNK.Enabled == true)
            {
                string MaNK = gridView2.GetRowCellDisplayText(gridView2.FocusedRowHandle, "NKMa").Trim();

                try
                {
                    con.ThucThiCauLenhSQL("delete from tblNhapKho where NKMa='" + MaNK + "'");
                    XtraMessageBox.Show("Đã xóa");
                    //btnRefeshNK_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Erro: " + ex.Message);
                }

            }

        }

        private void btnCancelXK_Click(object sender, EventArgs e)
        {
            if (gridControlXK.Enabled == true)
            {
                string MaXK = gridView6.GetRowCellDisplayText(gridView6.FocusedRowHandle, "XKMa").Trim();

                try
                {
                    con.ThucThiCauLenhSQL("delete from tblXuatKho where XKMa='" + MaXK + "'");
                    XtraMessageBox.Show("Đã xóa");
                    //btnRefeshXK_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Erro: " + ex.Message);
                }
            }

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Them temp = new Them("HangHoa");
            temp.ShowDialog();
            FormMain_Load(sender, e);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Them temp = new Them("NPP");
            temp.ShowDialog();
            FormMain_Load(sender, e);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Them temp = new Them("Kho");
            temp.ShowDialog();
            FormMain_Load(sender, e);
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Them temp = new Them("HangHoa");
            temp.ShowDialog();
            FormMain_Load(sender, e);
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Them temp = new Them("KhachHang");
            temp.ShowDialog();
            FormMain_Load(sender, e);
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Them temp = new Them("Kho");
            temp.ShowDialog();
            FormMain_Load(sender, e);
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //bo phan

            AddXtraTab(xtrapTPBoPhan);
            gridView10.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            DataTable temp = con.GetDataTable("select * from tblBoPhan");
            gridControlBoPhan.DataSource = temp;

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Bộ Phận',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //nhan vien 
            AddXtraTab(xtraTPNhanVien);
            gridView11.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            DataTable temp = con.GetDataTable("select * from tblNhanVien");
            gridControlNhanVien.DataSource = temp;

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Nhân Viên',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void btnNewBP_Click(object sender, EventArgs e)
        {
            gridView10.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            btnThemBP.Enabled = true;
            btnRefeshBP.Enabled = true;
        }

        private void btnRefeshBP_Click(object sender, EventArgs e)
        {
            DataTable temp = con.GetDataTable("select * from tblBoPhan");
            gridControlBoPhan.DataSource = temp;
        }

        private void btnXoaBP_Click(object sender, EventArgs e)
        {
            if (gridControlBoPhan.Enabled == true)
            {
                string MaBP = gridView10.GetRowCellDisplayText(gridView10.FocusedRowHandle, "BPMa").Trim();

                try
                {
                    con.ThucThiCauLenhSQL("delete from tblBoPhan where BPMa='" + MaBP + "'");
                    XtraMessageBox.Show("Đã xóa");
                    btnRefeshBP_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Erro: " + ex.Message);
                }

            }
        }

        private void btnThemBP_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable temp = gridControlBoPhan.DataSource as DataTable;
                SqlDataAdapter cmd = con.GetCmd("select * from tblBoPhan");

                cmd.Update(temp.GetChanges());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro: " + ex.Message);
            }

            FormMain_Load(sender, e);
        }

        private void btnNewNhanVien_Click(object sender, EventArgs e)
        {
            gridView11.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            btnThemNV.Enabled = true;
            btnRefeshNV.Enabled = true;


        }

        private void btnRefeshNV_Click(object sender, EventArgs e)
        {
            DataTable temp = con.GetDataTable("select * from tblNhanVien");
            gridControlNhanVien.DataSource = temp;
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (gridControlNhanVien.Enabled == true)
            {
                string MaNV = gridView11.GetRowCellDisplayText(gridView10.FocusedRowHandle, "NVMa").Trim();

                try
                {
                    con.ThucThiCauLenhSQL("delete from tblNhanVien where NVMa='" + MaNV + "'");
                    XtraMessageBox.Show("Đã xóa");
                    btnRefeshNV_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Erro: " + ex.Message);
                }

            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable temp = gridControlNhanVien.DataSource as DataTable;
                SqlDataAdapter cmd = con.GetCmd("select * from tblNhanVien");

                cmd.Update(temp.GetChanges());

                XtraMessageBox.Show("Đã thêm", "Thông Báo");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void thanhTienNK_Leave(object sender, EventArgs e)
        {
            //lay ma nhap kho
            //string tempStr = txtMaNK.Text;

            //int i = Convert.ToInt32(tempStr.Substring(2));
            //i++;
            //txtMaNK.Text = "NK" + i.ToString("0000");
        }

        private void ThanhTienXK_Leave(object sender, EventArgs e)
        {
            //string tempStr = txtMaXK.Text;

            //int i = Convert.ToInt32(tempStr.Substring(2));
            //i++;
            //txtMaXK.Text = "XK" + i.ToString("0000");
        }

        private void gridView2_ValidateRow_1(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //lay ma nhap kho
            string tempStr = txtMaNK.Text;

            int i = Convert.ToInt32(tempStr.Substring(2));
            i++;
            txtMaNK.Text = "NK" + i.ToString("0000");
        }

        private void navBarGroup1_ItemChanged(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            temp = con.GetDataTable("select * from tblHangHoa");
            gridControlBaoCao.MainView = gridView12;
            gridControlBaoCao.DataSource = temp;

        }

        private void navBarGroup2_ItemChanged(object sender, EventArgs e)
        {
            gridView12.Columns.Clear();

            gridControlBaoCao.DataSource = con.GetDataTable("select a.HHMa,b.HHTen,c.KTen,d.DVTen,a.NKMa,a.NKNgay,a.NKSL,a.NKGia,a.NKThanhTien,e.NPPTen " +
                "from tblNhapKho as a join tblHangHoa as b on a.HHMa=b.HHMa" +
                " join tblKho as c on a.KMa=c.KMa" +
                " join tblDonVi as d on a.DVMa=d.DVMa join tblNPP as e on a.NPPMa=e.NPPMa");

            stateBC = "NK";

        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            lbName.Hide();
            gridNhom.Hide();
            gridNPP.Hide();
            gridHangHoa.Hide();
            gridKho.Hide();

            gridView8.ActiveFilterString = null;
        }

        private void navBarGroup5_ItemChanged(object sender, EventArgs e)
        {
            //gridNhom.Hide();
            //gridNPP.Hide();
            //gridHangHoa.Hide();
            //gridKho.Hide();
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            lbName.Show();
            lbName.Text = "Hàng Hóa";
            gridNhom.Hide();
            gridNPP.Hide();
            gridHangHoa.Show();
            gridKho.Hide();


        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            lbName.Show();
            lbName.Text = "NPP";
            gridNhom.Hide();
            gridNPP.Show();
            gridHangHoa.Hide();
            gridKho.Hide();

            gridNPP.Location = gridHangHoa.Location;
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            lbName.Show();
            lbName.Text = "Nhóm Hàng";
            gridNhom.Show();
            gridNPP.Hide();
            gridHangHoa.Hide();
            gridKho.Hide();

            gridNhom.Location = gridHangHoa.Location;
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            lbName.Show();
            lbName.Text = "Kho";
            gridNhom.Hide();
            gridNPP.Hide();
            gridHangHoa.Hide();
            gridKho.Show();

            gridKho.Location = gridHangHoa.Location;
        }

        private void gridHangHoa_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void gridHangHoa_EditValueChanged(object sender, EventArgs e)
        {

            gridView8.ActiveFilterString = "[HHTen] LIKE '" + gridHangHoa.Text.ToString() + "'";
        }

        private void gridNPP_EditValueChanged(object sender, EventArgs e)
        {
            gridView8.ActiveFilterString = "[NPPTen] LIKE '" + gridNPP.Text.ToString() + "'";
        }

        private void gridNhom_EditValueChanged(object sender, EventArgs e)
        {
            gridView8.ActiveFilterString = "[NTen] LIKE '" + gridNhom.Text.ToString() + "'";
        }

        private void gridKho_EditValueChanged(object sender, EventArgs e)
        {
            gridView8.ActiveFilterString = "[KTen] LIKE '" + gridKho.Text.ToString() + "'";
        }

        private void navBarGroup3_ItemChanged(object sender, EventArgs e)
        {
            gridView12.Columns.Clear();

            gridControlBaoCao.DataSource = con.GetDataTable("select a.HHMa,b.HHTen,c.KTen,d.DVTen,a.XKMa,a.XKNgay,a.XKSL,a.XKGia,a.XKThanhTien,e.KHTen " +
                "from tblXuatKho as a join tblHangHoa as b on a.HHMa=b.HHMa" +
                " join tblKho as c on a.KMa=c.KMa" +
                " join tblDonVi as d on a.DVMa=d.DVMa join tblKhachHang as e on a.KHMa=e.KHMa");

            stateBC = "XK";
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridView12.ActiveFilterString != null) gridView12.ActiveFilterString += " and ";
            gridView12.ActiveFilterString += "[HHTen] LIKE '" + gridHHBC.Text.ToString() + "'";
        }

        private void dateEditTu_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void navNhapTH_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            dateEditDen.Text = "";
            dateEditTu.Text = "";
            gridHHBC.Text = "";

            gridView12.ActiveFilterString = null;

        }

        private void navXuatTH_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView12.ActiveFilterString = null;
            dateEditDen.Text = "";
            dateEditTu.Text = "";
            gridHHBC.Text = "";
        }

        private void dateEditDen_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEditTu_Leave(object sender, EventArgs e)
        {
            if (gridView12.ActiveFilterString != null) gridView12.ActiveFilterString += " and ";
            if (stateBC == "NK")
            {
                //MessageBox.Show("click");
                if (dateEditTu.Text != "") gridView12.ActiveFilterString += "[NKNgay] >= '" + dateEditTu.Text + "'";
                else gridView12.ActiveFilterString = null;

                if (dateEditDen.Text != "" && dateEditTu.Text != "")
                {
                    if (dateEditTu.DateTime.CompareTo(dateEditDen.DateTime) == 1)
                    {
                        XtraMessageBox.Show("Ngày sau không được nhỏ hơn ngày trước", "Thông Báo");
                        return;
                    }
                    else gridView12.ActiveFilterString += "and [NKngay] <= '" + dateEditDen.Text + "'";
                }
            }

            if (stateBC == "XK")
            {
                if (dateEditTu.Text != "") gridView12.ActiveFilterString += "[XKNgay] >= '" + dateEditTu.Text + "'";
                else gridView12.ActiveFilterString = null;

                if (dateEditDen.Text != "" && dateEditTu.Text != "")
                {
                    if (dateEditTu.DateTime.CompareTo(dateEditDen.DateTime) == 1)
                    {
                        XtraMessageBox.Show("Ngày sau không được nhỏ hơn ngày trước", "Thông Báo");
                        return;
                    }
                    else gridView12.ActiveFilterString += "and [XKngay] <= '" + dateEditDen.Text + "'";
                }
            }
        }

        private void dateEditDen_Leave(object sender, EventArgs e)
        {
            if (gridView12.ActiveFilterString != null) gridView12.ActiveFilterString += " and ";
            if (stateBC == "NK")
            {
                //MessageBox.Show("click");
                if (dateEditDen.Text != "") gridView12.ActiveFilterString += "[NKNgay] <= '" + dateEditDen.Text + "'";
                else gridView12.ActiveFilterString = null;

                if (dateEditTu.Text != "" && dateEditTu.Text != "")
                {
                    if (dateEditTu.DateTime.CompareTo(dateEditDen.DateTime) == 1)
                    {
                        XtraMessageBox.Show("Ngày sau không được nhỏ hơn ngày trước", "Thông Báo");
                        return;
                    }
                    else gridView12.ActiveFilterString += "and [NKngay] >= '" + dateEditTu.Text + "'";
                }
            }

            if (stateBC == "XK")
            {
                if (dateEditDen.Text != "") gridView12.ActiveFilterString += "[XKNgay] <= '" + dateEditDen.Text + "'";
                else gridView12.ActiveFilterString = null;

                if (dateEditTu.Text != "" && dateEditTu.Text != "")
                {
                    if (dateEditTu.DateTime.CompareTo(dateEditDen.DateTime) == 1)
                    {
                        XtraMessageBox.Show("Ngày sau không được nhỏ hơn ngày trước", "Thông Báo");
                        return;
                    }
                    else gridView12.ActiveFilterString += "and [XKngay] >= '" + dateEditTu.Text + "'";
                }
            }
        }

        private void btnPrintNK_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.xls", gridControlNK);
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddXtraTab(xtraTPBaoCao);
            navBarGroup2_ItemChanged(sender, e);
            navNhapNgay_LinkClicked(sender, e);
        }

        private void navNhapNgay_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView12.ShowCustomFilterDialog(gridView12.Columns[5]);
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddXtraTab(xtraTPBaoCao);
            navBarGroup2_ItemChanged(sender, e);
            navNhapHH_LinkClicked(sender, e);
        }

        private void navNhapHH_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView12.ShowCustomFilterDialog(gridView12.Columns[1]);
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddXtraTab(xtraTPBaoCao);
            navBarGroup3_ItemChanged(sender, e);
            navXuatNgay_LinkClicked(sender, e);
        }

        private void navXuatNgay_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView12.ShowCustomFilterDialog(gridView12.Columns[5]);
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddXtraTab(xtraTPBaoCao);
            navBarGroup3_ItemChanged(sender, e);
            navXuatHH_LinkClicked(sender, e);
        }

        private void navXuatHH_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView12.ShowCustomFilterDialog(gridView12.Columns[1]);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.pdf", gridControlNK);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.pdf", gridControlXK);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.xls", gridControlXK);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.xls", gridControlTK);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.pdf", gridControlTK);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.pdf", gridControlBaoCao);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.xls", gridControlBaoCao);
        }

        private void btnThemKK_Click(object sender, EventArgs e)
        {
            DialogResult temp = XtraMessageBox.Show("Bạn có muốn cập nhật lại số lượng Hàng Hóa?", "Thông Báo", MessageBoxButtons.YesNo);
            if (SaveChane("tblKiemKeTemp"))
            {
                XtraMessageBox.Show("Đã lưu!", "Thông Báo");

                con.ThucThiCauLenhSQL("insert into tblKiemKe(KKMa, KKNgay, HHMa, HHTen, NMa, KMa, KKNguoi, KKSL, HHSL) select KKMa, KKNgay, HHMa, HHTen, NMa, KMa, KKNguoi, KKSL, HHSL from tblKiemKeTemp");

                //btnRefeshXK_Click(sender, e);
            }
            if (temp == DialogResult.Yes)
            {
                DataTable temp1 = con.GetDataTable("select * from tblKiemKeTemp");

                for (int i = 0; i < temp1.Rows.Count; i++)
                {
                    //XtraMessageBox.Show(temp1.Rows[i][2].ToString() + temp1.Rows[i][7].ToString());
                    con.ThucThiCauLenhSQL("update tblHangHoa set HHTonHienTai=" + temp1.Rows[i][7].ToString() + " where HHMa='" + temp1.Rows[i][2].ToString() + "'");
                }
            }
            else
            {

            }
            con.ThucThiCauLenhSQL("delete from tblKiemKeTemp");

        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView12.ActiveFilterString = null;
            dateEditDen.Dispose();
            dateEditTu.Dispose();
            gridHHBC.Text = "";
        }

        private void navBarGroup1_ItemChanged_1(object sender, EventArgs e)
        {
            gridView12.Columns.Clear();

            gridControlBaoCao.DataSource = con.GetDataTable("select * from tblKiemKe");

            stateBC = "KK";
        }


        private void TenHang_Click(object sender, EventArgs e)
        {
            repositoryItemGridLookUpEdit1_Leave(sender, e);
        }

        private void HHTenEdit_Click(object sender, EventArgs e)
        {
            repositoryItemGridLookUpEdit2_Leave(sender, e);
        }

        private void barbtnTHK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddXtraTab(BDXK);
            gridHH.Text = "";
            gridHHXK.Text = "";

            btnNow_Click(sender, e);
            btnNowXK_Click(sender, e);
            //chartTK.DataSource = con.GetDataTable("select HHTen,HHSL from tblHangHoa");

            //nhat ki 
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Tổng Hợp Kho',N'Xem','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            //thu 2 tuan nay
            DateTime tempTime = new DateTime();
            tempTime = DateTime.Now.Date;


            if (dateState == "tuan")
            {
                while (tempTime.DayOfWeek != DayOfWeek.Monday) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(6));

            }
            if (dateState == "thang")
            {
                while (tempTime.Day > 1) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(DateTime.DaysInMonth(tempTime.Year, tempTime.Month) - 1));

            }

            if (dateState == "quy")
            {
                if (tempTime.Month < 4)
                {
                    start = tempTime.Year + "/1/1";
                    end = tempTime.Year + "/3/31";
                }
                if (tempTime.Month >= 4 && tempTime.Month < 7)
                {
                    start = tempTime.Year + "/4/1";
                    end = tempTime.Year + "/6/30";
                }
                if (tempTime.Month >= 7 && tempTime.Month < 10)
                {
                    start = tempTime.Year + "/7/1";
                    end = tempTime.Year + "/9/30";
                }
                if (tempTime.Month >= 10 && tempTime.Month < 13)
                {
                    start = tempTime.Year + "/10/1";
                    end = tempTime.Year + "/12/31";
                }
            }

            cmdTime = "select HHTen,NKSL,NKNgay from tblNhapKho as a join tblHangHoa as b on a.HHMa=b.HHMa where NKNgay>= '" + start + "' and NKNgay<= '" + end + "'";
            chartNK.DataSource = con.GetDataTable(cmdTime);

            //MessageBox.Show(start+end);
        }

        private void comboxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridHH.Text = "";

            if (comboxDate.SelectedIndex == 0)
            {
                dateState = "tuan";
                btnNow.Text = "Tuần Này";
                btnYester.Text = "Tuần Trước";

                btnNow_Click(sender, e);
            }
            if (comboxDate.SelectedIndex == 1)
            {
                dateState = "thang";
                btnNow.Text = "Tháng Này";
                btnYester.Text = "Tháng Trước";

                btnNow_Click(sender, e);
            }
            if (comboxDate.SelectedIndex == 2)
            {
                dateState = "quy";
                btnNow.Text = "Quý Này";
                btnYester.Text = "Quý Trước";

                btnNow_Click(sender, e);
            }
        }

        private void btnYester_Click(object sender, EventArgs e)
        {
            //thu 2 tuan truoc
            DateTime tempTime = new DateTime();
            tempTime = DateTime.Now.Date;
            tempTime = tempTime.AddDays(-7);

            if (dateState == "tuan")
            {
                while (tempTime.DayOfWeek != DayOfWeek.Monday) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(6));

            }
            if (dateState == "thang")
            {
                tempTime = tempTime.AddMonths(-1);
                while (tempTime.Day > 1) tempTime = tempTime.AddDays(-1);

                start = string.Format("{0:yyyy/MM/dd}", tempTime);
                end = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(DateTime.DaysInMonth(tempTime.Year, tempTime.Month) - 1));

            }

            if (dateState == "quy")
            {
                tempTime = tempTime.AddMonths(-3);
                if (tempTime.Month < 4)
                {
                    start = tempTime.Year + "/1/1";
                    end = tempTime.Year + "/3/31";
                }
                if (tempTime.Month >= 4 && tempTime.Month < 7)
                {
                    start = tempTime.Year + "/4/1";
                    end = tempTime.Year + "/6/30";
                }
                if (tempTime.Month >= 7 && tempTime.Month < 10)
                {
                    start = tempTime.Year + "/7/1";
                    end = tempTime.Year + "/9/30";
                }
                if (tempTime.Month >= 10 && tempTime.Month < 13)
                {
                    start = tempTime.Year + "/10/1";
                    end = tempTime.Year + "/12/31";
                }
            }

            cmdTime = "select HHTen,NKSL,NKNgay from tblNhapKho as a join tblHangHoa as b on a.HHMa=b.HHMa where NKNgay>= '" + start + "' and NKNgay<= '" + end + "'";
            chartNK.DataSource = con.GetDataTable(cmdTime);

            //MessageBox.Show(start+end);
        }

        private void comboBoxEditTenNK_Enter(object sender, EventArgs e)
        {
            comboBoxEditTenNK_EditValueChanged(sender, e);
        }

        private void gridHH_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = cmdTime;
            if (gridHH.Text != null)
            {
                temp += " and HHTen=N'" + gridHH.Text + "'";
            }
            else temp = cmdTime;
            chartNK.DataSource = con.GetDataTable(temp);


        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = Convert.ToDateTime(end);

            if (dateState == "tuan")
            {
                temp = temp.AddDays(7);
            }
            if (dateState == "thang")
            {
                temp = temp.AddMonths(1);

            }

            if (dateState == "quy")
            {
                temp = temp.AddMonths(3);
            }

            end = string.Format("{0:yyyy/MM/dd}", temp);
            cmdTime = "select HHTen,NKSL,NKNgay from tblNhapKho as a join tblHangHoa as b on a.HHMa=b.HHMa where NKNgay>= '" + start + "' and NKNgay<= '" + end + "'";
            chartNK.DataSource = con.GetDataTable(cmdTime);
            //MessageBox.Show(start+end);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            DateTime temp = Convert.ToDateTime(start);

            if (dateState == "tuan")
            {
                temp = temp.AddDays(-7);

            }
            if (dateState == "thang")
            {
                temp = temp.AddMonths(-1);

            }

            if (dateState == "quy")
            {
                temp = temp.AddMonths(-3);
            }

            start = string.Format("{0:yyyy/MM/dd}", temp);
            cmdTime = "select HHTen,NKSL,NKNgay from tblNhapKho as a join tblHangHoa as b on a.HHMa=b.HHMa where NKNgay>= '" + start + "' and NKNgay<= '" + end + "'";
            chartNK.DataSource = con.GetDataTable(cmdTime);
            //MessageBox.Show(start+end);
        }

        private void comboxDateXK_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridHHXK.Text = "";

            if (comboxDateXK.SelectedIndex == 0)
            {
                dateState = "tuan";
                btnNowXK.Text = "Tuần Này";
                btnYesterXK.Text = "Tuần Trước";

                btnNowXK_Click(sender, e);
            }
            if (comboxDateXK.SelectedIndex == 1)
            {
                dateState = "thang";
                btnNowXK.Text = "Tháng Này";
                btnYesterXK.Text = "Tháng Trước";

                btnNowXK_Click(sender, e);
            }
            if (comboxDateXK.SelectedIndex == 2)
            {
                dateState = "quy";
                btnNowXK.Text = "Quý Này";
                btnYesterXK.Text = "Quý Trước";

                btnNowXK_Click(sender, e);
            }
        }

        private void gridHHXK_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = cmdTime1;
            if (gridHHXK.Text != null)
            {
                temp += " and HHTen=N'" + gridHH.Text + "'";
            }
            else temp = cmdTime1;
            chartXK.DataSource = con.GetDataTable(temp);
        }

        private void btnNowXK_Click(object sender, EventArgs e)
        {
            //thu 2 tuan nay
            DateTime tempTime = new DateTime();
            tempTime = DateTime.Now.Date;


            if (dateState == "tuan")
            {
                while (tempTime.DayOfWeek != DayOfWeek.Monday) tempTime = tempTime.AddDays(-1);

                start1 = string.Format("{0:yyyy/MM/dd}", tempTime);
                end1 = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(6));

            }
            if (dateState == "thang")
            {
                while (tempTime.Day > 1) tempTime = tempTime.AddDays(-1);

                start1 = string.Format("{0:yyyy/MM/dd}", tempTime);
                end1 = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(DateTime.DaysInMonth(tempTime.Year, tempTime.Month) - 1));

            }

            if (dateState == "quy")
            {
                if (tempTime.Month < 4)
                {
                    start1 = tempTime.Year + "/1/1";
                    end1 = tempTime.Year + "/3/31";
                }
                if (tempTime.Month >= 4 && tempTime.Month < 7)
                {
                    start1 = tempTime.Year + "/4/1";
                    end1 = tempTime.Year + "/6/30";
                }
                if (tempTime.Month >= 7 && tempTime.Month < 10)
                {
                    start1 = tempTime.Year + "/7/1";
                    end1 = tempTime.Year + "/9/30";
                }
                if (tempTime.Month >= 10 && tempTime.Month < 13)
                {
                    start1 = tempTime.Year + "/10/1";
                    end1 = tempTime.Year + "/12/31";
                }
            }

            cmdTime1 = "select HHTen,XKSL,XKNgay from tblXuatKho as a join tblHangHoa as b on a.HHMa=b.HHMa where XKNgay>= '" + start1 + "' and XKNgay<= '" + end1 + "'";
            chartXK.DataSource = con.GetDataTable(cmdTime1);

            //MessageBox.Show(start+end);
        }

        private void btnYesterXK_Click(object sender, EventArgs e)
        {
            //thu 2 tuan truoc
            DateTime tempTime = new DateTime();
            tempTime = DateTime.Now.Date;
            tempTime = tempTime.AddDays(-7);

            if (dateState == "tuan")
            {
                while (tempTime.DayOfWeek != DayOfWeek.Monday) tempTime = tempTime.AddDays(-1);

                start1 = string.Format("{0:yyyy/MM/dd}", tempTime);
                end1 = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(6));

            }
            if (dateState == "thang")
            {
                tempTime = tempTime.AddMonths(-1);
                while (tempTime.Day > 1) tempTime = tempTime.AddDays(-1);

                start1 = string.Format("{0:yyyy/MM/dd}", tempTime);
                end1 = string.Format("{0:yyyy/MM/dd}", tempTime.AddDays(DateTime.DaysInMonth(tempTime.Year, tempTime.Month) - 1));

            }

            if (dateState == "quy")
            {
                tempTime = tempTime.AddMonths(-3);
                if (tempTime.Month < 4)
                {
                    start1 = tempTime.Year + "/1/1";
                    end1 = tempTime.Year + "/3/31";
                }
                if (tempTime.Month >= 4 && tempTime.Month < 7)
                {
                    start1 = tempTime.Year + "/4/1";
                    end1 = tempTime.Year + "/6/30";
                }
                if (tempTime.Month >= 7 && tempTime.Month < 10)
                {
                    start1 = tempTime.Year + "/7/1";
                    end1 = tempTime.Year + "/9/30";
                }
                if (tempTime.Month >= 10 && tempTime.Month < 13)
                {
                    start1 = tempTime.Year + "/10/1";
                    end1 = tempTime.Year + "/12/31";
                }
            }

            cmdTime1 = "select HHTen,XKSL,xKNgay from tblXuatKho as a join tblHangHoa as b on a.HHMa=b.HHMa where XKNgay>= '" + start1 + "' and XKNgay<= '" + end1 + "'";
            chartXK.DataSource = con.GetDataTable(cmdTime1);

            //MessageBox.Show(start+end);
        }

        private void btnRightXK_Click(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = Convert.ToDateTime(end1);

            if (dateState == "tuan")
            {
                temp = temp.AddDays(7);
            }
            if (dateState == "thang")
            {
                temp = temp.AddMonths(1);

            }

            if (dateState == "quy")
            {
                temp = temp.AddMonths(3);
            }

            end1 = string.Format("{0:yyyy/MM/dd}", temp);
            cmdTime1 = "select HHTen,XKSL,XKNgay from tblXuatKho as a join tblHangHoa as b on a.HHMa=b.HHMa where XKNgay>= '" + start1 + "' and XKNgay<= '" + end1 + "'";
            chartXK.DataSource = con.GetDataTable(cmdTime1);
            //MessageBox.Show(start+end);
        }

        private void btnLeftXK_Click(object sender, EventArgs e)
        {
            DateTime temp = Convert.ToDateTime(start1);

            if (dateState == "tuan")
            {
                temp = temp.AddDays(-7);

            }
            if (dateState == "thang")
            {
                temp = temp.AddMonths(-1);

            }

            if (dateState == "quy")
            {
                temp = temp.AddMonths(-3);
            }

            start1 = string.Format("{0:yyyy/MM/dd}", temp);
            cmdTime1 = "select HHTen,XKSL,XKNgay from tblXuatKho as a join tblHangHoa as b on a.HHMa=b.HHMa where XKNgay>= '" + start1 + "' and XKNgay<= '" + end1 + "'";
            chartXK.DataSource = con.GetDataTable(cmdTime1);
            //MessageBox.Show(start+end);
        }

        private void navBarGroup6_ItemChanged(object sender, EventArgs e)
        {
            stateQL = "NK";
        }

        private void navBarGroup7_ItemChanged(object sender, EventArgs e)
        {
            stateQL = "XK";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBP.Text != "")
            {
                DataTable temp = con.GetDataTable("select * from tblBoPhan" + " where BPMa='" + comboBP.Text + "'");
                gridControlBoPhan.DataSource = temp;
            }

        }

        private void MBP_Click(object sender, EventArgs e)
        {
            gridView11.SetRowCellValue(gridView11.FocusedRowHandle, "BPMa", con.GetValue("select BPMa from tblBoPhan where BPTen=N'" + comboBP.Text + "'", 0));

            //MessageBox.Show(con.GetValue("select BPMa from tblBoPhan where BPTen=N'" + comboBP.Text + "'",0));
        }

        private void NVMa_Leave(object sender, EventArgs e)
        {
            gridView11.SetRowCellValue(gridView11.FocusedRowHandle, "BPMa", con.GetValue("select BPMa from tblBoPhan where BPTen=N'" + comboBP.Text + "'", 0));

        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.xls", gridControlNhanVien);
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            ExportToExcel temp = new ExportToExcel();
            temp.exportFile("*.pdf", gridControlNhanVien);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //nhat ki
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Nhật Kí HT',N'Xem','" +
               string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");


            AddXtraTab(xtraTPNhatKi);

            gridControlNhatKi.DataSource = con.GetDataTable("select * from tblNhatKi");


        }

        private void barBtnThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Thông Tin',N'Xem','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");
        }

        private void btnXoaNhatKi_Click(object sender, EventArgs e)
        {
            con.ThucThiCauLenhSQL("delete from tblNhatKi");

            DateTime currentTime = DateTime.Now;
            con.ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'Nhật Kí HT',N'Xóa','" +
                string.Format("{0:yyyy/MM/dd HH:mm:ss}", currentTime) + "',N'" + lbNameUser.Text + "')");

            gridControlNhatKi.DataSource = ("select * from tblNhatKi");
        }

        private void xtraTPNhapKho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
