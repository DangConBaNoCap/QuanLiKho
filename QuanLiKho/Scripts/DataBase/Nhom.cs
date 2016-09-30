using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class Nhom
	{

	#region Constructor
	public Nhom()
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
	string ConnectionString=@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiKho;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=QuanLiKho";
	public DataTable Select()
	{
		DataSet ds;
		try
		{
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@NMa",SqlDbType.Char),
				new SqlParameter("@NTen",SqlDbType.NChar),
				new SqlParameter("@NGhiChu",SqlDbType.NVarChar),
				new SqlParameter("@KMa",SqlDbType.Char) 
			};
			

				if (NMa != null)
				{
					Params[0].Value = NMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (NTen != null)
				{
					Params[1].Value = NTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (NGhiChu != null)
				{
					Params[2].Value = NGhiChu;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

				if (KMa != null)
				{
					Params[3].Value = KMa;
				}
				else
				{
					Params[3].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblNhom_Select",Params);
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
				new SqlParameter("@NTen",NTen),
				new SqlParameter("@NGhiChu",NGhiChu),
				new SqlParameter("@KMa",KMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhom_Insert",Params);
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
				new SqlParameter("@NMa",NMa),
				new SqlParameter("@NTen",NTen),
				new SqlParameter("@NGhiChu",NGhiChu),
				new SqlParameter("@KMa",KMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhom_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@NMa",NMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhom_Delete",Params);
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
