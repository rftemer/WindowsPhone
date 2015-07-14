using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Networking;
using System.Threading.Tasks;
using Windows.Web.Http;
using System.Threading;

namespace NuBank.RestApi
{
    public class RestAPI
    {
        private string addressapi = string.Empty;

        public RestAPI(string _addressapi)
        {
            addressapi = _addressapi;
        }
        
        public int GetJson(out string jsonFile)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(3000);
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(addressapi));
                HttpResponseMessage response = httpClient.SendRequestAsync(request).AsTask().Result;

                jsonFile = response.Content.ToString();
                httpClient.Dispose();
                return 0;
            }
            catch (Exception ex)
            {
                jsonFile = ex.Message; 
                return (int)ex.HResult;
            }

            
        }
        
        
    }
}
