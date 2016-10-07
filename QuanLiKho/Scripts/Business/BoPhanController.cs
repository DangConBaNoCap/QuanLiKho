using System;
using System.Data;

namespace QuanLiKho
{
    public class BoPhanController
    {
        #region Constructor

        public BoPhanController()
        { }

        #endregion Constructor

        #region Private Variables

        private int _BPMa;
        private string _BPTen;
        private string _BPGhiChu;
        private BoPhan objclstblBoPhan;

        #endregion Private Variables

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

        #endregion Public Properties

        #region Public Methods

        public DataTable Select()
        {
            DataTable dt;
            try
            {
                objclstblBoPhan = new BoPhan();

                objclstblBoPhan.BPMa = BPMa;

                dt = objclstblBoPhan.Select();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Insert()
        {
            try
            {
                objclstblBoPhan = new BoPhan();

                objclstblBoPhan.BPTen = BPTen;
                objclstblBoPhan.BPGhiChu = BPGhiChu;

                if (objclstblBoPhan.Insert())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update()
        {
            try
            {
                objclstblBoPhan = new BoPhan();

                objclstblBoPhan.BPMa = BPMa;
                objclstblBoPhan.BPTen = BPTen;
                objclstblBoPhan.BPGhiChu = BPGhiChu;

                if (objclstblBoPhan.Update())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete()
        {
            try
            {
                objclstblBoPhan = new BoPhan();

                objclstblBoPhan.BPMa = BPMa;

                if (objclstblBoPhan.Delete())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion Public Methods
    }
}