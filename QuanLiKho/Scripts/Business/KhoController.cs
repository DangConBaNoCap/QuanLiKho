using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class KhoController
	{

	#region Constructor
	public KhoController()
	{}
	#endregion

	#region Private Variables
	private char _KMa;
	private string _KTen;
	private string _KNguoiLienHe;
	private string _KDiaChi;
	private char _KDienThoai;
	private string _KNguoiQuanLi;
	private string _KGhiChu;
	Kho  objclstblKho;
	#endregion

	#region Public Properties
	public char KMa
	{ 
		get { return _KMa; }
		set { _KMa = value; }
	}
	public string KTen
	{ 
		get { return _KTen; }
		set { _KTen = value; }
	}
	public string KNguoiLienHe
	{ 
		get { return _KNguoiLienHe; }
		set { _KNguoiLienHe = value; }
	}
	public string KDiaChi
	{ 
		get { return _KDiaChi; }
		set { _KDiaChi = value; }
	}
	public char KDienThoai
	{ 
		get { return _KDienThoai; }
		set { _KDienThoai = value; }
	}
	public string KNguoiQuanLi
	{ 
		get { return _KNguoiQuanLi; }
		set { _KNguoiQuanLi = value; }
	}
	public string KGhiChu
	{ 
		get { return _KGhiChu; }
		set { _KGhiChu = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblKho = new Kho();
			
			objclstblKho.KMa = KMa;
		
			dt = objclstblKho.Select();
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
			objclstblKho = new Kho();
			
			objclstblKho.KTen = KTen;
			objclstblKho.KNguoiLienHe = KNguoiLienHe;
			objclstblKho.KDiaChi = KDiaChi;
			objclstblKho.KDienThoai = KDienThoai;
			objclstblKho.KNguoiQuanLi = KNguoiQuanLi;
			objclstblKho.KGhiChu = KGhiChu;
		
			if(objclstblKho.Insert())
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
			objclstblKho = new Kho();
			
			objclstblKho.KMa = KMa;
			objclstblKho.KTen = KTen;
			objclstblKho.KNguoiLienHe = KNguoiLienHe;
			objclstblKho.KDiaChi = KDiaChi;
			objclstblKho.KDienThoai = KDienThoai;
			objclstblKho.KNguoiQuanLi = KNguoiQuanLi;
			objclstblKho.KGhiChu = KGhiChu;
		
			if(objclstblKho.Update())
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
			objclstblKho = new Kho();
			
			objclstblKho.KMa = KMa;
		
			if(objclstblKho.Delete())
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
