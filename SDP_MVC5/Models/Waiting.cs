using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SDP_MVC5.Models
{
    public class Waiting
    {
        public int ID { get; set; }
        [Required]
        public int workshopID { get; set; }
        [Required]
        public int bookingID { get; set; }
        [Required]
        public int studentID { get; set; }
        [Display(Name = "Created Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime createdtime { get; set; }
    }
}