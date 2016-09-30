using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class BoPhanController
	{

	#region Constructor
	public BoPhanController()
	{}
	#endregion

	#region Private Variables
	private char _BPMa;
	private string _BPTen;
	private string _BPGhiChu;
	BoPhan  objclstblBoPhan;
	#endregion

	#region Public Properties
	public char BPMa
	{ 
		get { return _BPMa; }
		set { _BPMa = value; }
	}
	public string BPTen
	{ 
		get { return _BPTen; }
		set { _BPTen = value; }
	}
	public string BPGhiChu
	{ 
		get { return _BPGhiChu; }
		set { _BPGhiChu = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblBoPhan = new BoPhan();
			
			objclstblBoPhan.BPMa = BPMa;
		
			dt = objclstblBoPhan.Select();
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
			objclstblBoPhan = new BoPhan();
			
			objclstblBoPhan.BPTen = BPTen;
			objclstblBoPhan.BPGhiChu = BPGhiChu;
		
			if(objclstblBoPhan.Insert())
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
			objclstblBoPhan = new BoPhan();
			
			objclstblBoPhan.BPMa = BPMa;
			objclstblBoPhan.BPTen = BPTen;
			objclstblBoPhan.BPGhiChu = BPGhiChu;
		
			if(objclstblBoPhan.Update())
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
			objclstblBoPhan = new BoPhan();
			
			objclstblBoPhan.BPMa = BPMa;
		
			if(objclstblBoPhan.Delete())
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
