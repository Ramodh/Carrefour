using HealthAndGlow.Models;
using System.Collections;
using Windows.UI.Xaml.Data;
using HealthAndGlow.Common.JumpList;
using System.Threading.Tasks;
using HealthAndGlow.DataModel;
using System.Collections.Generic;

namespace HealthAndGlow.ViewModels
{
    public class CatalogViewModel
    {
        public async Task<List<JumpListGroup<CatalogItem>>> GetDataTest()
        {
            var items = await CategoriesDataSource.GetCategoriesAsync();
            var data = items.ToGroups(x => x.CatalogId, x => x.CatalogName);
            return data;
        }
    }
}
