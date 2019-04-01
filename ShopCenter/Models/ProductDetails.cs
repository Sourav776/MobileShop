using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCenter.Models
{
    public class ProductDetails
    {
        public int ? Slno { get; set; }
        public string MobileName { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
        public string Features { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string SimType { get; set; }
    }
}