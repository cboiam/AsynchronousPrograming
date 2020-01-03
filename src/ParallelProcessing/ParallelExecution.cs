using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParallelProcessing
{
    public static class ParallelExecution
    {
        private static readonly HttpClient client;

        static ParallelExecution()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/fibonacci");
        }

        public static ParallelResponse Execute()
        {
            var request1 = client.GetAsync("/30").Result;
            var request2 = client.GetAsync("/4").Result;
            var request3 = client.GetAsync("/33").Result;
            var request4 = client.GetAsync("/1").Result;
            var request5 = client.GetAsync("/8").Result;

            var request1Response = request1.Content.ReadAsStringAsync().Result;
            var request2Response = request2.Content.ReadAsStringAsync().Result;
            var request3Response = request3.Content.ReadAsStringAsync().Result;
            var request4Response = request4.Content.ReadAsStringAsync().Result;
            var request5Response = request5.Content.ReadAsStringAsync().Result;

            return new ParallelResponse
            {
                Request1 = request1Response,
                Request2 = request2Response,
                Request3 = request3Response,
                Request4 = request4Response,
                Request5 = request5Response
            };
        }

        public static async Task<ParallelResponse> ExecuteAsync()
        {
            var request1 = client.GetAsync("/30");
            var request2 = client.GetAsync("/4");
            var request3 = client.GetAsync("/33");
            var request4 = client.GetAsync("/1");
            var request5 = client.GetAsync("/8");

            return new ParallelResponse
            {
                Request1 = await (await request1).Content.ReadAsStringAsync(),
                Request2 = await (await request2).Content.ReadAsStringAsync(),
                Request3 = await (await request3).Content.ReadAsStringAsync(),
                Request4 = await (await request4).Content.ReadAsStringAsync(),
                Request5 = await (await request5).Content.ReadAsStringAsync()
            };
        }
    }
}
