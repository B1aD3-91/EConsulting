
using AutoMapper;

using EConsulting.Controllers.Dto;
using EConsulting.Model;

namespace EConsulting.Mapper
{
    public class TimeRangeMapper : Profile
    {
        public TimeRangeMapper()
        {
            // Source => Target
            CreateMap<TimeRangeDto, TimeRangeModel>();
            CreateMap<TimeRangeModel, TimeRangeDto>();
        }
    }
}
