using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EConsulting.Model
{
    [Table("DateRange")]
    public class TimeRangeModel
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}
