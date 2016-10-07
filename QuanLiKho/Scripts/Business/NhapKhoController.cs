using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class NhapKhoController
	{

	#region Constructor
	public NhapKhoController()
	{}
	#endregion

	#region Private Variables
	private int _NKMa;
	private int _HHMa;
	private char _KMa;
	private char _DVMa;
	private System.DateTime _NKNgay;
	private int _NKSL;
	private decimal _NKGia;
	private decimal _NKThanhTien;
	private int _NPPMa;
	NhapKho  objclstblNhapKho;
	#endregion

	#region Public Properties
	public int NKMa
	{ 
		get { return _NKMa; }
		set { _NKMa = value; }
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
	public System.DateTime NKNgay
	{ 
		get { return _NKNgay; }
		set { _NKNgay = value; }
	}
	public int NKSL
	{ 
		get { return _NKSL; }
		set { _NKSL = value; }
	}
	public decimal NKGia
	{ 
		get { return _NKGia; }
		set { _NKGia = value; }
	}
	public decimal NKThanhTien
	{ 
		get { return _NKThanhTien; }
		set { _NKThanhTien = value; }
	}
	public int NPPMa
	{ 
		get { return _NPPMa; }
		set { _NPPMa = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblNhapKho = new NhapKho();
			
			objclstblNhapKho.NKMa = NKMa;
		
			dt = objclstblNhapKho.Select();
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
			objclstblNhapKho = new NhapKho();
			
			objclstblNhapKho.HHMa = HHMa;
			objclstblNhapKho.KMa = KMa;
			objclstblNhapKho.DVMa = DVMa;
			objclstblNhapKho.NKNgay = NKNgay;
			objclstblNhapKho.NKSL = NKSL;
			objclstblNhapKho.NKGia = NKGia;
			objclstblNhapKho.NKThanhTien = NKThanhTien;
			objclstblNhapKho.NPPMa = NPPMa;
		
			if(objclstblNhapKho.Insert())
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
			objclstblNhapKho = new NhapKho();
			
			objclstblNhapKho.NKMa = NKMa;
			objclstblNhapKho.HHMa = HHMa;
			objclstblNhapKho.KMa = KMa;
			objclstblNhapKho.DVMa = DVMa;
			objclstblNhapKho.NKNgay = NKNgay;
			objclstblNhapKho.NKSL = NKSL;
			objclstblNhapKho.NKGia = NKGia;
			objclstblNhapKho.NKThanhTien = NKThanhTien;
			objclstblNhapKho.NPPMa = NPPMa;
		
			if(objclstblNhapKho.Update())
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
			objclstblNhapKho = new NhapKho();
			
			objclstblNhapKho.NKMa = NKMa;
		
			if(objclstblNhapKho.Delete())
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
