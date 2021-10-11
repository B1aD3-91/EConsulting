using System.IO;
using System.Threading.Tasks;

using EConsulting.Data;
using EConsulting.Model;

using Microsoft.AspNetCore.Http;

namespace EColsunting.Extension
{
	public class DbLoggerMiddleware
	{
		private readonly RequestDelegate next;

		public DbLoggerMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext context, AppDbContext appDbContext)
		{
			var logBuilder = await FormatRequest(context.Request, new LoggingModel.Builder());

			var originalBodyStream = context.Response.Body;

			using (var responseBody = new MemoryStream())
			{
				context.Response.Body = responseBody;
				await next(context);
				var logModel = await FormatResponse(context.Response, logBuilder);
				await responseBody.CopyToAsync(originalBodyStream);
				appDbContext.loggingModels.Add(logModel);
			}
			await appDbContext.SaveChangesAsync();
		}

		private async Task<LoggingModel.Builder> FormatRequest(HttpRequest request, LoggingModel.Builder builder)
		{
			request.EnableBuffering();
			var bodyAsText = await new StreamReader(request.Body).ReadToEndAsync();
			request.Body.Seek(0, SeekOrigin.Begin);

			return builder
				.SetPath(request.Path.Value)
				.SetRequestHeaders(request.Headers)
				.SetRequestBody(bodyAsText);
		}

		private async Task<LoggingModel> FormatResponse(HttpResponse response, LoggingModel.Builder builder)
		{
			response.Body.Seek(0, SeekOrigin.Begin);
			string bodAsText = await new StreamReader(response.Body).ReadToEndAsync();
			response.Body.Seek(0, SeekOrigin.Begin);

			return builder
				 .SetRequestHeaders(response.Headers)
				 .SetResponeBody(bodAsText)
				 .SetStatus(response.StatusCode.ToString())
				 .Build();
		}
	}
}
