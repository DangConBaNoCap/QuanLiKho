using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class Kho
	{

	#region Constructor
	public Kho()
	{}
	#endregion

	#region Private Variables
	private char _KMa;
	private string _KTen;
	private string _KNguoiLienHe;
	private string _KDiaChi;
	private char _KDienThoai;
	private string _KNguoiQuanLi;
	private string _KGhiChu;
	Kho  objclstblKho;
	#endregion

	#region Public Properties
	public char KMa
	{ 
		get { return _KMa; }
		set { _KMa = value; }
	}
	public string KTen
	{ 
		get { return _KTen; }
		set { _KTen = value; }
	}
	public string KNguoiLienHe
	{ 
		get { return _KNguoiLienHe; }
		set { _KNguoiLienHe = value; }
	}
	public string KDiaChi
	{ 
		get { return _KDiaChi; }
		set { _KDiaChi = value; }
	}
	public char KDienThoai
	{ 
		get { return _KDienThoai; }
		set { _KDienThoai = value; }
	}
	public string KNguoiQuanLi
	{ 
		get { return _KNguoiQuanLi; }
		set { _KNguoiQuanLi = value; }
	}
	public string KGhiChu
	{ 
		get { return _KGhiChu; }
		set { _KGhiChu = value; }
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
				new SqlParameter("@KMa",SqlDbType.Char),
				new SqlParameter("@KTen",SqlDbType.NVarChar),
				new SqlParameter("@KNguoiLienHe",SqlDbType.NVarChar),
				new SqlParameter("@KDiaChi",SqlDbType.NVarChar),
				new SqlParameter("@KDienThoai",SqlDbType.Char),
				new SqlParameter("@KNguoiQuanLi",SqlDbType.NVarChar),
				new SqlParameter("@KGhiChu",SqlDbType.NVarChar) 
			};
			

				if (KMa != null)
				{
					Params[0].Value = KMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (KTen != null)
				{
					Params[1].Value = KTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (KNguoiLienHe != null)
				{
					Params[2].Value = KNguoiLienHe;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

				if (KDiaChi != null)
				{
					Params[3].Value = KDiaChi;
				}
				else
				{
					Params[3].Value = DBNull.Value;
				}

				if (KDienThoai != null)
				{
					Params[4].Value = KDienThoai;
				}
				else
				{
					Params[4].Value = DBNull.Value;
				}

				if (KNguoiQuanLi != null)
				{
					Params[5].Value = KNguoiQuanLi;
				}
				else
				{
					Params[5].Value = DBNull.Value;
				}

				if (KGhiChu != null)
				{
					Params[6].Value = KGhiChu;
				}
				else
				{
					Params[6].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblKho_Select",Params);
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
				new SqlParameter("@KTen",KTen),
				new SqlParameter("@KNguoiLienHe",KNguoiLienHe),
				new SqlParameter("@KDiaChi",KDiaChi),
				new SqlParameter("@KDienThoai",KDienThoai),
				new SqlParameter("@KNguoiQuanLi",KNguoiQuanLi),
				new SqlParameter("@KGhiChu",KGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblKho_Insert",Params);
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
				new SqlParameter("@KMa",KMa),
				new SqlParameter("@KTen",KTen),
				new SqlParameter("@KNguoiLienHe",KNguoiLienHe),
				new SqlParameter("@KDiaChi",KDiaChi),
				new SqlParameter("@KDienThoai",KDienThoai),
				new SqlParameter("@KNguoiQuanLi",KNguoiQuanLi),
				new SqlParameter("@KGhiChu",KGhiChu) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblKho_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@KMa",KMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblKho_Delete",Params);
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
