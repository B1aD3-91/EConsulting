using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EConsulting.Controllers.Dto;
using EConsulting.Model;

namespace EConsulting.Service
{
    public interface ITimeRangeService
    {
        public Task<long> CreateTimeRangeAsync(TimeRangeDto timeRangeDto);
        public Task<List<TimeRangeDto>> GetTimeRangeListAsync(DateTime startDate, DateTime endDate);
    }
}
