using Plugin.Maui.Audio;

namespace FazzbeerRebornCalculator
{
    public partial class MainPage : ContentPage
    {
        private IAudioManager audioManager = new AudioManager();


        public MainPage()
        {
            AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
            audioPlayerViewModel.PlayAudio("background.mp3");

            InitializeComponent();

        }

        async void onClicked(object? sender, EventArgs e){
            if (sender is Button btn)
            {
                await btn.ScaleTo(0.95, 120);
                await btn.ScaleTo(1, 120);
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            double fontSize;

            fontSize = width * height / 10000;


            foreach (var button in Keyboard.Children.OfType<Button>())
            {
                button.FontSize = fontSize * 0.75;
            }

            foreach (var label in Display.Children.OfType<Label>())
            {
                label.FontSize = fontSize;
            }
        }
    }

}
