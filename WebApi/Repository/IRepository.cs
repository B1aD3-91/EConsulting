using System.Linq;

using EConsulting.Model;

namespace EConsulting.Repository
{
    public interface IRepository
    {
        public long CreateTimeRange(TimeRangeModel timeRangeModel);
        public IQueryable<TimeRangeModel> GetAllTimeRange();
        public bool SaveChanges();

    }
}
