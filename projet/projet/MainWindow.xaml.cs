using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace projet
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BackgroundMusicPlayer.MediaEnded += BackgroundMusicPlayer_MediaEnded;
        }

        private void BackgroundMusicPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            BackgroundMusicPlayer.Position = TimeSpan.Zero;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
