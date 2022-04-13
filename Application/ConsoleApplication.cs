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

            Console.WriteLine("Сколько раз нужно отправить ответ?");
            var count = int.TryParse(Console.ReadLine(), out var c)
                ? c
                : throw new ArgumentException("Число вводи");

            filler.PostMultipleRandomAsync(count).Wait();
        }
    }
}
