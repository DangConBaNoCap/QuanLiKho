using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class DonVi
	{

	#region Constructor
	public DonVi()
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
	string ConnectionString=@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiKho;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=QuanLiKho";
	public DataTable Select()
	{
		DataSet ds;
		try
		{
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@DVMa",SqlDbType.Char),
				new SqlParameter("@DVTen",SqlDbType.NVarChar),
				new SqlParameter("@DVGhiChu",SqlDbType.NVarChar) 
			};
			

				if (DVMa != null)
				{
					Params[0].Value = DVMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (DVTen != null)
				{
					Params[1].Value = DVTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (DVGhiChu != null)
				{
					Params[2].Value = DVGhiChu;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblDonVi_Select",Params);
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
				new SqlParameter("@DVTen",DVTen),
				new SqlParameter("@DVGhiChu",DVGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblDonVi_Insert",Params);
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
				new SqlParameter("@DVMa",DVMa),
				new SqlParameter("@DVTen",DVTen),
				new SqlParameter("@DVGhiChu",DVGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblDonVi_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@DVMa",DVMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblDonVi_Delete",Params);
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
