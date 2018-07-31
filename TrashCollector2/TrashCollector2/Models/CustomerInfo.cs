using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class CustomerInfo
    {
        //[Key]
        //public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser ApplicationUser { get; set; }
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }


        //[ForeignKey("ApplicationUser")]
        //public int ApplicationUserID { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

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