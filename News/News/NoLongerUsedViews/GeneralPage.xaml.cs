using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using News.Services;
using News.Models;
using Xamarin.Essentials;

namespace News.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralPage : ContentPage
    {
        NewsService service;
        NewsGroup newsGroup;
        Task<NewsGroup> t3 = null, t4 = null;

        public GeneralPage()
        {
            InitializeComponent();
            service = new NewsService();
            newsGroup = new NewsGroup();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {

                    await LoadNews();
                }

                catch (Exception excep)
                {
                    await DisplayAlert("Failed to load news", $"The news site could not load. Please try again later", "RAAAAAAGE");

                }
            });

        }
        private async Task LoadNews()
        {


            await Task.Run(() =>
            {
                //Use the following code line to throw an exception and see modal exception handling
                //t3 = service.GetNewsAPISampleAsync(NewsCategory.categoryToThrow);

                t3 = service.GetNewsAPISampleAsync(NewsCategory.business);
                Task.WaitAll(t3);


            });

            if (t3?.Status == TaskStatus.RanToCompletion)
            {
                newsGroup = t3.Result;
                CustomList.ItemsSource = newsGroup.Articles;
            }

            else
            {
                throw new Exception();
            }
        }

        private async void Refresh_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                t3 = service.GetNewsAPISampleAsync(NewsCategory.business);
                Task.WaitAll(t3);


            });

            if (t3?.Status == TaskStatus.RanToCompletion)
            {
                newsGroup = t3.Result;
                CustomList.ItemsSource = newsGroup.Articles;
            }

            else
            {
                throw new Exception();
            }
        }

        private async void RefreshAndThrowError_Clicked(object sender, EventArgs e)
        {
            CustomList.ItemsSource = null;
            boxViewLine.IsVisible = false;
            activityIndicatorNewsLoading.HeightRequest = 200;
            activityIndicatorNewsLoading.IsRunning = true;
            await Task.Delay(5000);
            try
            {

                await Task.Run(() =>
                {
                    t4 = service.GetNewsAPISampleAsync(NewsCategory.categoryToThrow);
                    Task.WaitAll(t4);


                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed to load news", $"The news site could not load. Please try again later", "RAAAAAAGE");
            }

            if (t4?.Status == TaskStatus.RanToCompletion)
            {
                newsGroup = t4.Result;
                CustomList.ItemsSource = newsGroup.Articles;
            }


            activityIndicatorNewsLoading.HeightRequest = 0;
            boxViewLine.IsVisible = true;
            activityIndicatorNewsLoading.IsRunning = false;
        }

        private async void RefreshSlowConnection_Clicked(object sender, EventArgs e)
        {

            boxViewLine.IsVisible = false;
            activityIndicatorNewsLoading.HeightRequest = 200;
            CustomList.ItemsSource = null;
            activityIndicatorNewsLoading.IsRunning = true;
            await Task.Delay(5000);


            await Task.Run(() =>
            {
                t3 = service.GetNewsAPISampleAsync(NewsCategory.business);
                Task.WaitAll(t3);


            });

            if (t3?.Status == TaskStatus.RanToCompletion)
            {
                newsGroup = t3.Result;
                CustomList.ItemsSource = newsGroup.Articles;
            }

            else
            {
                throw new Exception();
            }

            if (CustomList.ItemsSource != null)
            {
                activityIndicatorNewsLoading.IsRunning = false;
            }
            activityIndicatorNewsLoading.HeightRequest = 0;
            boxViewLine.IsVisible = true;
        }


        private async void CustomList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            NewsItem item = (NewsItem)e.Item;
            await Navigation.PushAsync(new ArticleView(item.Url));
        }
    }
}