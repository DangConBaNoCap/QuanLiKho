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
using WMPLib;

namespace QuanLiKho
{
    public partial class LoadVideo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public LoadVideo()
        {
            InitializeComponent();
        }

        public LoadVideo(string path)
        {
            InitializeComponent();

            axWindowsMediaPlayer1.URL = path;
            //axWindowsMediaPlayer1.settings.autoStart = false;
            //axWindowsMediaPlayer1.currentPlaylist = axWindowsMediaPlayer1.mediaCollection.getByName("mediafile");
            //axWindowsMediaPlayer1.Ctlcontrols.next();
            //axWindowsMediaPlayer1.Ctlcontrols.play();
            
        }

        private void LoadVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }


    }
}