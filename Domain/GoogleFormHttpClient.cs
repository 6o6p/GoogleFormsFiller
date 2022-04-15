using GoogleFormsFiller;
using GoogleFormsFiller.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class GoogleFormHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _uri;
        private readonly GoogleForm _form;
        private readonly Proxy _proxy;

        public GoogleFormHttpClient(string uri)
        {
            _proxy = new Proxy();
            _httpClient = new HttpClient();
            _uri = new Uri(uri);
            _form = GetFormAsync().Result;
        }

        public async Task PostMultipleRandomAsync(int count)
        {
            var tasks = new List<Task<HttpResponseMessage>>();

            while(count > 0)
            {
                tasks.Add(PostRandomAsync());
                count--;
            }

            while(tasks.Count > 0)
            {
                var task = await Task.WhenAny(tasks);
                var taskResult = await task;
                Console.WriteLine($"{(HttpClient.DefaultProxy as WebProxy).Address}\t{taskResult.StatusCode}");
                tasks.Remove(task);
            }
        }

        public async Task<HttpResponseMessage> PostRandomAsync()
        {
            HttpResponseMessage result;
            do
            {
                HttpClient.DefaultProxy = new WebProxy(_proxy.GetNextProxy());
                result = await _httpClient.PostAsync(new Uri(_uri, "formResponse"), new FormUrlEncodedContent(_form.GetRandomAnswers()));
            } while (!result.IsSuccessStatusCode);

            return result;
        }


        public async Task<GoogleForm> GetFormAsync()
        {
            var newUri = new Uri(_uri, "viewform");

            var response = _httpClient.GetAsync(newUri);
            //response.EnsureSuccessStatusCode();

            var content = response.Result.Content;

            var page = await content.ReadAsStringAsync();
            //var page = await content.ReadAsAsync<string>();

            return new GoogleForm(page);
        }
    }
}
