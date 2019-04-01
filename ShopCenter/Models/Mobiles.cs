using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ShopCenter.Models
{
    public  class Mobiles
    {
        public int Slno { get; set; }
        public string mobileName { get; set; }
        public Double Price { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}