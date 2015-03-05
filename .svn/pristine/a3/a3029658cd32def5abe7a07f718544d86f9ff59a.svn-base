using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace HealthAndGlow.Common.Services
{
    public static class Constants
    {
        public static string Url = "http://172.29.55.82:9090/hngeCommerceWebservice/rest/product";

        /// <summary>
        ///     Checks whether Internet is Connected (or) not
        /// </summary>
        /// <returns>bool</returns>
        public static bool ConnectedToInternet()
        {
            var InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            if (InternetConnectionProfile == null)
            {
                return false;
            }
            var level = InternetConnectionProfile.GetNetworkConnectivityLevel();
            return level == NetworkConnectivityLevel.InternetAccess;
        }
    }
}
