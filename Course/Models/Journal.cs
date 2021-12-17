//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Journal
    {
        public int RecordID { get; set; }
        public int Subject_ID { get; set; }

        [Display(Name = "ID студента")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [RegularExpression(@"[0-9]{5,10}", ErrorMessage = "Некорректный ID студента")]
        public int Student_ID { get; set; }

        [Display(Name = "Оценка")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [RegularExpression(@"[0,5]?", ErrorMessage = "Некорректная оценка")]    
        public string Mark { get; set; }

        [Display(Name = "Дата оценки")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1/1/2010", "1/1/2022",
        //ErrorMessage = "Value for \"{0}\" must be between {1} and {2}")]
        public DateTime MarkDate {
            /*get
            {
                return MarkDate;
            }

            set
            {
                //DateTime d1 = new DateTime(2010, 1, 1, 0, 0, 0);
                //DateTime d2 = new DateTime(2022, 1, 1, 0, 0, 0);           

                
                if (value.Date > d1.Date && value.Date < d2.Date)
                {
                    MarkDate = value;
                }                    
            }*/
            get; set;
        }

        //private DateTime d1 = new DateTime(2010, 1, 1, 0, 0, 0);
        //private DateTime d2 = new DateTime(2022, 1, 1, 0, 0, 0); 

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
