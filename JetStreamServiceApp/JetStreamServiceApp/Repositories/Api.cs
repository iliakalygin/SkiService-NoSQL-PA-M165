using Newtonsoft.Json;
using JetStreamServiceApp.Models;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;

namespace JetStreamServiceApp.Repositories
{
    internal class Api
    {
        private static HttpClient client = new HttpClient();


        static Api()
        {
            client.BaseAddress = new Uri("http://localhost:5093/api/Order/");
        }



        // GET alles
        public static async Task<IEnumerable<Order>?> GetOrder()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5093/api/Order");

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error Http Request");

            var result = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());

            return result;
        }

        // GET by Id
        public static async Task<Order?> GetResourceById(string resourceUrl, string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{resourceUrl}/{id}");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Order>(content);
        }

        // DELETE by Id
        public static async Task DeleteResourceById(string resourceUrl, string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{resourceUrl}/{id}");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        // PUT by Id
        public static async Task UpdateResourceById(string resourceUrl, string id, Order updatedOrder)
        {
            var json = JsonConvert.SerializeObject(updatedOrder);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, $"{resourceUrl}/{id}");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
