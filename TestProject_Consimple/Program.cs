using System;
using System.Net.Http;
using TestProject_Consimple.Client;
using TestProject_Consimple.View;

namespace TestProject_Consimple
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            Uri baseUri = new Uri("https://tester.consimple.pro/");
            DataHttpClient dataHttpClient = new DataHttpClient(httpClient, baseUri);


            ClientApplication application = new ClientApplication(dataHttpClient, new DataProcessor(), new ConsoleInteraction());
            application.Start();
        }
    }
}
