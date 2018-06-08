using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HarjutusApp.Services
{
    public class BaseService
    {
        public HttpClient _client;

        public BaseService()
        {
            _client = new HttpClient();
            #warning refactor, localhost hardcoded
            _client.BaseAddress = new Uri("https://localhost:44324/api/v1/");
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }


        protected async Task<T> PostAsync<T>(string url, T obj)
        {
            var response = await _client.PostAsJsonAsync(url, obj);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        protected async Task<T> PutAsync<T>(string url, T obj)
        {
            var response = await _client.PutAsJsonAsync(url, obj);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        protected async Task<T> DeleteAsync<T>(string url)
        {
            var response = await _client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }
    }
}
