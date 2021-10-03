using System;
using System.Linq;

using EConsulting.Data;
using EConsulting.Model;

namespace EConsulting.Repository
{
    public class RepositoryImpl : IRepository
    {
        private readonly AppDbContext context;
        public RepositoryImpl(AppDbContext context)
        {
            this.context = context;
        }
        public long CreateTimeRange(TimeRangeModel timeRangeModel)
        {
            context.TimeRangeModels.Add(timeRangeModel);
            SaveChanges();
            return timeRangeModel.Id;
        }
        
        public IQueryable<TimeRangeModel> GetAllTimeRange()
        {
            return context.TimeRangeModels;
        }

        public bool SaveChanges()
        {
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}
