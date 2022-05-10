using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booksite.Models
{
    public class ItemCart
    {
        public Book Book { get; set; }

        public int Quantity { get; set; }

        public float LineTotal { get; set; }
    }
}