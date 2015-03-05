using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.Data.Json;
using System.Diagnostics;

namespace HealthAndGlow.DataModel
{
    public class CategoriesDataSource
    {
        private static CategoriesDataSource _categories = new CategoriesDataSource();
        //public static List<SubCategoryItem> SubCategoryList = new List<SubCategoryItem>();
        public static List<CatalogItem> CatalogList = new List<CatalogItem>();


        public static async Task<List<CatalogItem>> GetCategoriesAsync()
        {
            await _categories.GetCategoriesDataAsync();
            return CatalogList;
        }

        private async Task GetCategoriesDataAsync()
        {
            try
            {
                if (CatalogList.Count != 0)
                    return;

                Uri dataUri = new Uri("ms-appx:///DataModel/CategoryData.json");

                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                string jsonText = await FileIO.ReadTextAsync(file);
                JsonObject jsonObject = JsonObject.Parse(jsonText);
                JsonArray catalogArray = jsonObject["catalog"].GetArray();

                foreach (JsonValue catalog in catalogArray)
                {
                    CatalogItem catalogItem = new CatalogItem();

                    JsonObject catalogObj = catalog.GetObject();
                    var catalogId = catalogObj["catalog_id"].GetString();
                    var catalogName = catalogObj["catalog_name"].GetString();

                    catalogItem.CatalogId = catalogId;
                    catalogItem.CatalogName = catalogName;
                    catalogItem.CategoryList = new List<CategoryItem>();

                    JsonArray categoryArray = catalogObj["category"].GetArray();
                    foreach (JsonValue category in categoryArray)
                    {
                        CategoryItem categoryItem = new CategoryItem();
                        JsonObject categoryObj = category.GetObject();
                        var categoryId = categoryObj["category_id"].GetString();
                        var categoryName = categoryObj["category_name"].GetString();

                        categoryItem.CategoryId = categoryId;
                        categoryItem.CategoryName = categoryName;
                        categoryItem.SubCategoryList = new List<SubCategoryItem>();

                        JsonArray subcategoryArray = categoryObj["subcategory"].GetArray();
                        foreach (JsonValue subcategory in subcategoryArray)
                        {
                            SubCategoryItem subCategoryItem = new SubCategoryItem();
                            //subCategory.CatalogId = catalogId;
                            //subCategory.CatalogName = catalogName;
                            //subCategory.CategoryId = categoryId;
                            //subCategory.CategoryName = categoryName;

                            JsonObject subcategoryObj = subcategory.GetObject();
                            subCategoryItem.SubCategoryId = subcategoryObj["subcategory_id"].GetString();
                            subCategoryItem.SubCategoryName = subcategoryObj["subcategory_name"].GetString();

                            categoryItem.SubCategoryList.Add(subCategoryItem);
                        }

                        catalogItem.CategoryList.Add(categoryItem);
                    }

                    CatalogList.Add(catalogItem);
                }
            }
            catch (Exception e)
            { Debug.WriteLine(e.Message); }
        }
    }

    //public class CatalogItem
    //{
    //    public string CatalogId { set; get; }
    //    public string CatalogName { set; get; }
    //}

    //public class CategoryItem
    //{
    //    public string CategoryId { set; get; }
    //    public string CategoryName { set; get; }
    //}

    public class SubCategoryItem
    {
        //public string CatalogId { set; get; }
        //public string CatalogName { set; get; }
        //public string CategoryId { set; get; }
        //public string CategoryName { set; get; }
        public string SubCategoryId { set; get; }
        public string SubCategoryName { set; get; }
    }

    public class CatalogItem
    {
        public string CatalogId { get; set; }
        public string CatalogName { get; set; }
        public List<CategoryItem> CategoryList { get; set; }
    }

    public class CategoryItem
    {
        public string CategoryId { set; get; }
        public string CategoryName { set; get; }
        public List<SubCategoryItem> SubCategoryList { get; set; }
    }
}
