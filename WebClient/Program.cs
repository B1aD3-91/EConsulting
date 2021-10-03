using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace EConsultingWebClient
{
    class Program
    {
        private const string GetRequest = "http://localhost:8080/api/TimeRange/get";
        private const string PutRequest = "http://localhost:8080/api/TimeRange/create";
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please enter start date in the format yyyy-MM-dd:");
                var startDate = Console.ReadLine();
                Console.WriteLine("Please enter end date in the format yyyy-MM-dd:");
                var endDate = Console.ReadLine();
                Console.WriteLine("Please choise method: 1 - GetTimeRange, 2 - PutTimeRange, Exit - to exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Task.Run(() => GetTimeRangeRequest(startDate, endDate));
                        break;
                    case "2":
                        Task.Run(() => PutTimeRangeRequest(startDate, endDate));
                        break;
                    case "Exit":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Unexpected method!");
                        break;

                }
            }
        }

        private static async Task GetTimeRangeRequest(string startDate, string endDate)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri($"{GetRequest}/{startDate}/{endDate}");
                Console.WriteLine(await client.GetStringAsync(uri));
            }
        }

        private static async Task PutTimeRangeRequest(string startDate, string endDate)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new TimeRangeDto
            {
                start = DateTime.Parse(startDate),
                end = DateTime.Parse(endDate)
            }));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (var client = new HttpClient())
            {
                var uri = new Uri($"{PutRequest}");
                var result = await client.PutAsync(uri, content);
                Console.WriteLine(await result.Content.ReadAsStringAsync());
            }
        }
    }
}
