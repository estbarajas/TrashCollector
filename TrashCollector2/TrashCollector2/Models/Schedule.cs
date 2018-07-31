using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector2.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Display(Name = "Normal Day Pickup")]
        public string NormalDayPickUp { get; set; }
        public IEnumerable<SelectListItem> NormalDayPickUps { get; set; }


        [Display(Name = "Extra Date PickUp")]
        public string ExtraDatePickUp { get; set; }
    }
}