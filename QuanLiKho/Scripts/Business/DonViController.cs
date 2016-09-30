using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class DonViController
	{

	#region Constructor
	public DonViController()
	{}
	#endregion

	#region Private Variables
	private char _DVMa;
	private string _DVTen;
	private string _DVGhiChu;
	DonVi  objclstblDonVi;
	#endregion

	#region Public Properties
	public char DVMa
	{ 
		get { return _DVMa; }
		set { _DVMa = value; }
	}
	public string DVTen
	{ 
		get { return _DVTen; }
		set { _DVTen = value; }
	}
	public string DVGhiChu
	{ 
		get { return _DVGhiChu; }
		set { _DVGhiChu = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblDonVi = new DonVi();
			
			objclstblDonVi.DVMa = DVMa;
		
			dt = objclstblDonVi.Select();
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
			objclstblDonVi = new DonVi();
			
			objclstblDonVi.DVTen = DVTen;
			objclstblDonVi.DVGhiChu = DVGhiChu;
		
			if(objclstblDonVi.Insert())
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
			objclstblDonVi = new DonVi();
			
			objclstblDonVi.DVMa = DVMa;
			objclstblDonVi.DVTen = DVTen;
			objclstblDonVi.DVGhiChu = DVGhiChu;
		
			if(objclstblDonVi.Update())
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
			objclstblDonVi = new DonVi();
			
			objclstblDonVi.DVMa = DVMa;
		
			if(objclstblDonVi.Delete())
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
