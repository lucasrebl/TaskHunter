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
            backgroundMusicPlayer.MediaEnded += BackgroundMusicPlayer_MediaEnded;
        }

        private void BackgroundMusicPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            backgroundMusicPlayer.Position = TimeSpan.Zero;
            backgroundMusicPlayer.Play();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
