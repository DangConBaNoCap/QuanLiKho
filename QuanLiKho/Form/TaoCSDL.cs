using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Specialized;

namespace QuanLiKho
{
    public partial class TaoCSDL : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string server=@".\SQLEXPRESS";

        private string logFilePath = "|DataDirectory|";
        
        public static SqlConnection connect;

        public TaoCSDL()
        {
            InitializeComponent();

            barButtonItem1.Enabled = false;
            
        }
        public void PutSql(string Name,string value)
        {
            //try
            //{
                

            //    //MessageBox.Show(sInfor);
            //}
            //catch (Exception ex)
            //{
            //    Log(ex.ToString());
            //    throw ex;
            //}

            // Gets the current assembly.
            Assembly Asm = Assembly.GetExecutingAssembly();

            // Resources are named using a fully qualified name.
            Stream strm = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name);

            // write the contents of the embedded file.

            StreamWriter write = new StreamWriter(strm);
            
            write.Write(value);
            //string sInfor = write.;

            write.Close();
            //return sInfor;
        }

        public string GetSql(string Name)
        {
            try
            {
                // Gets the current assembly.
                Assembly Asm = Assembly.GetExecutingAssembly();

                // Resources are named using a fully qualified name.
                Stream strm = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name);

                // Reads the contents of the embedded file.
                StreamReader reader = new StreamReader(strm);
                string sInfor = reader.ReadToEnd();
                //StreamWriter write = new StreamWriter(strm);
                Log(sInfor);
                reader.Close();
                return sInfor;

                //MessageBox.Show(sInfor);
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                throw ex;
            }
        }

        private void ExecuteSql(string serverName, string dbName, string userid, string password, string Sql)
        {
 
            if (TaoCSDL.connect == null)
            {
                try
                {

                    TaoCSDL.connect = new SqlConnection(@"Data Source="+serverName+";Initial Catalog=master;Integrated Security=SSPI;");

                }
                catch
                {

                }
            }

            if (TaoCSDL.connect.State != ConnectionState.Open)
            {
                TaoCSDL.connect.Open();

                SqlCommand sqlcmd = new SqlCommand(Sql, connect);
                sqlcmd.ExecuteNonQuery();
            }

            if (TaoCSDL.connect.State == ConnectionState.Open)
            {
                TaoCSDL.connect.Close();
            }
            
        }
        protected void AddDBTable(string serverName, string userid, string password)
        {
            try
            {
                // Creates the database and installs the tables.
                string strScript = GetSql("sqldropcreate.txt");
                ExecuteSql(serverName, "master", userid, password, strScript);
                System.Threading.Thread.Sleep(5 * 1000);
                string strdb = GetSql("sqldata.txt");
                
                ExecuteSql(serverName, "master", userid, password, strdb);
                System.Threading.Thread.Sleep(10 * 1000);

                MessageBox.Show("Tạo Thành Công", "Thông Báo");
                barButtonItem1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConnec_Click(object sender, EventArgs e)
        {
            TaoCSDL.connect = new SqlConnection(@"Data Source=" + comboServer.Text + ";Initial Catalog=master;Integrated Security=SSPI;");
            try
            {
                connect.Open();
                MessageBox.Show("Kết nối thành công", "Thông Báo");
                barButtonItem1.Enabled = true;
                KetNoiCSDL.server = comboServer.Text.Trim();
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }


        public void Log(string str)
        {
            StreamWriter Tex;
            try
            {
                Tex = File.AppendText(this.logFilePath);
                Tex.WriteLine(DateTime.Now.ToString() + " " + str);
                Tex.Close();
            }
            catch
            { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddDBTable(comboServer.Text, textUser.Text, textPas.Text);
            //MessageBox.Show("Tạo dữ liệu thành công");
            //MessageBox.Show(GetSql("sqldropcreate.txt"));
        }

        private void comboServer_EditValueChanged(object sender, EventArgs e)
        {
            server = comboServer.Text;
            KetNoiCSDL.server = comboServer.Text;
        }

        private void btnSaoLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            //dialog.Multiselect = false;
            dialog.Title = "Lựa chọn thư mục";
            dialog.Filter = "*.bak|*.bak";
            dialog.FileName =DateTime.Now.Day+"-"+DateTime.Now.Month+" "+DateTime.Now.Hour+"h-"+DateTime.Now.Minute +".bak";
            dialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            if (dialog.ShowDialog() == DialogResult.OK||dialog.ShowDialog()==DialogResult.Yes)
            {
                ExecuteSql(comboServer.Text, "master", textUser.Text, textPas.Text, "backup database [KhoHangHoa] to disk=N'" + dialog.FileName + "'");
            }
            else return;
        }

        private void btnPhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Multiselect = false;
            dialog.Title = "Lựa chọn file .bak";
            dialog.Filter = "*.bak|*.bak";
            //dialog.FileName = DateTime.Now.Day + "-" + DateTime.Now.Month + " " + DateTime.Now.Hour + "h-" + DateTime.Now.Minute + ".bak";
            dialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            if (dialog.ShowDialog() == DialogResult.OK || dialog.ShowDialog() == DialogResult.Yes)
            {
                ExecuteSql(comboServer.Text, "master", textUser.Text, textPas.Text, "backup database [KhoHangHoa] from disk=N'" + dialog.FileName + "' with norecovery");
            }
            else return;
        }
    }
}