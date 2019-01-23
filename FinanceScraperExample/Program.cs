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
            Console.WriteLine(content);            
        }
    }
}
