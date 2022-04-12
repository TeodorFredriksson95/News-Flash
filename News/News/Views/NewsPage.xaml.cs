using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using News.Models;
using News.Services;

namespace News.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        NewsService service;
        NewsGroup newsGroup;
        Task<NewsGroup> t3 = null, t4 = null;

        public NewsPage()
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

            NewsCategory category = (NewsCategory)Enum.Parse(typeof(NewsCategory), Title.ToLower());

            await Task.Run(() =>
            {
                //Use the following code line to throw an exception and see modal exception handling
                //t3 = service.GetNewsAPISampleAsync(NewsCategory.categoryToThrow);

                //Used for sample data
                //t3 = service.GetNewsAPISampleAsync(category);
                t3 = service.GetNewsAsync(category);
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
                NewsCategory category = (NewsCategory)Enum.Parse(typeof(NewsCategory), Title.ToLower());

                //Used for sample data
                //t3 = service.GetNewsAPISampleAsync(NewsCategory.business);
                t3 = service.GetNewsAsync(category);
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
                    //Used for sample data
                    //t4 = service.GetNewsAPISampleAsync(NewsCategory.categoryToThrow);

                    t4 = service.GetNewsAsync(NewsCategory.categoryToThrow);
                    Task.WaitAll(t4);

                    throw new Exception();

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
            else
            {
                throw new Exception();
            }

            activityIndicatorNewsLoading.HeightRequest = 0;
            boxViewLine.IsVisible = true;
            activityIndicatorNewsLoading.IsRunning = false;
        }

        private async void RefreshSlowConnection_Clicked(object sender, EventArgs e)
        {
            NewsCategory category = (NewsCategory)Enum.Parse(typeof(NewsCategory), Title.ToLower());

            boxViewLine.IsVisible = false;
            activityIndicatorNewsLoading.HeightRequest = 200;
            CustomList.ItemsSource = null;
            activityIndicatorNewsLoading.IsRunning = true;
            await Task.Delay(5000);


            await Task.Run(() =>
            {
                //Used for sample data
                // t3 = service.GetNewsAPISampleAsync(category); 
                t3 = service.GetNewsAsync(category);
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