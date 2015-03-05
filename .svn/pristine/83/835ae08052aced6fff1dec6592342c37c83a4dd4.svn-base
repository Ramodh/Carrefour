using HealthAndGlow.Common;
using HealthAndGlow.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace HealthAndGlow.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShopNowScreen : Page
    {
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public ShopNowScreen()
        {
            this.InitializeComponent();
            this.TitleBarControl.SearchButtonTap += TitleBarControl_SearchButtonTap;
            this.TitleBarControl.CartButtonTap += TitleBarControl_CartButtonTap;
        }


        void TitleBarControl_CartButtonTap(object sender, TappedRoutedEventArgs e)
        {
            // Navigate to the cart page.
            if (!Frame.Navigate(typeof(Cart)))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        void TitleBarControl_SearchButtonTap(object sender, TappedRoutedEventArgs e)
        {
            if (!Frame.Navigate(typeof(SearchResults)))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.TitleBarControl.CartItemCounter = CartHelper.GetNumberOfProductsInCart().ToString();

            //var dealsoftheday = await ShopNowDataSource.GetDealsOfTheDayAsync();
            //DealsOfTheDayListView.ItemsSource = dealsoftheday;

            //var favourites = await ShopNowDataSource.GetOurFavourtiesAsync();
            //OurFavouritesListView.ItemsSource = favourites;

            //var justout = await ShopNowDataSource.GetOurJustOutAsync();
            //JustOutListView.ItemsSource = justout;          

            var dealsoftheday = await OffersAndDealsDataSource.GetDealsAsync();
            //DataContext = offersData;
            DealsOfTheDayListView.ItemsSource = dealsoftheday;

            var favourites = await OffersAndDealsDataSource.GetOffersAsync();
            OurFavouritesListView.ItemsSource = favourites;

            var justout = await OffersAndDealsDataSource.GetOffersAsync();
            JustOutListView.ItemsSource = justout;  

        }

        private void DealsOfTheDayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Frame.Navigate(typeof(ProductDetailScreen)))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        private void JustOutListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Frame.Navigate(typeof(ProductDetailScreen)))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        private void OurFavouritesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Frame.Navigate(typeof(ProductDetailScreen)))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }
    }
}
