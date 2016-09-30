using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class HangHoa
	{

	#region Constructor
	public HangHoa()
	{}
	#endregion

	#region Private Variables
	private char _HHMa;
	private string _HHTen;
	private decimal _HHGia;
	private char _DVMa;
	private char _KMa;
	private char _NPPMa;
	private int _HHTonHienTai;
	private char _NMa;
	HangHoa  objclstblHangHoa;
	#endregion

	#region Public Properties
	public char HHMa
	{ 
		get { return _HHMa; }
		set { _HHMa = value; }
	}
	public string HHTen
	{ 
		get { return _HHTen; }
		set { _HHTen = value; }
	}
	public decimal HHGia
	{ 
		get { return _HHGia; }
		set { _HHGia = value; }
	}
	public char DVMa
	{ 
		get { return _DVMa; }
		set { _DVMa = value; }
	}
	public char KMa
	{ 
		get { return _KMa; }
		set { _KMa = value; }
	}
	public char NPPMa
	{ 
		get { return _NPPMa; }
		set { _NPPMa = value; }
	}
	public int HHTonHienTai
	{ 
		get { return _HHTonHienTai; }
		set { _HHTonHienTai = value; }
	}
	public char NMa
	{ 
		get { return _NMa; }
		set { _NMa = value; }
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
				new SqlParameter("@HHMa",SqlDbType.Char),
				new SqlParameter("@HHTen",SqlDbType.NVarChar),
				new SqlParameter("@HHGia",SqlDbType.Money),
				new SqlParameter("@DVMa",SqlDbType.Char),
				new SqlParameter("@KMa",SqlDbType.Char),
				new SqlParameter("@NPPMa",SqlDbType.Char),
				new SqlParameter("@HHTonHienTai",SqlDbType.Int),
				new SqlParameter("@NMa",SqlDbType.Char) 
			};
			

				if (HHMa != null)
				{
					Params[0].Value = HHMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (HHTen != null)
				{
					Params[1].Value = HHTen;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (HHGia != null)
				{
					Params[2].Value = HHGia;
				}
				else
				{
					Params[2].Value = DBNull.Value;
				}

				if (DVMa != null)
				{
					Params[3].Value = DVMa;
				}
				else
				{
					Params[3].Value = DBNull.Value;
				}

				if (KMa != null)
				{
					Params[4].Value = KMa;
				}
				else
				{
					Params[4].Value = DBNull.Value;
				}

				if (NPPMa != null)
				{
					Params[5].Value = NPPMa;
				}
				else
				{
					Params[5].Value = DBNull.Value;
				}

				if (HHTonHienTai != null)
				{
					Params[6].Value = HHTonHienTai;
				}
				else
				{
					Params[6].Value = DBNull.Value;
				}

				if (NMa != null)
				{
					Params[7].Value = NMa;
				}
				else
				{
					Params[7].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblHangHoa_Select",Params);
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
				new SqlParameter("@HHTen",HHTen),
				new SqlParameter("@HHGia",HHGia),
				new SqlParameter("@DVMa",DVMa),
				new SqlParameter("@KMa",KMa),
				new SqlParameter("@NPPMa",NPPMa),
				new SqlParameter("@HHTonHienTai",HHTonHienTai),
				new SqlParameter("@NMa",NMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblHangHoa_Insert",Params);
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
				new SqlParameter("@HHMa",HHMa),
				new SqlParameter("@HHTen",HHTen),
				new SqlParameter("@HHGia",HHGia),
				new SqlParameter("@DVMa",DVMa),
				new SqlParameter("@KMa",KMa),
				new SqlParameter("@NPPMa",NPPMa),
				new SqlParameter("@HHTonHienTai",HHTonHienTai),
				new SqlParameter("@NMa",NMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblHangHoa_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@HHMa",HHMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblHangHoa_Delete",Params);
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
