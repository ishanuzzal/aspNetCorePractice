using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTestingController : Controller
    {
        private readonly HttpClient _httpClient;
        public ApiTestingController() { 
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://leetcode.com/graphql?query=query{userContestRankingHistory(username: \"islam15-14475\")\r\n      {\r\n        attended\r\n        trendDirection\r\n        problemsSolved\r\n        totalProblems\r\n        finishTimeInSeconds\r\n        rating\r\n        ranking\r\n        contest \r\n        {\r\n          title\r\n          startTime\r\n        }\r\n      }\r\n}"),
                    };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(data);
                var specificData = jsonObject["totalSolved"];
                Console.WriteLine(specificData);
                return Ok(data);
            }
            else
            {
                // Handle the error condition
                return StatusCode((int)response.StatusCode);
            }
        }

    }
}
