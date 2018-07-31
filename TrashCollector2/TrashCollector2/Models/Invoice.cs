using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector2.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int AmountDue { get; set; }
        [Display(Name = "Invoice Status")]
        public string Status { get; set; }
    }
}