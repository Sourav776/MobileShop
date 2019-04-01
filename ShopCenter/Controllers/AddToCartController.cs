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
    public class AddToCartController : Controller
    {
        DataTable dt;
        MobileDetail md = new MobileDetail();
        public ActionResult Add(Mobiles m)
        {
            if(Session["Cart"]==null)
            {
                List<Mobiles> li = new List<Mobiles>();
                li.Add(m);
                Session["Cart"] = li;
                ViewBag.Cart = li.Count();
                Session["Count"] = 1;
            }
            else
            {
                List<Mobiles> li = (List<Mobiles>)Session["Cart"];
                li.Add(m);
                Session["Cart"] = li;
                ViewBag.Cart = li.Count();
                Session["Count"] = Convert.ToInt32(Session["Count"]) + 1;
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Myorder()
        {
            
            return View((List<Mobiles>)Session["Cart"]);

        }
        public ActionResult Remove(Mobiles mob)
        {
            List<Mobiles> li = (List<Mobiles>)Session["Cart"];
            li.RemoveAll(x => x.Slno == mob.Slno);
            Session["Cart"] = li;
            Session["Count"] = Convert.ToInt32(Session["Count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");

        }
    }
}