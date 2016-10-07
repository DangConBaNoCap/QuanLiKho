using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace QuanLiKho
{
	public class NhapKho
	{

	#region Constructor
	public NhapKho()
	{}
	#endregion

	#region Private Variables
	private int _NKMa;
	private int _HHMa;
	private char _KMa;
	private char _DVMa;
	private System.DateTime _NKNgay;
	private int _NKSL;
	private decimal _NKGia;
	private decimal _NKThanhTien;
	private int _NPPMa;
	NhapKho  objclstblNhapKho;
	#endregion

	#region Public Properties
	public int NKMa
	{ 
		get { return _NKMa; }
		set { _NKMa = value; }
	}
	public int HHMa
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
	public System.DateTime NKNgay
	{ 
		get { return _NKNgay; }
		set { _NKNgay = value; }
	}
	public int NKSL
	{ 
		get { return _NKSL; }
		set { _NKSL = value; }
	}
	public decimal NKGia
	{ 
		get { return _NKGia; }
		set { _NKGia = value; }
	}
	public decimal NKThanhTien
	{ 
		get { return _NKThanhTien; }
		set { _NKThanhTien = value; }
	}
	public int NPPMa
	{ 
		get { return _NPPMa; }
		set { _NPPMa = value; }
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
				new SqlParameter("@NKMa",SqlDbType.Int),
				new SqlParameter("@HHMa",SqlDbType.Int),
				new SqlParameter("@KMa",SqlDbType.Char),
				new SqlParameter("@DVMa",SqlDbType.Char),
				new SqlParameter("@NKNgay",SqlDbType.DateTime),
				new SqlParameter("@NKSL",SqlDbType.Int),
				new SqlParameter("@NKGia",SqlDbType.Money),
				new SqlParameter("@NKThanhTien",SqlDbType.Money),
				new SqlParameter("@NPPMa",SqlDbType.Int) 
			};
			

				if (NKMa != null)
				{
					Params[0].Value = NKMa;
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

				if (NKNgay != null)
				{
					Params[4].Value = NKNgay;
				}
				else
				{
					Params[4].Value = DBNull.Value;
				}

				if (NKSL != null)
				{
					Params[5].Value = NKSL;
				}
				else
				{
					Params[5].Value = DBNull.Value;
				}

				if (NKGia != null)
				{
					Params[6].Value = NKGia;
				}
				else
				{
					Params[6].Value = DBNull.Value;
				}

				if (NKThanhTien != null)
				{
					Params[7].Value = NKThanhTien;
				}
				else
				{
					Params[7].Value = DBNull.Value;
				}

				if (NPPMa != null)
				{
					Params[8].Value = NPPMa;
				}
				else
				{
					Params[8].Value = DBNull.Value;
				}

			
			ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure,"SP_tblNhapKho_Select",Params);
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
				new SqlParameter("@NKNgay",NKNgay),
				new SqlParameter("@NKSL",NKSL),
				new SqlParameter("@NKGia",NKGia),
				new SqlParameter("@NKThanhTien",NKThanhTien),
				new SqlParameter("@NPPMa",NPPMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhapKho_Insert",Params);
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
				new SqlParameter("@NKMa",NKMa),
				new SqlParameter("@HHMa",HHMa),
				new SqlParameter("@KMa",KMa),
				new SqlParameter("@DVMa",DVMa),
				new SqlParameter("@NKNgay",NKNgay),
				new SqlParameter("@NKSL",NKSL),
				new SqlParameter("@NKGia",NKGia),
				new SqlParameter("@NKThanhTien",NKThanhTien),
				new SqlParameter("@NPPMa",NPPMa) 
			};
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhapKho_Update",Params);
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
			SqlParameter[] Params = { new SqlParameter("@NKMa",NKMa) };
			int result = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure,"SP_tblNhapKho_Delete",Params);
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
