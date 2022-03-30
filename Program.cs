using System;
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
            HttpResponseMessage response = await httpClient.GetAsync("https://docs.google.com/forms/d/e/1FAIpQLScn6pTePXTW0LodjrNYNXZT3jBZDUeedJh2WE7m2d1IJ5Ttww/viewform");
            response.EnsureSuccessStatusCode();

            var headers = response.Content.GetType();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
