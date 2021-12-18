using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course.Models
{
    public class DateInput
    {
        [Display(Name = "Date from")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Date)]
        public DateTime from { get; set; }

        [Display(Name = "Date to")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Date)]
        public DateTime to { get; set; }
    }
}