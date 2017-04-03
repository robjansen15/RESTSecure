using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RESTSecure
{
    class REST<T>
    {
        public void POST(T obj, string path, string token)
        {
            string URL = System.Configuration.ConfigurationManager.AppSettings["server"] + path;
            string urlParameters = "?securedObject=" + new Encryption().EncryptString(new Serializer<T>().Serialize(obj), token);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {

            }
            else
            {

            }
        }


        public string GET(T obj, string path, string token)
        {
            string responseString = string.Empty;

            string URL = System.Configuration.ConfigurationManager.AppSettings["server"] + path;
            string urlParameters = "?securedObject=" + new Encryption().EncryptString(new Serializer<T>().Serialize(obj), token);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                //lets grab the response
                responseString = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return responseString;
        }
    }
}
