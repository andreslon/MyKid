using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyKid.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicPage : Page
    {
        public List<string> Sounds { get; set; }
        public MediaPlayer mediaPlayer { get; set; }

        public MusicPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            FillSounds();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
        }  
        private void FillSounds()
        {
            Sounds = new List<string>();
            Sounds.Add("Bluthund_jault.mp3");
            Sounds.Add("donkey.mp3");
            Sounds.Add("Ente_quackt.mp3");
            Sounds.Add("Gaense.mp3");
            Sounds.Add("hahn_kikeriki.mp3");
            Sounds.Add("huehner.mp3");
            Sounds.Add("Katze_miaut.mp3");
            Sounds.Add("ochse.mp3");
            Sounds.Add("pferd_whinnert.mp3");
            Sounds.Add("Pony.mp3");
            Sounds.Add("Rinder_muh.mp3");
            Sounds.Add("schaf.mp3");
            Sounds.Add("schafe.mp3");
            Sounds.Add("schwein.mp3");
            Sounds.Add("truthahn.mp3");
            Sounds.Add("Ziege.mp3"); 
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        { 
            Play();
            args.Handled = false;
        }
        private void Back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            On_BackRequested();
        }
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }
        public void Play()
        {
            if (mediaPlayer == null)
            {
                mediaPlayer = new MediaPlayer();
            } 
            Random random = new Random();
            var pos = random.Next(0, 15);
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Sounds/{Sounds[pos]}"));
            mediaPlayer.Play(); 
        }
    }
}
