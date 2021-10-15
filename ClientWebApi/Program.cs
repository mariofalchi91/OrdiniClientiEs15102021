using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientWebApi
{
    class Program
    {
        static async Task Main()
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
                    Console.WriteLine($"{item.Id} - {item.Codice} - {item.Nome} - {item.Cognome}");
            }

            Console.WriteLine();

            httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44376/api/ordini/")
            };

            httpResponse = await client.SendAsync(httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                string jsonData = await httpResponse.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<OrdineContract>>(jsonData);

                foreach (var item in results)
                    Console.WriteLine($"{item.Id} - {item.ClienteId} - {item.Data} - {item.CodOrdine} - {item.CodProdotto} - {item.Importo}");
            }

            Console.ReadKey();
        }
    }
}
