using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class NPPController
	{

	#region Constructor
	public NPPController()
	{}
	#endregion

	#region Private Variables
	private int _NPPMa;
	private string _NPPTen;
	private string _NPPDiaChi;
	private string _NPPMaSoThue;
	private string _NPPDienThoai;
	private string _NPPGhiChu;
	NPP  objclstblNPP;
	#endregion

	#region Public Properties
	public int NPPMa
	{ 
		get { return _NPPMa; }
		set { _NPPMa = value; }
	}
	public string NPPTen
	{ 
		get { return _NPPTen; }
		set { _NPPTen = value; }
	}
	public string NPPDiaChi
	{ 
		get { return _NPPDiaChi; }
		set { _NPPDiaChi = value; }
	}
	public string NPPMaSoThue
	{ 
		get { return _NPPMaSoThue; }
		set { _NPPMaSoThue = value; }
	}
	public string NPPDienThoai
	{ 
		get { return _NPPDienThoai; }
		set { _NPPDienThoai = value; }
	}
	public string NPPGhiChu
	{ 
		get { return _NPPGhiChu; }
		set { _NPPGhiChu = value; }
	}
	#endregion

	#region Public Methods
	public DataTable Select()
	{
		DataTable dt;
		try
		{
			objclstblNPP = new NPP();
			
			objclstblNPP.NPPMa = NPPMa;
		
			dt = objclstblNPP.Select();
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
			objclstblNPP = new NPP();
			
			objclstblNPP.NPPTen = NPPTen;
			objclstblNPP.NPPDiaChi = NPPDiaChi;
			objclstblNPP.NPPMaSoThue = NPPMaSoThue;
			objclstblNPP.NPPDienThoai = NPPDienThoai;
			objclstblNPP.NPPGhiChu = NPPGhiChu;
		
			if(objclstblNPP.Insert())
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
			objclstblNPP = new NPP();
			
			objclstblNPP.NPPMa = NPPMa;
			objclstblNPP.NPPTen = NPPTen;
			objclstblNPP.NPPDiaChi = NPPDiaChi;
			objclstblNPP.NPPMaSoThue = NPPMaSoThue;
			objclstblNPP.NPPDienThoai = NPPDienThoai;
			objclstblNPP.NPPGhiChu = NPPGhiChu;
		
			if(objclstblNPP.Update())
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
			objclstblNPP = new NPP();
			
			objclstblNPP.NPPMa = NPPMa;
		
			if(objclstblNPP.Delete())
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
