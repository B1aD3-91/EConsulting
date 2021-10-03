using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EConsulting;
using EConsulting.Controllers;
using EConsulting.Controllers.Dto;
using EConsulting.Repository;
using EConsulting.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Moq;

using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace WebApiTests
{
    public class UnitTest1
    {

        private static IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
        private static TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseConfiguration(config));
        private static HttpClient client = server.CreateClient();

        [Fact]
        public async Task wheReceivedValidDataThenReturnValidResponse()
        {
            // get
            var start = DateTime.Parse("2020-10-10");
            var end = DateTime.Parse("2020-10-10");

            // when
            var iLogger = new Mock<ILogger<TimeRangeController>>();
            var timeRangeService = new Mock<ITimeRangeService>();
            timeRangeService.Setup(service => service.GetTimeRangeListAsync(start, end))
                .Returns(Task.FromResult(TestData.GetValidTimeRangeDtoList()));
            var controller = new TimeRangeController(iLogger.Object, timeRangeService.Object);

            // action
            var result = (await controller.GetTimeRangeList(start, end)).Result as OkObjectResult;

            // then
            Assert.NotEmpty(result.Value as List<TimeRangeDto>);

        }

        [Fact]
        public async Task whenReceivedInvalidRageThenThowExceptionArgumentExceprion()
        {
            // get
            var start = DateTime.Parse("2020-11-10");
            var end = DateTime.Parse("2020-10-10");

            var repo = new Mock<IRepository>();
            var mapper = new Mock<IMapper>();
            var service = new TimeRangeServiceImpl(repo.Object, mapper.Object);

            // then
            await Assert.ThrowsAsync<ArgumentException>(() => service.GetTimeRangeListAsync(start, end));
        }

        [Fact]
        public async Task whenSentNotValidRequestThenResponseIsHttpRequestException()
        {
            await Assert.ThrowsAsync<HttpRequestException>(() => client.GetFromJsonAsync<IActionResult>("/api/TimeRange/get/test/test"));
        }

        [Fact]
        public async Task whenSentValidRequestThenResponseOk()
        {
            var result = await client.GetFromJsonAsync<List<TimeRangeDto>>("/api/TimeRange/get/2017-10-10/2021-10-10");

            Assert.IsType<List<TimeRangeDto>>(result);
        }
    }
}
