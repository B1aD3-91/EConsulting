using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EConsulting.Service;
using EConsulting.Controllers.Dto;

namespace EConsulting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRangeController : ControllerBase
    {
        private readonly ILogger log;
        private readonly ITimeRangeService timeRangeService;

        public TimeRangeController(ILogger<TimeRangeController> log, ITimeRangeService timeRangeService)
        {
            this.log = log;
            this.timeRangeService = timeRangeService;
        }

        [HttpPut("create")]
        public async Task<ActionResult> CreateTimeRange(TimeRangeDto timeRangeDto)
        {
            log.LogInformation($"Received request to create: {timeRangeDto.Start} : {timeRangeDto.End}");
            var result = await timeRangeService.CreateTimeRangeAsync(timeRangeDto);
            return Ok($"Object successfull created with Id: {result}");
        }

        [HttpGet("get/{startDate}/{endDate}")]
        public async Task<ActionResult<List<TimeRangeDto>>> GetTimeRangeList(DateTime startDate, DateTime endDate)
        {
            log.LogInformation($"Received request to get range: {startDate} : {endDate}");
            var result = await timeRangeService.GetTimeRangeListAsync(startDate, endDate);
            return Ok(result);
        }
    }
}
