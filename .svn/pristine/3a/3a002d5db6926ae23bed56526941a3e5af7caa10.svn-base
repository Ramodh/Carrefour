using HealthAndGlow.Common;
using HealthAndGlow.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace HealthAndGlow.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchResults : Page
    {
        private readonly NavigationHelper navigationHelper;
        ObservableCollection<string> ProductCollection = new ObservableCollection<string>();
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public SearchResults()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.Loaded += SearchResults_Loaded;            
            this.TitleBarControl.CartButtonTap += TitleBarControl_CartButtonTap;
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        void TitleBarControl_CartButtonTap(object sender, TappedRoutedEventArgs e)
        {
            // Navigate to the cart page.
            if (!Frame.Navigate(typeof(Cart)))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        private void ProductsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {            
            SearchProduct clickedProduct = e.ClickedItem as SearchProduct;
            // Pass the id of the selected item to product details screen.
            this.Frame.Navigate(typeof(ProductDetailScreen), clickedProduct);
        }
        void SearchResults_Loaded(object sender, RoutedEventArgs e)
        {
            this.TitleBarControl.CartItemCounter = CartHelper.GetNumberOfProductsInCart().ToString();
            this.TitleBarControl.SearchIconVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void SearchAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the list of products from search products webservice document.
            // Filter the result based on the sku_name field.
            // Pass the data back to the product details page.

            // Values to be bound to Auto complete box
            //var searchResult = await SearchProductsDataSource.GetSearchResultsAsync();
            List<SearchProduct> ProductsList = new List<SearchProduct>();
            //List<String> productNames = await SearchProductsDataSource.GetAllProductNamesAsync();

            if (!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                ProductsList = await SearchProductsDataSource.GetSearchedProductsAsync(SearchTextBox.Text.Trim());
            }

            if (ProductsList != null && ProductsList.Count > 0)
            {
                ProductsFound.Text = Convert.ToString(ProductsList.Count) + " product(s) found";
                ProductsFound.FontSize = 18;
                ProductsGridView.ItemsSource = ProductsList;
            }
            else
            {
                ProductsFound.Text = "No product(s) found :(";
            }
                        
        }

    }
}
