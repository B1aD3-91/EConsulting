
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
			CreateMap<TimeRangeDto, TimeRangeModel>()
				.ForMember("Start", opt => opt.MapFrom(f => f.StartDate))
				.ForMember("End", opt => opt.MapFrom(f => f.EndDate));
			CreateMap<TimeRangeModel, TimeRangeDto>();
		}
	}
}
