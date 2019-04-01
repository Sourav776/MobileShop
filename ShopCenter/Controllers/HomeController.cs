using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using ShopCenter.Models;

namespace ShopCenter.Controllers
{
   
    public class HomeController : Controller
    {
        MobileDetail md = new MobileDetail();
        DataTable dt;
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Index()
        {
            string cmd = "select * from Mobiles";
            dt = new DataTable();
            dt = md.SelectAll(cmd);
            List<Mobiles> mobiles = new List<Mobiles>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mobiles m = new Mobiles();
                m.Slno = Convert.ToInt32(dt.Rows[i]["slNo"]);
                m.mobileName = dt.Rows[i]["MobileName"].ToString();
                m.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                m.Url = dt.Rows[i]["Url"].ToString();
                //m.Description = dt.Rows[i][4].ToString();
                mobiles.Add(m);
            }
            return View(mobiles);
        }
        public ActionResult EachProductDetails( Mobiles m)
        {
            string cmd= "select m.slNo,m.MobileName,m.price,m.url,md.Features,md.model,md.color,md.SimType" +
                " from mobiles m inner join MobileDetails md on m.slNo=md.MobileId where m.slNo=" + m.Slno + "";
            dt = new DataTable();
            dt = md.SelectAll(cmd);
            List<ProductDetails> list = new List<ProductDetails>();
            for(int i=0;i<dt.Rows.Count; i++)
            {
                ProductDetails mobile = new ProductDetails();
                mobile.Slno = Convert.ToInt32(dt.Rows[i]["slNo"]);
                mobile.MobileName = dt.Rows[i]["MobileName"].ToString();
                mobile.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                mobile.Url = dt.Rows[i]["url"].ToString();
                mobile.Features = dt.Rows[i]["Features"].ToString();
                mobile.Model = dt.Rows[i]["model"].ToString();
                mobile.Color = dt.Rows[i]["color"].ToString();
                mobile.SimType = dt.Rows[i]["SimType"].ToString();
                list.Add(mobile);
            }
            return View(list);
        }
    }
}