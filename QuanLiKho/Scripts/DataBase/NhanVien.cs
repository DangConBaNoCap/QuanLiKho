using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class NhanVien
	{

	#region Constructor
	public NhanVien()
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
	string ConnectionString=@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiKho;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=QuanLiKho";

	public DataTable Select()
	{
		DataSet ds;
		try
		{
			SqlParameter[] Params = 
			{ 
				new SqlParameter("@NVMa",SqlDbType.Char),
				new SqlParameter("@NVTen",SqlDbType.NVarChar),
				new SqlParameter("@NVGhiChu",SqlDbType.NVarChar),
				new SqlParameter("@BPMa",SqlDbType.Char) 
			};
			

				if (NVMa != null)
				{
					Params[0].Value = NVMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (NVTen != null)
				{
					Params[1].Value = NVTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (NVGhiChu != null)
				{
					Params[2].Value = NVGhiChu;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

				if (BPMa != null)
				{
					Params[3].Value = BPMa;
				}
				else
				{
					Params[3].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblNhanVien_Select",Params);
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
				new SqlParameter("@NVTen",NVTen),
				new SqlParameter("@NVGhiChu",NVGhiChu),
				new SqlParameter("@BPMa",BPMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhanVien_Insert",Params);
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
				new SqlParameter("@NVMa",NVMa),
				new SqlParameter("@NVTen",NVTen),
				new SqlParameter("@NVGhiChu",NVGhiChu),
				new SqlParameter("@BPMa",BPMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhanVien_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@NVMa",NVMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhanVien_Delete",Params);
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
