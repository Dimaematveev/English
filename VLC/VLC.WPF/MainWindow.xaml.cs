using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Vlc.DotNet.Wpf;

namespace VLC.WPF
{
   

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            
        private DirectoryInfo vlcLibDirectory;
        private VlcControl control;
        private long BeginTime = 0;
        private long EndTime = -1;
        bool Max = false;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

            OpenFile.Click += (s, e) => { OpenFile_Click(); };
            Play.Click += (s, e) => { Play_Click(); };
            Pause.Click += (s, e) => { Pause_Click(); };
            Rewind10.Click += (s, e) => { Rewind10_Click(); };
            Rewind.Click += (s, e) => { Rewind_Click(); };
            RewindBegin.Click += (s, e) => { RewindBegin_Click(); };

            ControlContainer.MouseDoubleClick += ControlContainer_MouseDoubleClick;

            Times.ValueChanged += Times_ValueChanged;
            Times.PreviewMouseMove += Times_MouseMove;
            Closing += MainWindow_Closing;
        }

        private void Times_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Times.Visibility = Visibility.Visible;
        }

        private void Times_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            control.SourceProvider.MediaPlayer.Time = (long)e.NewValue;
        }

        private void ControlContainer_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            if (Max)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                Times.Visibility = Visibility.Visible;

                Max = false;
            }
            else
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                Times.Visibility = Visibility.Hidden;
                Max = true;
            }
        }

        private void RewindBegin_Click()
        {
            BeginTime= control.SourceProvider.MediaPlayer.Time;
            EndTime = -1;
        }

        private void Rewind10_Click()
        {
            control.SourceProvider.MediaPlayer.Time -= 10000;
            var audio = control.SourceProvider.MediaPlayer.Audio;
            audio.Tracks.Current = audio.Tracks.All.ElementAt(2);
            Timer timer = new Timer(Timer10S,null,10000,0);            
        }
        private void Timer10S(object obj)
        {
            var audio = control.SourceProvider.MediaPlayer.Audio;
            audio.Tracks.Current = audio.Tracks.All.ElementAt(1);
        }

        private void Rewind_Click()
        {
            EndTime = control.SourceProvider.MediaPlayer.Time;
            control.SourceProvider.MediaPlayer.Time = BeginTime;
            var audio = control.SourceProvider.MediaPlayer.Audio;
            audio.Tracks.Current = audio.Tracks.All.ElementAt(2);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            vlcLibDirectory = new DirectoryInfo(Path.Combine(@"D:\Дмитрий\source\repos\English\VLC", "libvlc", IntPtr.Size == 4 ? "win32" : "win64", "vlc-3.0.9.2"));
            
            control = new VlcControl();
            ControlContainer.Content = control;
            control.SourceProvider.CreatePlayer(vlcLibDirectory);
            control.SourceProvider.MediaPlayer.LengthChanged += MediaPlayer_LengthChanged;
           
        }

        private void MediaPlayer_LengthChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs e)
        {
            Dispatcher.Invoke((Action)delegate
            {
                Times.Minimum = 0;
                Times.Maximum = control.SourceProvider.MediaPlayer.Length;
            });
        }

        private void OpenFile_Click()
        {


            
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
         

            if (openFileDialog.ShowDialog() ==true)
            {
                control.BeginInit();
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                control.SourceProvider.MediaPlayer.Play(fileInfo);
                control.SourceProvider.MediaPlayer.Time = 110000;
                control.SourceProvider.MediaPlayer.Paused += MediaPlayer_Paused;
                control.SourceProvider.MediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
                control.EndInit();
            }
           

        }


        
        private void MediaPlayer_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            if (EndTime != -1 && e.NewTime>EndTime)
            {
                Pause_Click();
            }
        }

        private void MediaPlayer_Paused(object sender, Vlc.DotNet.Core.VlcMediaPlayerPausedEventArgs e)
        {
            if (EndTime != -1)
            {
                if (control.SourceProvider.MediaPlayer.Time>EndTime)
                {
                    var audio = control.SourceProvider.MediaPlayer.Audio;
                    audio.Tracks.Current = audio.Tracks.All.ElementAt(1);
                    BeginTime = EndTime;
                    EndTime = -1;
                    Play_Click();
                }
            }
        }



        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            control?.Dispose();
        }

        private void Play_Click()
        {
            control.SourceProvider.MediaPlayer.Play();
        }

        private void Pause_Click()
        {
            control.SourceProvider.MediaPlayer.Pause();
        }


        


    }
}

