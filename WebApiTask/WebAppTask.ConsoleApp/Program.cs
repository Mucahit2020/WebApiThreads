using System;
using System.Diagnostics;

namespace WebAppTask.ConsoleApp
{
    internal class Program
    {
         static async Task Main(string[] args)
        {

            do
            {
                AddLog("App is running ...");
                Console.Write("RequestType Sync = 0, Async = 1) : ");
                int requestType = int.Parse(Console.ReadLine());

                Console.Write("How many request Type : ");
                int requestCount = int.Parse(Console.ReadLine());

                var sw = Stopwatch.StartNew();

                var tasks = requestType == 0 ? GetSyncTask(requestCount) : GetAsyncTask(requestCount);

                await Task.WhenAll(tasks);// WhenAll ==> Bu satırdaki tasklar bitmeden alt satıra geçme demek.

                sw.Stop();

                AddLog($"Total Time : {sw.ElapsedMilliseconds} MS ");

            } while (Console.ReadKey().Key == ConsoleKey.R);


        }

        public static IEnumerable<Task>GetSyncTask(int howMany)
        {
            var result = new List<Task>();

            WebApiClient client = new WebApiClient();
            for (int i = 0; i < howMany; i++)
            {
                result.Add(client.CallSync());
            }
            return result;
        }
        public static IEnumerable<Task> GetAsyncTask(int howMany)
        {
            var result = new List<Task>();

            WebApiClient client = new WebApiClient();
            for (int i = 0; i < howMany; i++)
            {
                result.Add(client.CallAsync());
            }
            return result;
        }
        private static void AddLog(string logstr)
        {
            logstr = $"[{DateTime.Now: dd.MM.yyyy HH:mm:ss}] - {logstr}";
            Console.WriteLine(logstr);
        }
    }

    
}