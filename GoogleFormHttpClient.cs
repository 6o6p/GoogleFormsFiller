using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class GoogleFormHttpClient : HttpClient
    {
        private readonly Uri _uri;

        public GoogleFormHttpClient(string uri)
        {
            _uri = new Uri(uri);
        }

        public async Task<HttpResponseMessage> PostAsync(HttpContent content)
        {
            return await PostAsync(new Uri(_uri, "formResponse"), content);
        }

        public async Task<string> GetPublicLoadData()
        {
            var response = await GetAsync(new Uri(_uri,"viewform"));
            response.EnsureSuccessStatusCode();

            var page = await response.Content.ReadAsStringAsync();

            var publicLoadData = new PublicLoadParser().ParsePublicLoadFromPage(page);

            return publicLoadData;
        }
    }
}
