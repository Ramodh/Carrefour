﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace HealthAndGlow.Common.Services
{
    public static class ServiceAgent
    {

        /// <summary>
        ///     Convert's HttpResponse into JsonObject
        /// </summary>
        /// <param name="sDataResponse"></param>
        /// <returns>JsonObject</returns>
        public static async Task<JsonObject> ConvertJsonObject(HttpResponseMessage dataResponse)
        {
            try
            {
                var responseBodyAsText = await dataResponse.Content.ReadAsStringAsync();
                var responseDataObject = JsonValue.Parse(responseBodyAsText).GetObject();
                return responseDataObject;
            }
            catch (Exception ex)
            { }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryEntity"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static async Task<JsonObject> GetRequest(string query, Dictionary<string, string> parameters)
        {
            string _requestUrl = Constants.Url;
            try
            {
                if (!Constants.ConnectedToInternet())
                {
                    return null;
                }

                var _url = string.Empty;
                var _parameters = string.Empty;
                HttpRequestMessage req = null;

                _url = _requestUrl + "/" + query;

                var httpClient = new HttpClient();
                HttpResponseMessage response = null;

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
                    "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("AppProtocolVersion", "1.0.0.0");

                req = new HttpRequestMessage(HttpMethod.Get, _url);
                if (Constants.ConnectedToInternet())
                    response = await httpClient.SendAsync(req);

                if (response != null && response.IsSuccessStatusCode)
                    return await ConvertJsonObject(response);
            }
            catch (Exception ex)
            { }
            return null;
        }
    }
}
