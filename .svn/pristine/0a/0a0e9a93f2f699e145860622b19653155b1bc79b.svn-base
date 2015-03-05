using HealthAndGlow.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HealthAndGlow.Common
{
    public static class CartHelper
    {
        private static ObservableCollection<ProductsDataSourceItem> _productCollection = new ObservableCollection<ProductsDataSourceItem>();
        static ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        static CartHelper()
        {

        }

        /// <summary>
        /// Returns all the items in the cart.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ProductsDataSourceItem> GetProductsInCart()
        {
            return _productCollection;
        }

        /// <summary>
        /// Delete an individual item from the cart.
        /// </summary>
        /// <param name="productId">The product id of the item to be deleted.</param>
        public static void DeleteItemFromCart(string productId)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                if (settings.Values.Count > 0)
                {
                    if (settings.Values.ContainsKey("ProductsInCart"))
                    {
                        // Deserialize the json object before processing it.
                        string deserializedObject = settings.Values["ProductsInCart"] as string;

                        _productCollection = JsonConvert.DeserializeObject<ObservableCollection<ProductsDataSourceItem>>(deserializedObject);

                        ProductsDataSourceItem product = (from prod in _productCollection
                                                          where prod.SkuId == productId
                                                          select prod).FirstOrDefault();

                        _productCollection.Remove(product);

                        // Serialize the data again when saving back to isolated storage.
                        settings.Values["ProductsInCart"] = JsonConvert.SerializeObject(_productCollection);
                    }
                }
            }
        }

        /// <summary>
        /// Get the number of products available in the cart.
        /// </summary>
        /// <returns>Returns the number of products in cart.</returns>
        public static int GetNumberOfProductsInCart()
        {
            return _productCollection.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public static void AddItemToCart(ProductsDataSourceItem product)
        {
            // See if isolated directory already doesnt exist.
            // Create isolated storage.
            // Insert the input parameter into isolated storage.
            if (product != null && _productCollection != null)
            {
                // If a product already exists should it be added to cart ?
                bool isMatch = false;

                if (_productCollection.Count >= 1)
                {
                    foreach (var prod in _productCollection)
                    {
                        if (prod.SkuId.Equals(product.SkuId))
                        {
                            isMatch = true;
                        }
                    }

                    if (!isMatch)
                    {
                        _productCollection.Add(product);
                    }
                }
                else
                {
                    _productCollection.Add(product);
                }
            }
            
            // Serialize the data when saving into isolated storage. Else it gives an exception.
            settings.Values["ProductsInCart"] = JsonConvert.SerializeObject(_productCollection);          
        }
    }
}
