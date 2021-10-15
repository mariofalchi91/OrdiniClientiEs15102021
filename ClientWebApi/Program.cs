using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientWebApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("api client");

            HttpClient client = new HttpClient();

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44376/api/ordini/clienti")
            };

            HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                string jsonData = await httpResponse.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<ClienteContract>>(jsonData);

                foreach (var item in results)
                    Console.WriteLine($"{item.Id} - {item.Nome} - {item.Cognome}");
            }

            Console.ReadKey();
        }
    }
}
