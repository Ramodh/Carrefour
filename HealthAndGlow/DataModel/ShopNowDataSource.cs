using Newtonsoft.Json;
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
    public class ShopNowDataSource
    {
        private static ShopNowDataSource _sampleDataSource = new ShopNowDataSource();

        private ObservableCollection<ShopNowDataItem> _dealsoftheday = new ObservableCollection<ShopNowDataItem>();
        private ObservableCollection<ShopNowDataItem> _ourfavourites = new ObservableCollection<ShopNowDataItem>();
        private ObservableCollection<ShopNowDataItem> _ourjustout = new ObservableCollection<ShopNowDataItem>();

        public ObservableCollection<ShopNowDataItem> DealsOfTheDay
        {
            get { return this._dealsoftheday; }
        }

        public ObservableCollection<ShopNowDataItem> OurFavourties
        {
            get { return this._ourfavourites; }
        }

        public ObservableCollection<ShopNowDataItem> JustOut
        {
            get { return this._ourjustout; }
        }

        public static async Task<IEnumerable<ShopNowDataItem>> GetDealsOfTheDayAsync()
        {
            await _sampleDataSource.GetDealsOfTheDayDataAsync();

            return _sampleDataSource.DealsOfTheDay;
        }
        private async Task GetDealsOfTheDayDataAsync()
        {
            if (this._dealsoftheday.Count != 0)
            {
                return;
            }

            Uri dataUri = new Uri("ms-appx:///DataModel/ShopNow.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["data"].GetArray();
            foreach (JsonValue DealsOfTheDayValue in jsonArray)
            {
                JsonObject itemObject = DealsOfTheDayValue.GetObject();
                ShopNowDataItem DealsOfTheDayItem = new ShopNowDataItem(itemObject["catalog_id"].GetString(),
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

                this.DealsOfTheDay.Add(DealsOfTheDayItem);
            }
        }

        public static async Task<IEnumerable<ShopNowDataItem>> GetOurFavourtiesAsync()
        {
            await _sampleDataSource.GetOurFavourtiesDataAsync();

            return _sampleDataSource.OurFavourties;
        }
        private async Task GetOurFavourtiesDataAsync()
        {
            if (this._ourfavourites.Count != 0)
            {
                return;
            }

            Uri dataUri = new Uri("ms-appx:///DataModel/ShopNow.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["data"].GetArray();

            foreach (JsonValue OurFavourtiesValue in jsonArray)
            {
                JsonObject itemObject = OurFavourtiesValue.GetObject();
                ShopNowDataItem OurFavourtiesItem = new ShopNowDataItem(itemObject["catalog_id"].GetString(),
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

                this.OurFavourties.Add(OurFavourtiesItem);
            }
        }

        public static async Task<IEnumerable<ShopNowDataItem>> GetOurJustOutAsync()
        {
            await _sampleDataSource.GetJustOutDataAsync();

            return _sampleDataSource.JustOut;
        }
        private async Task GetJustOutDataAsync()
        {
            if (this._ourjustout.Count != 0)
            {
                return;
            }

            Uri dataUri = new Uri("ms-appx:///DataModel/ShopNow.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["data"].GetArray();

            foreach (JsonValue JustOutValue in jsonArray)
            {
                JsonObject itemObject = JustOutValue.GetObject();
                ShopNowDataItem JustOutItem = new ShopNowDataItem(itemObject["catalog_id"].GetString(),
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

                this.JustOut.Add(JustOutItem);
            }
        }
    }

    public class ShopNowDataItem
    {
        public ShopNowDataItem(string catalogid, string categoryid, string subcategoryid, string skuname, string skuid, string skuprice, string skuofferprice,
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
