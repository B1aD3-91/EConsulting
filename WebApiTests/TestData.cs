using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EConsulting.Controllers.Dto;
using EConsulting.Model;

namespace WebApiTests
{
    class TestData
    {
        public static TimeRangeDto GetValidTimeRangeDto()
        {
            return new TimeRangeDto()
            {
                Start = DateTime.Parse("2020-10-10"),
                End = DateTime.Parse("2020-10-10")
            };
        }

        public static List<TimeRangeModel> GetValidTimeRangeModelList()
        {
            return new List<TimeRangeModel>()
            {
                new TimeRangeModel()
                {
                    Start = DateTime.Parse("2020-10-10"),
                    End = DateTime.Parse("2020-10-10")
                },
                new TimeRangeModel()
                {
                    Start = DateTime.Parse("2018-10-10"),
                    End = DateTime.Parse("2018-10-10")
                }
            };
        }

        public static List<TimeRangeDto> GetValidTimeRangeDtoList()
        {
            return new List<TimeRangeDto>()
            {
                new TimeRangeDto()
                {
                    Start = DateTime.Parse("2020-10-10"),
                    End = DateTime.Parse("2020-10-10")
                },
                new TimeRangeDto()
                {
                    Start = DateTime.Parse("2018-10-10"),
                    End = DateTime.Parse("2018-10-10")
                }
            };
        }
    }
}
