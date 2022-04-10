using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new ConsoleApplication();
            app.Run();


            //var result = new SquareBracketsField();
            //var g = new SquareBracketsField();
            //g.Fields.Add(new TextField("g"));
            //g.Fields.Add(new TextField("o"));
            //g.Fields.Add(new TextField("p"));
            //g.Fields.Add(new TextField("a"));

            //result.Fields.Add(g);
            //result.Fields.Add(new TextField("null"));
            //result.Fields.Add(new SquareBracketsField());
            //var j = result[0].GetValue();


            //Console.WriteLine(result.GetValue());
        }


    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var responseBodyAsText = Run(new HttpClient()).Result;
    //        responseBodyAsText = responseBodyAsText.Replace(">", ">\n");

    //        Console.WriteLine(responseBodyAsText);
    //    }

    //    public static async Task<string> Run(HttpClient httpClient)
    //    {
    //        var uri = new Uri("https://docs.google.com/forms/d/e/1FAIpQLSdgSElU9HdG9ORwCfk0FTvNRxNZAkwVWYUG5aIYuSWtTBGddg/viewform");


    //        //var content = new FormUrlEncodedContent(new[]
    //        //{
    //        //    new KeyValuePair<string, string>("entry.1967548713", "shit"),
    //        //});
    //        HttpResponseMessage response = await httpClient.GetAsync(uri);
    //        response.EnsureSuccessStatusCode();
    //        //await httpClient.PostAsync(new Uri("https://docs.google.com/forms/d/e/1FAIpQLScn6pTePXTW0LodjrNYNXZT3jBZDUeedJh2WE7m2d1IJ5Ttww/formResponse"), content);

    //        return await response.Content.ReadAsStringAsync();
    //    }
    //}
}