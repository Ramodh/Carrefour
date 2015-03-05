using HealthAndGlow.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HealthAndGlow.Views
{
    public sealed partial class TitleBar : UserControl
    {
        public event TappedEventHandler SearchButtonTap;
        public event TappedEventHandler CartButtonTap;        
        public string CartItemCounter
        {
            get { return CartItemCount.Text; }
            set
            {
                CartItemCount.Text = value;
                NotifyPropertyChanged("CartItemCounter");
            }
        }

        public Visibility SearchIconVisibility
        {
            get { return Search.Visibility; }
            set
            {
                Search.Visibility = value;
            }
        }

        public TitleBar()
        {
            this.InitializeComponent();
        }
        
        private void Search_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Bubble the event back to the parent page.
            if (this.SearchButtonTap != null)
                this.SearchButtonTap(this, e);
        }

        private void Cart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Bubble the event back to the parent page.
            if (this.CartButtonTap != null)
                this.CartButtonTap(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }      
    }
}
