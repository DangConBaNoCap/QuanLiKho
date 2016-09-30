using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class XuatKho
	{

	#region Constructor
	public XuatKho()
	{}
	#endregion

	#region Private Variables
	private char _XKMa;
	private char _HHMa;
	private char _KMa;
	private char _DVMa;
	private int _XKSL;
	private decimal _XKGia;
	private char _KHMa;
	private System.DateTime _XKNgay;
	private decimal _XKThanhTien;
	XuatKho  objclstblXuatKho;
	#endregion

	#region Public Properties
	public char XKMa
	{ 
		get { return _XKMa; }
		set { _XKMa = value; }
	}
	public char HHMa
	{ 
		get { return _HHMa; }
		set { _HHMa = value; }
	}
	public char KMa
	{ 
		get { return _KMa; }
		set { _KMa = value; }
	}
	public char DVMa
	{ 
		get { return _DVMa; }
		set { _DVMa = value; }
	}
	public int XKSL
	{ 
		get { return _XKSL; }
		set { _XKSL = value; }
	}
	public decimal XKGia
	{ 
		get { return _XKGia; }
		set { _XKGia = value; }
	}
	public char KHMa
	{ 
		get { return _KHMa; }
		set { _KHMa = value; }
	}
	public System.DateTime XKNgay
	{ 
		get { return _XKNgay; }
		set { _XKNgay = value; }
	}
	public decimal XKThanhTien
	{ 
		get { return _XKThanhTien; }
		set { _XKThanhTien = value; }
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
				new SqlParameter("@XKMa",SqlDbType.Char),
				new SqlParameter("@HHMa",SqlDbType.Char),
				new SqlParameter("@KMa",SqlDbType.Char),
				new SqlParameter("@DVMa",SqlDbType.Char),
				new SqlParameter("@XKSL",SqlDbType.Int),
				new SqlParameter("@XKGia",SqlDbType.Money),
				new SqlParameter("@KHMa",SqlDbType.Char),
				new SqlParameter("@XKNgay",SqlDbType.System.DateTime.DateTime),
				new SqlParameter("@XKThanhTien",SqlDbType.Money) 
			};
			

				if (XKMa != null)
				{
					Params[0].Value = XKMa;
				}
				else
				{
					Params[0].Value = DBNull.Value;
				}

				if (HHMa != null)
				{
					Params[1].Value = HHMa;
				}
				else
				{
					Params[1].Value = DBNull.Value;
				}

				if (KMa != null)
				{
					Params[2].Value = KMa;
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

				if (XKSL != null)
				{
					Params[4].Value = XKSL;
				}
				else
				{
					Params[4].Value = DBNull.Value;
				}

				if (XKGia != null)
				{
					Params[5].Value = XKGia;
				}
				else
				{
					Params[5].Value = DBNull.Value;
				}

				if (KHMa != null)
				{
					Params[6].Value = KHMa;
				}
				else
				{
					Params[6].Value = DBNull.Value;
				}

				if (XKNgay != null)
				{
					Params[7].Value = XKNgay;
				}
				else
				{
					Params[7].Value = DBNull.Value;
				}

				if (XKThanhTien != null)
				{
					Params[8].Value = XKThanhTien;
				}
				else
				{
					Params[8].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblXuatKho_Select",Params);
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
				new SqlParameter("@HHMa",HHMa),
				new SqlParameter("@KMa",KMa),
				new SqlParameter("@DVMa",DVMa),
				new SqlParameter("@XKSL",XKSL),
				new SqlParameter("@XKGia",XKGia),
				new SqlParameter("@KHMa",KHMa),
				new SqlParameter("@XKNgay",XKNgay),
				new SqlParameter("@XKThanhTien",XKThanhTien) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblXuatKho_Insert",Params);
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
				new SqlParameter("@XKMa",XKMa),
				new SqlParameter("@HHMa",HHMa),
				new SqlParameter("@KMa",KMa),
				new SqlParameter("@DVMa",DVMa),
				new SqlParameter("@XKSL",XKSL),
				new SqlParameter("@XKGia",XKGia),
				new SqlParameter("@KHMa",KHMa),
				new SqlParameter("@XKNgay",XKNgay),
				new SqlParameter("@XKThanhTien",XKThanhTien) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblXuatKho_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@XKMa",XKMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblXuatKho_Delete",Params);
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
