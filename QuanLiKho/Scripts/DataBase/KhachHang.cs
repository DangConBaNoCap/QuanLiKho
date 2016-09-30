using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class KhachHang
	{

	#region Constructor
	public KhachHang()
	{}
	#endregion

	#region Private Variables
	private char _KHMa;
	private string _KHTen;
	private string _KHDiaChi;
	private char _KHMaSoThue;
	private char _KHDienThoai;
	private string _KHGhiChu;
	KhachHang  objclstblKhachHang;
	#endregion

	#region Public Properties
	public char KHMa
	{ 
		get { return _KHMa; }
		set { _KHMa = value; }
	}
	public string KHTen
	{ 
		get { return _KHTen; }
		set { _KHTen = value; }
	}
	public string KHDiaChi
	{ 
		get { return _KHDiaChi; }
		set { _KHDiaChi = value; }
	}
	public char KHMaSoThue
	{ 
		get { return _KHMaSoThue; }
		set { _KHMaSoThue = value; }
	}
	public char KHDienThoai
	{ 
		get { return _KHDienThoai; }
		set { _KHDienThoai = value; }
	}
	public string KHGhiChu
	{ 
		get { return _KHGhiChu; }
		set { _KHGhiChu = value; }
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
				new SqlParameter("@KHMa",SqlDbType.Char),
				new SqlParameter("@KHTen",SqlDbType.NVarChar),
				new SqlParameter("@KHDiaChi",SqlDbType.NVarChar),
				new SqlParameter("@KHMaSoThue",SqlDbType.Char),
				new SqlParameter("@KHDienThoai",SqlDbType.Char),
				new SqlParameter("@KHGhiChu",SqlDbType.NVarChar) 
			};
			

				if (KHMa != null)
				{
					Params[0].Value = KHMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (KHTen != null)
				{
					Params[1].Value = KHTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (KHDiaChi != null)
				{
					Params[2].Value = KHDiaChi;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

				if (KHMaSoThue != null)
				{
					Params[3].Value = KHMaSoThue;
				}
				else
				{
					Params[3].Value = DBNull.Value;
				}

				if (KHDienThoai != null)
				{
					Params[4].Value = KHDienThoai;
				}
				else
				{
					Params[4].Value = DBNull.Value;
				}

				if (KHGhiChu != null)
				{
					Params[5].Value = KHGhiChu;
				}
				else
				{
					Params[5].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblKhachHang_Select",Params);
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
				new SqlParameter("@KHTen",KHTen),
				new SqlParameter("@KHDiaChi",KHDiaChi),
				new SqlParameter("@KHMaSoThue",KHMaSoThue),
				new SqlParameter("@KHDienThoai",KHDienThoai),
				new SqlParameter("@KHGhiChu",KHGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblKhachHang_Insert",Params);
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
				new SqlParameter("@KHMa",KHMa),
				new SqlParameter("@KHTen",KHTen),
				new SqlParameter("@KHDiaChi",KHDiaChi),
				new SqlParameter("@KHMaSoThue",KHMaSoThue),
				new SqlParameter("@KHDienThoai",KHDienThoai),
				new SqlParameter("@KHGhiChu",KHGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblKhachHang_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@KHMa",KHMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblKhachHang_Delete",Params);
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
