using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class XuatKhoController
	{

	#region Constructor
	public XuatKhoController()
	{}
	#endregion

	#region Private Variables
	private int _XKMa;
	private int _HHMa;
	private char _KMa;
	private char _DVMa;
	private int _XKSL;
	private decimal _XKGia;
	private int _KHMa;
	private System.DateTime _XKNgay;
	private decimal _XKThanhTien;
	XuatKho  objclstblXuatKho;
	#endregion

	#region Public Properties
	public int XKMa
	{ 
		get { return _XKMa; }
		set { _XKMa = value; }
	}
	public int HHMa
	{ 
		get { return _HHMa; }
		set { _HHMa = value; }
	}
	public char KMa
	{ 
		get { return _KMa; }
		set { _KMa = value; }
	}
	public char DVMa
	{ 
		get { return _DVMa; }
		set { _DVMa = value; }
	}
	public int XKSL
	{ 
		get { return _XKSL; }
		set { _XKSL = value; }
	}
	public decimal XKGia
	{ 
		get { return _XKGia; }
		set { _XKGia = value; }
	}
	public int KHMa
	{ 
		get { return _KHMa; }
		set { _KHMa = value; }
	}
	public System.DateTime XKNgay
	{ 
		get { return _XKNgay; }
		set { _XKNgay = value; }
	}
	public decimal XKThanhTien
	{ 
		get { return _XKThanhTien; }
		set { _XKThanhTien = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblXuatKho = new XuatKho();
			
			objclstblXuatKho.XKMa = XKMa;
		
			dt = objclstblXuatKho.Select();
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
			objclstblXuatKho = new XuatKho();
			
			objclstblXuatKho.HHMa = HHMa;
			objclstblXuatKho.KMa = KMa;
			objclstblXuatKho.DVMa = DVMa;
			objclstblXuatKho.XKSL = XKSL;
			objclstblXuatKho.XKGia = XKGia;
			objclstblXuatKho.KHMa = KHMa;
			objclstblXuatKho.XKNgay = XKNgay;
			objclstblXuatKho.XKThanhTien = XKThanhTien;
		
			if(objclstblXuatKho.Insert())
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
			objclstblXuatKho = new XuatKho();
			
			objclstblXuatKho.XKMa = XKMa;
			objclstblXuatKho.HHMa = HHMa;
			objclstblXuatKho.KMa = KMa;
			objclstblXuatKho.DVMa = DVMa;
			objclstblXuatKho.XKSL = XKSL;
			objclstblXuatKho.XKGia = XKGia;
			objclstblXuatKho.KHMa = KHMa;
			objclstblXuatKho.XKNgay = XKNgay;
			objclstblXuatKho.XKThanhTien = XKThanhTien;
		
			if(objclstblXuatKho.Update())
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
			objclstblXuatKho = new XuatKho();
			
			objclstblXuatKho.XKMa = XKMa;
		
			if(objclstblXuatKho.Delete())
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
