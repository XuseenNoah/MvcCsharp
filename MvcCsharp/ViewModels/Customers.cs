using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCsharp.ViewModels
{
    public class Customers
    {
        public int Id { get; set; }
        [Required,Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
        [Required, Display(Name = "Customer Addres")]
        public string CustomerAddres { get; set; }
        [Required, Display(Name = "Customer Phone")]
        public string CustomerPhone { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}