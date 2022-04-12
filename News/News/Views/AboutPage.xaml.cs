using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace News.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BackgroundColor = Color.Black;
            Galaxy2.Opacity = 0;
            Galaxy2.IsVisible = true;

            WelcomeLabel.Opacity = 0;
            WelcomeLabel.IsVisible = true;

            WelcomeLabel2.Opacity = 0;
            WelcomeLabel2.IsVisible = true;

            WelcomeLabel3.Opacity = 0;
            WelcomeLabel3.IsVisible = true;

            ButtonOne.Opacity = 0;
            ButtonOne.IsVisible = true;


            Task.Run(() =>
            {
                Task.Delay(60000);
                Galaxy2.FadeTo(1, 6000).Wait();
                WelcomeLabel.FadeTo(1, 2000).Wait();
                Task.Delay(1000).Wait();
                WelcomeLabel2.FadeTo(1, 2000).Wait();
                Task.Delay(1500).Wait();

                WelcomeLabel3.FadeTo(1, 2000).Wait();
                ButtonOne.FadeTo(1, 2000);
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ButtonOne_Clicked(object sender, EventArgs e)
        {
            AstroLetsGo.Opacity = 0;
            AstroLetsGo.IsVisible = true;

            FodderTextLabelOne.Opacity = 0;
            FodderTextLabelOne.IsVisible = true;

            FodderTextLabelTwo.Opacity = 0;
            FodderTextLabelTwo.IsVisible = true;

            FodderTextLabelThree.Opacity = 0;
            FodderTextLabelThree.IsVisible = true;

            modernMan.Opacity = 0;
            modernMan.IsVisible = true;

            FodderTextLabelFour.Opacity = 0;
            FodderTextLabelFour.IsVisible = true;

            FodderTextLabelFive.Opacity = 0;
            FodderTextLabelFive.IsVisible = true;

            FNameLabel.Opacity = 0;
            FNameLabel.IsVisible = true;

            LNameLabel.Opacity = 0;
            LNameLabel.IsVisible = true;

            spinningGlobeImage.Opacity = 0;
            spinningGlobeImage.IsVisible = true;

            AstroMusic.Opacity = 0;
            AstroMusic.IsVisible = true;

            AstroBubble.Opacity = 0;
            AstroBubble.IsVisible = true;


            await Task.Run(() =>
             {

                 Task.WhenAll(WelcomeLabel.FadeTo(0, 1000), WelcomeLabel2.FadeTo(0, 1000),
                                WelcomeLabel3.FadeTo(0, 1000), ButtonOne.FadeTo(0, 1000));

                 AstroLetsGo.FadeTo(0.7, 1000).Wait();
                 Task.WhenAll(AstroLetsGo.RotateYTo(-2500, 2000), AstroLetsGo.FadeTo(0, 2000), AstroLetsGo.ScaleTo(0, 2000, Easing.Linear)).Wait();

                 FodderTextLabelOne.FadeTo(1, 500).Wait();
                 Task.Delay(3500).Wait();
             });
            StarOne.IsVisible = true;
            await Task.Delay(300);

            StarTwo.IsVisible = true;
            await Task.Delay(300);

            StarThree.IsVisible = true;
            await Task.Delay(300);

            StarFour.IsVisible = true;
            await Task.Delay(300);

            StarFive.IsVisible = true;
            await Task.Delay(300);

            StarSix.IsVisible = true;
            await Task.Delay(300);

            StarSeven.IsVisible = true;
            await Task.Delay(300);

            StarEight.IsVisible = true;
            await Task.Delay(300);

            StarNine.IsVisible = true;
            await Task.Delay(300);

            StarTen.IsVisible = true;
            await Task.Delay(300);

            StarEleven.IsVisible = true;
            await Task.Delay(300);

            StarTwelve.IsVisible = true;
            await Task.Delay(300);

            StarThirteen.IsVisible = true;
            await Task.Delay(300);

            StarFourteen.IsVisible = true;
            await Task.Delay(300);

            StarFifteen.IsVisible = true;
            await Task.Delay(300);

            await Task.WhenAll(FodderTextLabelOne.RotateYTo(-90, 500), FodderTextLabelOne.FadeTo(0, 500),
                                StarOne.RotateYTo(-90, 500), StarOne.FadeTo(0,500),
                                StarTwo.RotateYTo(-90, 500), StarTwo.FadeTo(0, 500),
                                StarThree.RotateYTo(-90, 500), StarThree.FadeTo(0, 500),
                                StarFour.RotateYTo(-90, 500), StarFour.FadeTo(0, 500),
                                StarFive.RotateYTo(-90, 500), StarFive.FadeTo(0, 500),
                                StarSix.RotateYTo(-90, 500), StarSix.FadeTo(0, 500),
                                StarSeven.RotateYTo(-90, 500), StarSeven.FadeTo(0, 500),
                                StarEight.RotateYTo(-90, 500), StarEight.FadeTo(0, 500),
                                StarNine.RotateYTo(-90, 500), StarNine.FadeTo(0, 500),
                                StarTen.RotateYTo(-90, 500), StarTen.FadeTo(0, 500),
                                StarEleven.RotateYTo(-90, 500), StarEleven.FadeTo(0, 500),
                                StarTwelve.RotateYTo(-90, 500), StarTwelve.FadeTo(0, 500),
                                StarThirteen.RotateYTo(-90, 500), StarThirteen.FadeTo(0, 500),
                                StarFourteen.RotateYTo(-90, 500), StarFourteen.FadeTo(0, 500),
                                StarFifteen.RotateYTo(-90, 500), StarFifteen.FadeTo(0, 500));

            await Task.Delay(1500);
            await Task.Run(() =>
            {
                FodderTextLabelTwo.FadeTo(1, 500).Wait();
                Task.Delay(1000).Wait();
                kingRiseOne.RotateXTo(0, 500, Easing.Linear).Wait();
                kingRiseTwo.RotateXTo(0, 500, Easing.Linear).Wait();
                kingRiseThree.RotateXTo(0, 500, Easing.Linear).Wait();

                Task.Delay(2000).Wait();

                Task.WhenAll(FodderTextLabelTwo.FadeTo(0, 1200), FodderTextLabelTwo.RotateYTo(90, 1200),
                             kingRiseOne.FadeTo(0, 1200), kingRiseOne.RotateYTo(90, 1200),
                             kingRiseTwo.FadeTo(0, 1200), kingRiseTwo.RotateYTo(90, 1200),
                             kingRiseThree.FadeTo(0, 1200), kingRiseThree.RotateYTo(90, 1200)
                             ).Wait();

                Task.Delay(1500).Wait();
                FodderTextLabelThree.FadeTo(1, 500).Wait();
                Task.Delay(1000).Wait();
                modernMan.FadeTo(1, 500).Wait();
                Task.Delay(1000).Wait();
                Task.WhenAll(FodderTextLabelThree.FadeTo(0, 1200), FodderTextLabelThree.RotateYTo(-90, 1200),
                            modernMan.FadeTo(0, 1200), modernMan.RotateYTo(-90, 1200)).Wait();

                Task.Delay(1800).Wait();

                FodderTextLabelFour.FadeTo(1, 500).Wait();
                Task.Delay(800).Wait();
                FodderTextLabelFive.FadeTo(1, 500).Wait();
                Task.Delay(2500).Wait();
                movingImage.TranslateTo(movingImage.TranslationX + 2000, movingImage.TranslationY - 200, 13000, Easing.Linear).Wait();
                FodderTextLabelFour.FadeTo(0, 1000).Wait();
                FodderTextLabelFive.FadeTo(0, 1000).Wait();

                Task.Delay(1000);
                Task.WhenAll(FNameLabel.FadeTo(1, 1500), LNameLabel.FadeTo(1, 1500)).Wait();

                Task.Delay(1600);
                spinningGlobeImage.FadeTo(1, 1500).Wait();

                for (int i = 0; i < 100; i++)
                {
                    Task.WhenAll(AstroBubble.FadeTo(0.6, 600), AstroMusic.FadeTo(0.6, 600)).Wait();
                    Task.WhenAll(AstroBubble.FadeTo(0.3, 600), AstroMusic.FadeTo(0.3, 600)).Wait();
                }

            });

            WelcomeLabel.IsVisible = false;
            WelcomeLabel2.IsVisible = false;
            WelcomeLabel3.IsVisible = false;
            ButtonOne.IsVisible = false;
            AstroLetsGo.IsVisible = false;




        }
    }
}
//moves image diagonally
//movingImage.TranslateTo(movingImage.TranslationX - 1200, movingImage.TranslationY - 300, 10000, Easing.Linear);
