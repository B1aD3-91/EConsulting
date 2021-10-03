using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EConsulting.Data;
using EConsulting.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace EColsunting.Extension
{
    public class DbLogger
    {
        private readonly RequestDelegate next;

        public DbLogger(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext appDbContext)
        {

            await next(context);

            await appDbContext.loggingModels.AddAsync(
            new LoggingModel()
            {
                RequestUrl = UriHelper.GetDisplayUrl(context.Request),
                RequestHeaders = string.Join(",", context.Request.Headers.Select(x => $"{x.Key} : {x.Value}")),
                ResponeHeaders = string.Join(",", context.Request.Headers.Select(x => $"{x.Key} : {x.Value}"))
            }
            ); 
            await appDbContext.SaveChangesAsync();

            // TODO: How read body?? context.Response.Body - not allowed read
        }
    }
}
