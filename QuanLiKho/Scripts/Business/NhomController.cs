using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class NhomController
	{

	#region Constructor
	public NhomController()
	{}
	#endregion

	#region Private Variables
	private char _NMa;
	private string _NTen;
	private string _NGhiChu;
	private char _KMa;
	Nhom  objclstblNhom;
	#endregion

	#region Public Properties
	public char NMa
	{ 
		get { return _NMa; }
		set { _NMa = value; }
	}
	public string NTen
	{ 
		get { return _NTen; }
		set { _NTen = value; }
	}
	public string NGhiChu
	{ 
		get { return _NGhiChu; }
		set { _NGhiChu = value; }
	}
	public char KMa
	{ 
		get { return _KMa; }
		set { _KMa = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblNhom = new Nhom();
			
			objclstblNhom.NMa = NMa;
		
			dt = objclstblNhom.Select();
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
			objclstblNhom = new Nhom();
			
			objclstblNhom.NTen = NTen;
			objclstblNhom.NGhiChu = NGhiChu;
			objclstblNhom.KMa = KMa;
		
			if(objclstblNhom.Insert())
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
			objclstblNhom = new Nhom();
			
			objclstblNhom.NMa = NMa;
			objclstblNhom.NTen = NTen;
			objclstblNhom.NGhiChu = NGhiChu;
			objclstblNhom.KMa = KMa;
		
			if(objclstblNhom.Update())
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
			objclstblNhom = new Nhom();
			
			objclstblNhom.NMa = NMa;
		
			if(objclstblNhom.Delete())
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
