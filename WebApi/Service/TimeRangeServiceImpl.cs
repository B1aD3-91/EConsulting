using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using EConsulting.Controllers.Dto;
using EConsulting.Model;
using EConsulting.Repository;


namespace EConsulting.Service
{
    public class TimeRangeServiceImpl : ITimeRangeService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper; 

        public TimeRangeServiceImpl(IRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<long> CreateTimeRangeAsync(TimeRangeDto timeRangedto)
        {
            if(timeRangedto.StartDate > timeRangedto.EndDate)
            {
                throw new ArgumentException();
            }
            return await Task.Run(() => repo.CreateTimeRange(mapper.Map<TimeRangeModel>(timeRangedto)));
        }

        public async Task<List<TimeRangeDto>> GetTimeRangeListAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException();
            }
            var result = await Task.Run(() => repo.GetAllTimeRange()
            .Where(x => (x.Start >= startDate && x.Start <= endDate) ||
            (x.End >= startDate && x.End <= endDate)).ToList());

            return mapper.Map<List<TimeRangeDto>>(result);
        }
    }
}
