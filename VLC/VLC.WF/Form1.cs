using AXVLC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLC.WF
{
    [Guid("9BE31822-FDAD-461B-AD51-BE1D1C159921")]
    public partial class Form1 : Form
    {
        readonly Vlc.DotNet.Forms.VlcControl vlcControl;
        public Form1()
        {
            InitializeComponent();

            vlcControl = new Vlc.DotNet.Forms.VlcControl();
            
            var libDirectory = new DirectoryInfo(Path.Combine(@"D:\Дмитрий\source\repos\English\VLC", "libvlc", IntPtr.Size == 4 ? "win32" : "win64", "vlc-3.0.9.2"));


            vlcControl.BeginInit();
            vlcControl.VlcLibDirectory = libDirectory;
            vlcControl.Dock = DockStyle.Fill;
            vlcControl.EndInit();
            this.Controls.Add(vlcControl);

            Play.Click += Play_Click;
            Pause.Click += Pause_Click;
            Reset.Click += Reset_Click;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            vlcControl.Audio.Tracks.Current = vlcControl.Audio.Tracks.All.ElementAt(2);
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            vlcControl.Pause();


            
        }

        private void Play_Click(object sender, EventArgs e)
        {

            FileInfo fileInfo = new FileInfo(@"\\Laptop-lenovo\видео\Harry.Potter.Collection\Harry.Potter.and.the.Order.of.the.Phoenix.2007.BDRip.1080p.Rus.Eng.mkv");

            vlcControl.VlcMediaPlayer.Play(fileInfo);
           // var ff = vlcControl.VlcMediaPlayer.Audio;
            vlcControl.VlcMediaPlayer.Time = 110000;

            vlcControl.Play();
            
        }
    }
}
