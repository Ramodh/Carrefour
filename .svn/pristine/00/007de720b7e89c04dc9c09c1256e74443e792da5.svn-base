using Coding4Fun.Toolkit.Controls;
using HealthAndGlow.Common;
using HealthAndGlow.DataModel;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Resources;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace HealthAndGlow.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cart : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public Cart()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);            
            this.Loaded += Cart_Loaded;
        }        

        void Cart_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ProductsDataSourceItem> ProductsInCart = new ObservableCollection<ProductsDataSourceItem>();
            ProductsInCart = CartHelper.GetProductsInCart();

            if (ProductsInCart.Count == 0)
            {
                //Checkout.Content = "Continue shopping";
                Checkout.Content = this.resourceLoader.GetString("strContinueShopping");
            }
            else
            {
                //Checkout.Content = "Proceed to checkout";
                Checkout.Content = this.resourceLoader.GetString("strCheckout");
            }

            CartListView.ItemsSource = ProductsInCart;
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void DeleteItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image deleteImage = sender as Image;
            CartHelper.DeleteItemFromCart(deleteImage.Tag.ToString());
            CartListView.ItemsSource = CartHelper.GetProductsInCart();
            if (CartHelper.GetNumberOfProductsInCart() == 0)
            {
                NoItemsInCart.Visibility = Visibility.Visible;                                
                Checkout.Content = this.resourceLoader.GetString("strContinueShopping");
            }
            else
            {
                NoItemsInCart.Visibility = Visibility.Collapsed;                                
                Checkout.Content = this.resourceLoader.GetString("strCheckout");
            }

            ToastPrompt prompt = new ToastPrompt();
            prompt.Message = this.resourceLoader.GetString("strProductRemovedFromCart");
            prompt.Background = new SolidColorBrush(new Color() { A = Convert.ToByte(255 * .7), R = 0XF6, G = 0x75, B = 0x34 }); ;
            prompt.Foreground = new SolidColorBrush(Colors.White);            
            prompt.Show();
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            Button checkoutButton = sender as Button;
            if(Convert.ToString(checkoutButton.Content) ==  this.resourceLoader.GetString("strCheckout"))
            {

            }

            if (Convert.ToString(checkoutButton.Content) == this.resourceLoader.GetString("strContinueShopping"))
            {
                Frame.GoBack();                
            }

        }        
    }
}
