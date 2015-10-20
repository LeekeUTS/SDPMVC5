using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SDP_MVC5.Models
{
    public class Attendance
    {
        public int ID { get; set; }
        [Required]
        public int workshopID { get; set; }
        [Required]
        public int bookingID { get; set; }
        [Required]
        public int studentID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime createdtime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Attendance Date")]
        [DataType(DataType.Date)]
        public DateTime attendancetime { get; set; }
        [Required]
        [Display(Name = "Workshop Name")]
        public string workshopName { get; set; }
        [Required]
        [Display(Name = "PassCode")]
        public string passCode { get; set; }
    }
}