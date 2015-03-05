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
    public class ProductsDataSource
    {
        private static ProductsDataSource _productDataSource = new ProductsDataSource();

        private ObservableCollection<ProductsDataSourceItem> _products = new ObservableCollection<ProductsDataSourceItem>();
       

        public ObservableCollection<ProductsDataSourceItem> Products
        {
            get { return this._products; }
        }

       

        public static async Task<IEnumerable<ProductsDataSourceItem>> GetProductsAsync()
        {
            await _productDataSource.GetProductsDataAsync();

            return _productDataSource.Products;
        }
        private async Task GetProductsDataAsync()
        {
            if (this._products.Count != 0)
            {
                return;
            }

            Uri dataUri = new Uri("ms-appx:///DataModel/ProductData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["data"].GetArray();

            foreach (JsonValue productValue in jsonArray)
            {
                JsonObject itemObject = productValue.GetObject();
                ProductsDataSourceItem productItem = new ProductsDataSourceItem(itemObject["catalog_id"].GetString(),
                    itemObject["category_id"].GetString(),
                    itemObject["subcategory_id"].GetString(),
                    itemObject["sku_name"].GetString(),
                    itemObject["sku_id"].GetString(),
                    itemObject["sku_price"].GetString(),
                    itemObject["sku_offer_price"].GetString(),
                    itemObject["sku_discount"].GetString(),
                    itemObject["sku_currency"].GetString(),
                    itemObject["sku_available_unit"].GetString(),
                    itemObject["sku_offer_desc"].GetString(),
                    itemObject["sku_image_urls"].GetString());

                this.Products.Add(productItem);
            }
        }

      
    }

    public class ProductsDataSourceItem
    {
        public ProductsDataSourceItem(string catalogid, string categoryid, string subcategoryid, string skuname, string skuid, string skuprice, string skuofferprice,
            string skudiscount, string skucurrency, string skuavaibaleunit, string skuoferdescription, string skuimageurl)
        {
            this.CatalogId = catalogid;
            this.CategoryId = categoryid;
            this.SubCategoryId = subcategoryid;
            this.SkuName = skuname;
            this.SkuId = skuid;
            this.SkuPrice = skuprice;
            this.SkuOfferPrice = skuofferprice;
            this.SkuDiscount = skudiscount;
            this.SkuCurrency = skucurrency;
            this.SkuAvailableUnit = skuavaibaleunit;
            this.SkuOfferDescription = SkuOfferDescription;
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
    }
}
