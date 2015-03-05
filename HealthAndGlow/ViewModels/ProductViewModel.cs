﻿using HealthAndGlow.Common.Services;
using HealthAndGlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace HealthAndGlow.ViewModels
{
    public class ProductViewModel
    {

        /// <summary>
        /// Retrieve all products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                JsonObject jsonObject = await ServiceAgent.GetRequest(null, null);
                return ParseJson(jsonObject);
            }
            catch (Exception ex) { }

            return null;
        }

        /// <summary>
        /// Products search
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> ProductSearch()
        {
            try
            {
                JsonObject jsonObject = await ServiceAgent.GetRequest(null, null);
                return ParseJson(jsonObject);
            }
            catch (Exception ex) { }

            return null;
        }

        /// <summary>
        /// Parse product json data
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        private List<Product> ParseJson(JsonObject jsonObject)
        {
            IJsonValue value;
            List<Product> ProductList=null;
            try
            {
                if (jsonObject == null)
                    return null;

                var productArray = jsonObject.GetNamedArray("data");
                ProductList = new List<Product>();
                for (int i = 0; i < productArray.Count; i++)
                {
                    var product = productArray[i].GetObject();
                    var productObj = new Product();
                    if (product.TryGetValue("sku_name", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            productObj.sku_name = product.GetNamedString("sku_name");
                        }
                    }
                    if (product.TryGetValue("sku_id", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            productObj.sku_id = product.GetNamedString("sku_id");
                        }
                    }
                    if (product.TryGetValue("sku_available_unit", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            productObj.sku_available_unit = product.GetNamedString("sku_available_unit");
                        }
                    }
                    if (product.TryGetValue("sku_currency", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            productObj.sku_currency = product.GetNamedString("sku_currency");
                        }
                    }
                    if (product.TryGetValue("sku_directions", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            //productObj.sku_directions = product.GetNamedString("sku_directions");
                        }
                    }
                    if (product.TryGetValue("sku_ingredients", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            //productObj.sku_ingredients = product.GetNamedString("sku_ingredients");
                        }
                    }
                    if (product.TryGetValue("sku_offer_desc", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            //productObj.sku_offer_desc = product.GetNamedString("sku_offer_desc");
                        }
                    }
                    if (product.TryGetValue("sku_offer_price", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            productObj.sku_offer_price = product.GetNamedString("sku_offer_price");
                        }
                    }
                    if (product.TryGetValue("sku_product_information", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            //productObj.sku_product_information = product.GetNamedString("sku_product_information");
                        }
                    }
                    if (product.TryGetValue("sku_price", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            productObj.sku_price = product.GetNamedString("sku_price");
                        }
                    }
                    if (product.TryGetValue("sku_image_urls", out value))
                    {
                        if (value.ValueType.ToString() != null)
                        {
                            productObj.sku_image_urls = product.GetNamedString("sku_image_urls");
                        }
                    }

                    ProductList.Add(productObj);
                }
                return ProductList;
            }
            catch (Exception ex)
            { }
            return ProductList;
        }
    }
}
