using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EConsulting.Model
{
    [Table("LogRecords")]
    public class LoggingModel
    {
        [Key]
        public long Key { get; set; }
        public DateTime DateTimeRecord { get; set; } = DateTime.Now;
        public string RequestUrl { get; set; }
        public string RequestHeaders { get; set; }
        public string ResponeHeaders { get; set; }
    }
}
