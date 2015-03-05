﻿using HealthAndGlow.Common;
using HealthAndGlow.DataModel;
using HealthAndGlow.ViewModels;
using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace HealthAndGlow.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsScreen : Page
    {
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");
        public ProductsScreen()
        {
            this.InitializeComponent();
            this.TitleBarControl.SearchButtonTap += TitleBarControl_SearchButtonTap;
            this.TitleBarControl.CartButtonTap += TitleBarControl_CartButtonTap;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //ProductsViewModel viewmodelobj = new ProductsViewModel();
            //viewmodelobj.LoadProducts();
            //this.DataContext = viewmodelobj;
            this.TitleBarControl.CartItemCounter = CartHelper.GetNumberOfProductsInCart().ToString();

            //var ProductList = await new ProductViewModel().GetProducts();
            var productsData = await ProductsDataSource.GetProductsAsync();
            ProductsGridView.ItemsSource = productsData;
        }

        private void ProductsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ProductDetailScreen));
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
    }



}
