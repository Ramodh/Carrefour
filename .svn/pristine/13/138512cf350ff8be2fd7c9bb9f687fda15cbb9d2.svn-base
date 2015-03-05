using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace HealthAndGlow.DataModel
{
    public class OffersAndDealsDataSource
    {
        private static OffersAndDealsDataSource _sampleDataSource = new OffersAndDealsDataSource();

        private ObservableCollection<OffersAndDealsDataItem> _offers = new ObservableCollection<OffersAndDealsDataItem>();
        private ObservableCollection<OffersAndDealsDataItem> _deals = new ObservableCollection<OffersAndDealsDataItem>();

        public ObservableCollection<OffersAndDealsDataItem> Offers
        {
            get { return this._offers; }
        }

        public ObservableCollection<OffersAndDealsDataItem> Deals
        {
            get { return this. _deals; }
        }        

        public static async Task<IEnumerable<OffersAndDealsDataItem>> GetOffersAsync()
        {
            await _sampleDataSource.GetOffersDataAsync();

            return _sampleDataSource.Offers;
        }
        private async Task GetOffersDataAsync()
        {
            if (this._offers.Count != 0)
            {
                return;
            }

            Uri dataUri = new Uri("ms-appx:///DataModel/OffersData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["keyoffer"].GetArray();

            foreach (JsonValue offersValue in jsonArray)
            {
                JsonObject itemObject = offersValue.GetObject();
                OffersAndDealsDataItem offersItem = new OffersAndDealsDataItem(itemObject["catalog_id"].GetString(),
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

                this.Offers.Add(offersItem);
            }
        }

        public static async Task<IEnumerable<OffersAndDealsDataItem>> GetDealsAsync()
        {
            await _sampleDataSource.GetDealsDataAsync();

            return _sampleDataSource.Deals;
        }
        private async Task GetDealsDataAsync()
        {
            if (this._deals.Count != 0)
            {
                return;
            }

            Uri dataUri = new Uri("ms-appx:///DataModel/DealsData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["bestdeal"].GetArray();

            foreach (JsonValue offersValue in jsonArray)
            {
                JsonObject itemObject = offersValue.GetObject();
                OffersAndDealsDataItem offersItem = new OffersAndDealsDataItem(itemObject["catalog_id"].GetString(),
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

                this.Deals.Add(offersItem);
            }
        }
    }

    public class OffersAndDealsDataItem
    {
        public OffersAndDealsDataItem(string catalogid, string categoryid, string subcategoryid, string skuname, string skuid, string skuprice, string skuofferprice,
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
