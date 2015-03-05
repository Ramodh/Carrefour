using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace HealthAndGlow.DataModel
{
    public class Products : INotifyPropertyChanged
    {

        public ImageSource Source { get; set; }



        string _ProductName;
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                if (_ProductName != value)
                {
                    _ProductName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }



        string _ProductPrice;
        public string ProductPrice
        {
            get
            {
                return _ProductPrice;
            }
            set
            {
                if (_ProductPrice != value)
                {
                    _ProductPrice = value;
                    OnPropertyChanged("ProductPrice");
                }
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
