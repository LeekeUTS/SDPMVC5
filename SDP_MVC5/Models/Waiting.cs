using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDP_MVC5.Models
{
    public class Waiting
    {
        public int ID { get; set; }
        public int workshopID { get; set; }
        public int studentID { get; set; }
        public DateTime created { get; set; }
    }
}