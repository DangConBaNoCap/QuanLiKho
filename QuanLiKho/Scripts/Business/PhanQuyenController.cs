using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class PhanQuyenController
	{

	#region Constructor
	public PhanQuyenController()
	{}
	#endregion

	#region Private Variables
	private char _Username;
	private char _Password;
	private char _NVMa;
	PhanQuyen  objclstblPhanQuyen;
	#endregion

	#region Public Properties
	public char Username
	{ 
		get { return _Username; }
		set { _Username = value; }
	}
	public char Password
	{ 
		get { return _Password; }
		set { _Password = value; }
	}
	public char NVMa
	{ 
		get { return _NVMa; }
		set { _NVMa = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblPhanQuyen = new PhanQuyen();
			
			objclstblPhanQuyen.Username = Username;
		
			dt = objclstblPhanQuyen.Select();
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
			objclstblPhanQuyen = new PhanQuyen();
			
			objclstblPhanQuyen.Password = Password;
			objclstblPhanQuyen.NVMa = NVMa;
		
			if(objclstblPhanQuyen.Insert())
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
			objclstblPhanQuyen = new PhanQuyen();
			
			objclstblPhanQuyen.Username = Username;
			objclstblPhanQuyen.Password = Password;
			objclstblPhanQuyen.NVMa = NVMa;
		
			if(objclstblPhanQuyen.Update())
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
			objclstblPhanQuyen = new PhanQuyen();
			
			objclstblPhanQuyen.Username = Username;
		
			if(objclstblPhanQuyen.Delete())
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
