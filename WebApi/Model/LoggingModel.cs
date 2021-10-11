using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Microsoft.Extensions.Primitives;

namespace EConsulting.Model
{
	[Table("LogRecords")]
	public class LoggingModel
	{
		[Key]
		public long Key { get; set; }
		public DateTime DateTimeRecord { get; set; } = DateTime.Now;
		public string Path { get; set; }
		public string RequestHeaders { get; set; }
		public string RequestBody { get; set; }
		public string Status { get; set; }
		public string ResponeHeaders { get; set; }
		public string ResponeBody { get; set; }

		public Builder newBuilder()
		{
			return new Builder();
		}

		[NotMapped]
		public class Builder
		{
			private LoggingModel model;
			public Builder() { model = new LoggingModel(); }

			public Builder SetPath(string path)
			{
				model.Path = path;
				return this;
			}
			public Builder SetRequestHeaders(IDictionary<string, StringValues> headers)
			{
				model.RequestHeaders
					= string.Join(",", headers.Select(x => $"{x.Key} : {x.Value}"));
				return this;
			}
			public Builder SetRequestBody(string body)
			{
				model.RequestBody = body; return this;
			}
			public Builder SetStatus(string status)
			{
				model.Status = status;
				return this;
			}
			public Builder SetResponeHeaders(IDictionary<string, StringValues> headers)
			{
				model.ResponeHeaders
					= string.Join(",", headers.Select(x => $"{x.Key} : {x.Value}"));
				return this;
			}
			public Builder SetResponeBody(string body)
			{
				model.ResponeBody = body;
				return this;
			}
			public LoggingModel Build()
			{
				return model;
			}
		}
	}
}

