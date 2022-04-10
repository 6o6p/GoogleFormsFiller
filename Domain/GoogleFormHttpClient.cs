﻿using GoogleFormsFiller;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public GoogleFormHttpClient(string uri)
        {
            _httpClient = new HttpClient();
            _uri = new Uri(uri);
            _form = GetFormAsync().Result;
        }

        public async Task<HttpResponseMessage> PostAsync(HttpContent content)
        {
            return await _httpClient.PostAsync(new Uri(_uri, "formResponse"), content);
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