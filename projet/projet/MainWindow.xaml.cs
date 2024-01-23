using System;
using System.Windows;
using System.Windows.Media;

namespace projet
{
    public partial class MainWindow : Window
    {
        public MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string cheminMusique = "Sounds/yoneuve.mp3";

            if (System.IO.File.Exists(cheminMusique))
            {
                mediaPlayer.Open(new Uri(cheminMusique, UriKind.RelativeOrAbsolute));
                mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;

                mediaPlayer.Play();
            }
            else
            {
                MessageBox.Show("Fichier audio introuvable : " + cheminMusique);
            }
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }
    }
}
