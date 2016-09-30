using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class NPP
	{

	#region Constructor
	public NPP()
	{}
	#endregion

	#region Private Variables
	private char _NPPMa;
	private string _NPPTen;
	private string _NPPDiaChi;
	private string _NPPMaSoThue;
	private string _NPPDienThoai;
	private string _NPPGhiChu;
	NPP  objclstblNPP;
	#endregion

	#region Public Properties
	public char NPPMa
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
	string ConnectionString=@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiKho;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=QuanLiKho";
	public DataTable Select()
	{
		DataSet ds;
		try
		{
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@NPPMa",SqlDbType.Char),
				new SqlParameter("@NPPTen",SqlDbType.NVarChar),
				new SqlParameter("@NPPDiaChi",SqlDbType.NVarChar),
				new SqlParameter("@NPPMaSoThue",SqlDbType.NChar),
				new SqlParameter("@NPPDienThoai",SqlDbType.NChar),
				new SqlParameter("@NPPGhiChu",SqlDbType.NVarChar) 
			};
			

				if (NPPMa != null)
				{
					Params[0].Value = NPPMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (NPPTen != null)
				{
					Params[1].Value = NPPTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (NPPDiaChi != null)
				{
					Params[2].Value = NPPDiaChi;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

				if (NPPMaSoThue != null)
				{
					Params[3].Value = NPPMaSoThue;
				}
				else
				{
					Params[3].Value = DBNull.Value;
				}

				if (NPPDienThoai != null)
				{
					Params[4].Value = NPPDienThoai;
				}
				else
				{
					Params[4].Value = DBNull.Value;
				}

				if (NPPGhiChu != null)
				{
					Params[5].Value = NPPGhiChu;
				}
				else
				{
					Params[5].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblNPP_Select",Params);
			return ds.Tables[0];
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
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@NPPTen",NPPTen),
				new SqlParameter("@NPPDiaChi",NPPDiaChi),
				new SqlParameter("@NPPMaSoThue",NPPMaSoThue),
				new SqlParameter("@NPPDienThoai",NPPDienThoai),
				new SqlParameter("@NPPGhiChu",NPPGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNPP_Insert",Params);
			if (result > 0)
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
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@NPPMa",NPPMa),
				new SqlParameter("@NPPTen",NPPTen),
				new SqlParameter("@NPPDiaChi",NPPDiaChi),
				new SqlParameter("@NPPMaSoThue",NPPMaSoThue),
				new SqlParameter("@NPPDienThoai",NPPDienThoai),
				new SqlParameter("@NPPGhiChu",NPPGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNPP_Update",Params);
			if (result > 0)
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
			SqlParameter[] Params = { new SqlParameter("@NPPMa",NPPMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNPP_Delete",Params);
			if (result > 0)
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
