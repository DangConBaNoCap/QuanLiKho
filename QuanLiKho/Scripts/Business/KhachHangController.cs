using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class KhachHangController
	{

	#region Constructor
	public KhachHangController()
	{}
	#endregion

	#region Private Variables
	private char _KHMa;
	private string _KHTen;
	private string _KHDiaChi;
	private char _KHMaSoThue;
	private char _KHDienThoai;
	private string _KHGhiChu;
	KhachHang  objclstblKhachHang;
	#endregion

	#region Public Properties
	public char KHMa
	{ 
		get { return _KHMa; }
		set { _KHMa = value; }
	}
	public string KHTen
	{ 
		get { return _KHTen; }
		set { _KHTen = value; }
	}
	public string KHDiaChi
	{ 
		get { return _KHDiaChi; }
		set { _KHDiaChi = value; }
	}
	public char KHMaSoThue
	{ 
		get { return _KHMaSoThue; }
		set { _KHMaSoThue = value; }
	}
	public char KHDienThoai
	{ 
		get { return _KHDienThoai; }
		set { _KHDienThoai = value; }
	}
	public string KHGhiChu
	{ 
		get { return _KHGhiChu; }
		set { _KHGhiChu = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblKhachHang = new KhachHang();
			
			objclstblKhachHang.KHMa = KHMa;
		
			dt = objclstblKhachHang.Select();
			return dt;
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
	public bool Insert()
	{
		try
		{
			objclstblKhachHang = new KhachHang();
			
			objclstblKhachHang.KHTen = KHTen;
			objclstblKhachHang.KHDiaChi = KHDiaChi;
			objclstblKhachHang.KHMaSoThue = KHMaSoThue;
			objclstblKhachHang.KHDienThoai = KHDienThoai;
			objclstblKhachHang.KHGhiChu = KHGhiChu;
		
			if(objclstblKhachHang.Insert())
			{
				return true;
			}
			return false;
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
	public bool Update()
	{
		try
		{
			objclstblKhachHang = new KhachHang();
			
			objclstblKhachHang.KHMa = KHMa;
			objclstblKhachHang.KHTen = KHTen;
			objclstblKhachHang.KHDiaChi = KHDiaChi;
			objclstblKhachHang.KHMaSoThue = KHMaSoThue;
			objclstblKhachHang.KHDienThoai = KHDienThoai;
			objclstblKhachHang.KHGhiChu = KHGhiChu;
		
			if(objclstblKhachHang.Update())
			{
				return true;
			}
			return false;
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
	public bool Delete()
	{
		try
		{
			objclstblKhachHang = new KhachHang();
			
			objclstblKhachHang.KHMa = KHMa;
		
			if(objclstblKhachHang.Delete())
			{
				return true;
			}
			return false;
		}
		catch(Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
	#endregion

	}
}
