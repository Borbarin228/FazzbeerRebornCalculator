using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazzbeerRebornCalculator
{
    public class AudioPlayerViewModel
    {
        readonly IAudioManager audioManager;


        public AudioPlayerViewModel(IAudioManager audioManager)
        {
            this.audioManager = audioManager;
        }

        public async void PlayAudio(string filepath, bool endless = true, double volume = 0.2)
        {
            var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(filepath));
            audioPlayer.Volume = volume;

            audioPlayer.Play();
            if (endless && audioPlayer.IsPlaying)
            {
                PlayAudio(filepath, endless, volume);
            }

        }
    }
}
