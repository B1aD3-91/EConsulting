using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EConsulting.Controllers;
using EConsulting.Controllers.Dto;
using EConsulting.Repository;
using EConsulting.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Moq;

using Xunit;

namespace WebApiTests
{
    public class UnitTest1
    {
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

            // when
            var repo = new Mock<IRepository>();
            var mapper = new Mock<IMapper>();
            var service = new TimeRangeServiceImpl(repo.Object, mapper.Object);

            // then
            await Assert.ThrowsAsync<ArgumentException>(() => service.GetTimeRangeListAsync(start, end));
        }
    }
}
