using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class PhanQuyen
	{

	#region Constructor
	public PhanQuyen()
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
	string ConnectionString=@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiKho;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=QuanLiKho";
	public DataTable Select()
	{
		DataSet ds;
		try
		{
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@Username",SqlDbType.Char),
				new SqlParameter("@Password",SqlDbType.Char),
				new SqlParameter("@NVMa",SqlDbType.Char) 
			};
			

				if (Username != null)
				{
					Params[0].Value = Username;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (Password != null)
				{
					Params[1].Value = Password;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (NVMa != null)
				{
					Params[2].Value = NVMa;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblPhanQuyen_Select",Params);
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
				new SqlParameter("@Password",Password),
				new SqlParameter("@NVMa",NVMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblPhanQuyen_Insert",Params);
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
				new SqlParameter("@Username",Username),
				new SqlParameter("@Password",Password),
				new SqlParameter("@NVMa",NVMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblPhanQuyen_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@Username",Username) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblPhanQuyen_Delete",Params);
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
