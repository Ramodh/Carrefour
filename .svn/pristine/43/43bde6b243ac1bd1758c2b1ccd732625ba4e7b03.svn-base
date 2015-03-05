using HealthAndGlow.Common;
using HealthAndGlow.Common.JumpList;
using HealthAndGlow.Data;
using HealthAndGlow.DataModel;
using HealthAndGlow.ViewModels;
using HealthAndGlow.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Pivot Application template is documented at http://go.microsoft.com/fwlink/?LinkID=391641

namespace HealthAndGlow
{
    public sealed partial class PivotPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");
        //private CatalogViewModel defaultViewModel = new CatalogViewModel();

        public PivotPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            this.TitleBarControl.SearchButtonTap += TitleBarControl_SearchButtonTap;
            this.TitleBarControl.CartButtonTap += TitleBarControl_CartButtonTap;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            this.pivot.Loaded += pivot_Loaded;
            //this.DataContext = defaultViewModel;
        }

        async void pivot_Loaded(object sender, RoutedEventArgs e)
        {
            this.TitleBarControl.CartItemCounter = CartHelper.GetNumberOfProductsInCart().ToString();

            // NOTE : test functionality for add to cart.            
            ProductsDataSourceItem product = new ProductsDataSourceItem("1", "1", "2", "Sony external hardisk", "1", "Rs 1000", "1", "2", "3", "1","Description","/Assets/product2.png");
            CartHelper.AddItemToCart(product);

            ProductsDataSourceItem product1 = new ProductsDataSourceItem("1", "1", "2", "Levis pants", "2", "Rs 700", "2", "2", "3", "2", "Description", "/Assets/product3.png");
            CartHelper.AddItemToCart(product1);

            ProductsDataSourceItem product2 = new ProductsDataSourceItem("1", "1", "2", "Levis pants", "3", "Rs 900", "1", "2", "3", "1", "Description", "/Assets/Product1.png");
            CartHelper.AddItemToCart(product2);

            this.TitleBarControl.CartItemCounter = CartHelper.GetNumberOfProductsInCart().ToString();

            var offersData = await OffersAndDealsDataSource.GetOffersAsync();
            //DataContext = offersData;
            OffersListView.ItemsSource = offersData;

            var dealsData = await OffersAndDealsDataSource.GetDealsAsync();
            DealsListView.ItemsSource = dealsData;

            //GroupedCategoryList = await new CatalogViewModel().GetDataTest();
            this.groupedItemsViewSource.Source = await new CatalogViewModel().GetDataTest();
            this.gridView.ItemsSource = groupedItemsViewSource.View.CollectionGroups;
        }

        async void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            else
            {
                var msg = new MessageDialog("Do you want to Exit From the Application??");
                msg.Title = "Exit";
                var okBtn = new UICommand("OK");
                var cancelBtn = new UICommand("Cancel");
                msg.Commands.Add(okBtn);
                msg.Commands.Add(cancelBtn);
                IUICommand result = await msg.ShowAsync();

                if (result != null && result.Label == "OK")
                {
                    Application.Current.Exit();
                }
            }
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
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        //public CatalogViewModel DefaultViewModel
        //{
        //    get { return this.defaultViewModel; }
        //}
        //List<JumpListGroup<SubCategoryItem>> _groupedCategoryList;
        //public List<JumpListGroup<SubCategoryItem>> GroupedCategoryList
        //{
        //    get { return _groupedCategoryList; }
        //    private set
        //    {
        //        _groupedCategoryList = value;
        //        OnPropertyChanged("GroupedCategoryList");
        //    }
        //}

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>.
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //var sampleDataGroup = await SampleDataSource.GetGroupAsync("Group-1");
            //this.DefaultViewModel[FirstGroupName] = sampleDataGroup;

            //var offersData = await OffersAndDealsDataSource.GetOffersAsync();
            ////DataContext = offersData;
            //OffersListView.ItemsSource = offersData;

            //var dealsData = await OffersAndDealsDataSource.GetDealsAsync();
            //DealsListView.ItemsSource = dealsData;

            ////GroupedCategoryList = await new CatalogViewModel().GetDataTest();
            //this.groupedItemsViewSource.Source = await new CatalogViewModel().GetDataTest();
            //this.gridView.ItemsSource = groupedItemsViewSource.View.CollectionGroups;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache. Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/>.</param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }


        /// <summary>
        /// Handle the click event with respect to the individual item in offers pivot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Offers_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Pass the catalog id bound to the offer to the products page.
            // navigate to product page.
            var offerId = ((OffersAndDealsDataItem)e.ClickedItem).CatalogId;
            if (!Frame.Navigate(typeof(ProductsScreen), offerId))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        private void Deals_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Pass the catalog id bound to the offer to the products page.
            // navigate to product page.
            var dealsId = ((OffersAndDealsDataItem)e.ClickedItem).CatalogId;
            if (!Frame.Navigate(typeof(ProductsScreen), dealsId))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await StatusBar.GetForCurrentView().HideAsync();
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void ShopNowAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShopNowScreen));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (CategoryItem)e.ClickedItem;
            Frame.Navigate(typeof(SubCategoryScreen), clickedItem);
        }
    }
}
