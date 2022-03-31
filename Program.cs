using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            var responseBodyAsText = Run(new HttpClient()).Result;
            responseBodyAsText = responseBodyAsText.Replace(">", ">\n");

            Console.WriteLine(responseBodyAsText);
        }

        public static async Task<string> Run(HttpClient httpClient)
        {
            var uri = new Uri("https://docs.google.com/forms/d/e/1FAIpQLScn6pTePXTW0LodjrNYNXZT3jBZDUeedJh2WE7m2d1IJ5Ttww/viewform");




            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();


            return await response.Content.ReadAsStringAsync();
        }
    }
}
