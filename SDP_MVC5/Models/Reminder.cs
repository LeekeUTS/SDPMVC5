using System;
using System.Data.Entity;

namespace SDP_MVC5.Models
{
    public class Reminder
    {
        public int ID { get; set; }
        public int workshopID { get; set; }
        public int studentID { get; set; }
        public DateTime createdtime { get; set; }
        public DateTime remindertime { get; set; }
        public string status { get; set; }
    }
}