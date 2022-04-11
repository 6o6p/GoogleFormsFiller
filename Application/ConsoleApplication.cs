using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class ConsoleApplication
    {
        public void Run()
        {
            Console.WriteLine("Введите идентификатор формы:");
            var formAddress = $"https://docs.google.com/forms/d/e/{Console.ReadLine()}/";

            var filler = new GoogleFormHttpClient(formAddress);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("entry.1967548713", "BUP"),
            });

            var response = filler.PostAsync(content).Result;

            if (response.IsSuccessStatusCode)
                Console.WriteLine("Success");
            else
                Console.WriteLine("Failed");
        }
    }
}
