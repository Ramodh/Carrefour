using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndGlow.Models
{
    public class CatalogModel
    {
        public static List<CatalogModel> CreateSampleData()
        {
            var data = new List<CatalogModel>();

            data.Add(new CatalogModel("1", "Sonata", "1", "Mobility"));
            data.Add(new CatalogModel("1", "Sonata", "1", "Dynamics AX"));
            data.Add(new CatalogModel("1", "Sonata", "1", "SAP"));
            data.Add(new CatalogModel("1", "Sonata", "1", "TUI"));
            data.Add(new CatalogModel("1", "Sonata", "1", "Good Year"));
            data.Add(new CatalogModel("1", "Sonata", "1", "Health & Glow"));
            data.Add(new CatalogModel("1", "Sonata", "1", "Microsof"));
            //data.Add(new CatalogModel("1", "Sonata", "1", "Avery"));
            //data.Add(new CatalogModel("1", "Sonata", "1", "Landmark"));
            //data.Add(new CatalogModel("1", "Sonata", "1", "Mobility"));
            //data.Add(new CatalogModel("1", "Sonata", "1", "Mobility"));
            //data.Add(new CatalogModel("1", "Sonata", "1", "Mobility"));
            data.Add(new CatalogModel("2", "Sage", "1", "Mobile Sales"));
            data.Add(new CatalogModel("2", "Sage", "1", "Services"));
            data.Add(new CatalogModel("2", "Sage", "1", "Payment Solution"));
            data.Add(new CatalogModel("2", "Sage", "1", "SCA"));
            data.Add(new CatalogModel("2", "Sage", "1", "Cuetomer View"));
            data.Add(new CatalogModel("2", "Sage", "1", "Sage One"));
            data.Add(new CatalogModel("2", "Sage", "1", "Mobility"));
            data.Add(new CatalogModel("2", "Sage", "1", "Real Estate"));
            //data.Add(new CatalogModel("2", "Sage", "1", "Mobility"));
            //data.Add(new CatalogModel("2", "Sage", "1", "Mobility"));
            //data.Add(new CatalogModel("2", "Sage", "1", "Mobility"));
            //data.Add(new CatalogModel("2", "Sage", "1", "Mobility"));
            //data.Add(new CatalogModel("2", "Sage", "1", "Mobility"));

            return data;
        }

        public CatalogModel(string catalogId, string catalogName, string categoryId, string categoryName)
        {
            CatalogName = catalogName;
            CatalogId = catalogId;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public string CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
