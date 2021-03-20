using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncConsole
{
    class Program
    {
        async static Task Main()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://www.apple.com/");

            WriteLine($"Apple's home page has {response.Content.Headers.ContentLength:N0} bytes.");
        }
    }
}
