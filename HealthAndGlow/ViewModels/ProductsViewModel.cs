using HealthAndGlow.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace HealthAndGlow.ViewModels
{
    public class ProductsViewModel
    {
        public  ObservableCollection<Products> ProductsList { get; set; }

        public void  LoadProducts()
        {
            ObservableCollection<Products> _Products = new ObservableCollection<Products>();
            Image img1 = new Image();
            img1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Product1.png"));

            Image img2 = new Image();
            img2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Product2.png"));

            Image img3 = new Image();
            img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Product3.png"));

            _Products.Add(new Products { ProductName = "ProductItem1", ProductPrice = "Rs.1200", Source = img1.Source });
            _Products.Add(new Products { ProductName = "ProductItem2", ProductPrice = "Rs.1300", Source = img2.Source });
            _Products.Add(new Products { ProductName = "ProductItem3", ProductPrice = "Rs.1400", Source = img3.Source });
            _Products.Add(new Products { ProductName = "ProductItem4", ProductPrice = "Rs.1500", Source = img1.Source });
            _Products.Add(new Products { ProductName = "ProductItem5", ProductPrice = "Rs.1600", Source = img2.Source });
            _Products.Add(new Products { ProductName = "ProductItem6", ProductPrice = "Rs.1700", Source = img3.Source });
                        
            ProductsList = _Products;
        }
    }
}
