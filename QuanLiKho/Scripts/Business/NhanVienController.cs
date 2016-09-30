using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class NhanVienController
	{

	#region Constructor
	public NhanVienController()
	{}
	#endregion

	#region Private Variables
	private char _NVMa;
	private string _NVTen;
	private string _NVGhiChu;
	private char _BPMa;
	NhanVien  objclstblNhanVien;
	#endregion

	#region Public Properties
	public char NVMa
	{ 
		get { return _NVMa; }
		set { _NVMa = value; }
	}
	public string NVTen
	{ 
		get { return _NVTen; }
		set { _NVTen = value; }
	}
	public string NVGhiChu
	{ 
		get { return _NVGhiChu; }
		set { _NVGhiChu = value; }
	}
	public char BPMa
	{ 
		get { return _BPMa; }
		set { _BPMa = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblNhanVien = new NhanVien();
			
			objclstblNhanVien.NVMa = NVMa;
		
			dt = objclstblNhanVien.Select();
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
			objclstblNhanVien = new NhanVien();
			
			objclstblNhanVien.NVTen = NVTen;
			objclstblNhanVien.NVGhiChu = NVGhiChu;
			objclstblNhanVien.BPMa = BPMa;
		
			if(objclstblNhanVien.Insert())
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
			objclstblNhanVien = new NhanVien();
			
			objclstblNhanVien.NVMa = NVMa;
			objclstblNhanVien.NVTen = NVTen;
			objclstblNhanVien.NVGhiChu = NVGhiChu;
			objclstblNhanVien.BPMa = BPMa;
		
			if(objclstblNhanVien.Update())
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
			objclstblNhanVien = new NhanVien();
			
			objclstblNhanVien.NVMa = NVMa;
		
			if(objclstblNhanVien.Delete())
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
