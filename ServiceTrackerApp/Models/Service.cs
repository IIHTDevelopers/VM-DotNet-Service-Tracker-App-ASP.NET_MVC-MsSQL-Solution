using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceTrackerApp.Models
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ServiceName { get; set; }
        public bool IsCompleted { get; set; }
        public string Notes { get; set; }
    }

}