using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace FinanceScraperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring the client
            var client = new RestClient("https://api.iextrading.com/1.0");

            // Declare the request to the endpoint
            var request = new RestRequest("/stock/market/batch?symbols=aapl,fb,tsla,amzn,googl,twtr,csco,ndaq&types=quote", Method.GET);

            // Execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;// raw content as string 
            //Console.WriteLine(content);

            var deserializedContent = JsonConvert.DeserializeObject(content); // returns as object
            //Console.WriteLine(deserializedContent);

            JArray output = new JArray(deserializedContent);

            foreach (var item in output.Children<JObject>())
            {
                foreach (JProperty prop in item.Properties())
                {
                    Console.WriteLine("symbol:  " + prop.Value["quote"]["symbol"]);
                    Console.WriteLine("companyName:  " + prop.Value["quote"]["companyName"]);
                    Console.WriteLine("sector:  " + prop.Value["quote"]["sector"]);
                    Console.WriteLine("openPrice:  " + prop.Value["quote"]["open"]);
                    Console.WriteLine("closePrice:  " + prop.Value["quote"]["close"]);
                    Console.WriteLine("latestPrice:  " + prop.Value["quote"]["latestPrice"]);
                    Console.WriteLine("marketCap:  " + prop.Value["quote"]["marketCap"]);
                    Console.WriteLine();
                }
            }
        }
    }
}
