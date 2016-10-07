using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class BoPhan
	{

	#region Constructor
	public BoPhan()
	{}
	#endregion

	#region Private Variables
	private int _BPMa;
	private string _BPTen;
	private string _BPGhiChu;
	BoPhan  objclstblBoPhan;
	#endregion

	#region Public Properties
	public int BPMa
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
	//string ConnectionString=@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiKho;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=QuanLiKho";
	string ConnectionString=QuanLiKho.Properties.Settings.Default.ConnectionString.ToString();
	public DataTable Select()
	{
		DataSet ds;
		try
		{
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@BPMa",SqlDbType.Int),
				new SqlParameter("@BPTen",SqlDbType.NVarChar),
				new SqlParameter("@BPGhiChu",SqlDbType.NVarChar) 
			};
			

				if (BPMa != null)
				{
					Params[0].Value = BPMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (BPTen != null)
				{
					Params[1].Value = BPTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (BPGhiChu != null)
				{
					Params[2].Value = BPGhiChu;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblBoPhan_Select",Params);
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
				new SqlParameter("@BPTen",BPTen),
				new SqlParameter("@BPGhiChu",BPGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblBoPhan_Insert",Params);
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
				new SqlParameter("@BPMa",BPMa),
				new SqlParameter("@BPTen",BPTen),
				new SqlParameter("@BPGhiChu",BPGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblBoPhan_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@BPMa",BPMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblBoPhan_Delete",Params);
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
