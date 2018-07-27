using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer : Roles
    {
        [ForeignKey("Schedule")]
        [Display(Name = "Schedule Id")]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }


        public IEnumerable<Schedule> Schedules { get; set; }

        [ForeignKey("Invoice")]
        [Display(Name = "Invoice Id")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }


        public IEnumerable<Invoice> Invoices { get; set; }
    }
}