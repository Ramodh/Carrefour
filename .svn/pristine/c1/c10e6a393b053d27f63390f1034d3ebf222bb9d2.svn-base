using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace HealthAndGlow.DataModel
{
    public class SearchProductsDataSource
    {
        private static SearchProductsDataSource _searchProductDataSource = new SearchProductsDataSource();
        private ObservableCollection<SearchProduct> _searchProducts = new ObservableCollection<SearchProduct>();

        public ObservableCollection<SearchProduct> SearchProducts
        {
            get { return this._searchProducts; }
        }


        public static async Task<IEnumerable<SearchProduct>> GetSearchResultsAsync()
        {
            await _searchProductDataSource.GetSearchResultsDataAsync();

            return _searchProductDataSource.SearchProducts;
        }

        private async Task GetSearchResultsDataAsync()
        {
            if (this._searchProducts.Count != 0)
            {
                return;
            }

            Uri dataUri = new Uri("ms-appx:///DataModel/SearchProductsData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["searched"].GetArray();

            foreach (JsonValue offersValue in jsonArray)
            {
                JsonObject itemObject = offersValue.GetObject();
                SearchProduct searchedProduct = new SearchProduct(itemObject["sku_name"].GetString(),
                    itemObject["sku_id"].GetString(),                    
                    itemObject["sku_price"].GetString(),
                    itemObject["sku_offer_price"].GetString(),
                    itemObject["sku_currency"].GetString(),
                    itemObject["sku_available_unit"].GetString(),
                    itemObject["sku_offer_desc"].GetString(),
                    itemObject["sku_product_information"].GetString(),                    
                    itemObject["sku_ingredients"].GetString(),
                    itemObject["sku_directions"].GetString(),
                    itemObject["image_url"].GetString());                

                this.SearchProducts.Add(searchedProduct);
            }
        }

        public static async Task<SearchProduct> GetSearchedProductAsync(string uniqueId)
        {
            await _searchProductDataSource.GetSearchResultsDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _searchProductDataSource.SearchProducts.Where((item) => item.SkuName.ToLower().Contains(uniqueId.ToLower()));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task<List<SearchProduct>> GetSearchedProductsAsync(string product)
        {
            await _searchProductDataSource.GetSearchResultsDataAsync();
            List<SearchProduct> matches = _searchProductDataSource.SearchProducts.Where((item) => item.SkuName.ToLower().Contains(product.ToLower())).ToList();
            return matches;
        }

        public static async Task<List<string>> GetAllProductNamesAsync()
        {
            await _searchProductDataSource.GetSearchResultsDataAsync();
            List<string> productNames = new List<string>();

            foreach(var item in _searchProductDataSource.SearchProducts)
            {
                productNames.Add(item.SkuName);
            }
            
            return productNames;
        }
    }

    public class SearchProduct
    {
        public SearchProduct(string skuname, string skuid, string skuprice, string skuofferprice,
             string skucurrency, string skuavaibaleunit, string skuoferdescription, string skuproductinformation, string skuingredients, string skudirections ,string skuimageurl)
        {            
            this.SkuName = skuname;
            this.SkuId = skuid;
            this.SkuPrice = skuprice;
            this.SkuOfferPrice = skuofferprice;         
            this.SkuCurrency = skucurrency;
            this.SkuAvailableUnit = skuavaibaleunit;
            this.SkuOfferDescription = skuoferdescription;
            this.SkuProductInformation = skuproductinformation;
            this.SkuIngredients = skuingredients;
            this.SkuDirections = skudirections;
            this.SkuImageUrl = skuimageurl;
                    
        }

        public string CatalogId { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string SkuName { get; set; }
        public string SkuId { get; set; }
        public string SkuPrice { get; set; }
        public string SkuOfferPrice { get; set; }
        public string SkuDiscount { get; set; }
        public string SkuCurrency { get; set; }
        public string SkuAvailableUnit { get; set; }
        public string SkuOfferDescription { get; set; }
        public string SkuImageUrl { get; set; }

        public string SkuProductInformation { get; set; }

        public string SkuIngredients { get; set; }

        public string SkuDirections { get; set; }        
    }
}
