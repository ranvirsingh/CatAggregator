using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CatAggregatorApp.Helper
{
    public static class ServiceHelper
    {
        public static HttpClient RESTClient { get; set; }

        public static void Initialize() 
        {
            RESTClient = new HttpClient();
            RESTClient.DefaultRequestHeaders.Accept.Clear();
            RESTClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
