using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class HangHoaController
	{

	#region Constructor
	public HangHoaController()
	{}
	#endregion

	#region Private Variables
	private char _HHMa;
	private string _HHTen;
	private decimal _HHGia;
	private char _DVMa;
	private char _KMa;
	private char _NPPMa;
	private int _HHTonHienTai;
	private char _NMa;
	HangHoa  objclstblHangHoa;
	#endregion

	#region Public Properties
	public char HHMa
	{ 
		get { return _HHMa; }
		set { _HHMa = value; }
	}
	public string HHTen
	{ 
		get { return _HHTen; }
		set { _HHTen = value; }
	}
	public decimal HHGia
	{ 
		get { return _HHGia; }
		set { _HHGia = value; }
	}
	public char DVMa
	{ 
		get { return _DVMa; }
		set { _DVMa = value; }
	}
	public char KMa
	{ 
		get { return _KMa; }
		set { _KMa = value; }
	}
	public char NPPMa
	{ 
		get { return _NPPMa; }
		set { _NPPMa = value; }
	}
	public int HHTonHienTai
	{ 
		get { return _HHTonHienTai; }
		set { _HHTonHienTai = value; }
	}
	public char NMa
	{ 
		get { return _NMa; }
		set { _NMa = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblHangHoa = new HangHoa();
			
			objclstblHangHoa.HHMa = HHMa;
		
			dt = objclstblHangHoa.Select();
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
			objclstblHangHoa = new HangHoa();
			
			objclstblHangHoa.HHTen = HHTen;
			objclstblHangHoa.HHGia = HHGia;
			objclstblHangHoa.DVMa = DVMa;
			objclstblHangHoa.KMa = KMa;
			objclstblHangHoa.NPPMa = NPPMa;
			objclstblHangHoa.HHTonHienTai = HHTonHienTai;
			objclstblHangHoa.NMa = NMa;
		
			if(objclstblHangHoa.Insert())
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
			objclstblHangHoa = new HangHoa();
			
			objclstblHangHoa.HHMa = HHMa;
			objclstblHangHoa.HHTen = HHTen;
			objclstblHangHoa.HHGia = HHGia;
			objclstblHangHoa.DVMa = DVMa;
			objclstblHangHoa.KMa = KMa;
			objclstblHangHoa.NPPMa = NPPMa;
			objclstblHangHoa.HHTonHienTai = HHTonHienTai;
			objclstblHangHoa.NMa = NMa;
		
			if(objclstblHangHoa.Update())
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
			objclstblHangHoa = new HangHoa();
			
			objclstblHangHoa.HHMa = HHMa;
		
			if(objclstblHangHoa.Delete())
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
