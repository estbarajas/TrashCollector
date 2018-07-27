using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string NormalDayPickUp { get; set; }
        public string ExtraDatePickUp { get; set; }
    }
}