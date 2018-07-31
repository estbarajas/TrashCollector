using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //[Key]
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Address { get; set; }
        //public int ZipCode { get; set; }

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

        //[ForeignKey("User")]
        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }
    }
}