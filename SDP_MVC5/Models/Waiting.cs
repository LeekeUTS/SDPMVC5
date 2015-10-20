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
        public int studentID { get; set; }
        [Display(Name = "Created Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime createdtime { get; set; }
        [Required]
        [Display(Name = "Workshop Name")]
        public string workshopName { get; set; }
        [Required]
        public int workshopSetID { get; set; }
    }
}