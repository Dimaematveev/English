using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Media
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Uri uri = new Uri(@"\\Laptop-lenovo\видео\Harry.Potter.Collection\Harry.Potter.and.the.Order.of.the.Phoenix.2007.BDRip.1080p.Rus.Eng.mkv");
            //MediaPlayer.MediaPlayerClass mediaPlayerClass = new MediaPlayer.MediaPlayerClass();
            AddCurrentTime_Click()
            //MediaItem
        }

        private void AddCurrentTime_Click()
        {
        //    var d = MediaControl;
        //    MediaControl.Position = MediaControl.Position.Add(new TimeSpan(0, 0, 5, 0));
        }

        private void PlayButton_Click()
        {
            //MediaControl.Play();
        }
    }
}
