using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers.Part1Controllers
{
    public class Part1Controller : Controller
    {
        public ActionResult Index()
        {
            //Get IP Addr
            var remoteIpAddress = Request.UserHostAddress.ToString();
            this.ViewData["ip_addr"] = remoteIpAddress;

            //request cookie from previous visit
            HttpCookie cookie = Request.Cookies["cook"];

            if (cookie == null)
            {
                cookie = new HttpCookie("cook");
                cookie.Value = "1";
                cookie.Expires = DateTime.Now.AddYears(5);
                Response.Cookies.Add(cookie);

                this.ViewData["visits_times"] = Request.Cookies["cook"].Value;
            }
            else
            {
                var cook = Int32.Parse(cookie.Value);
                cook++;
                cookie.Value = cook.ToString();
                cookie.Expires = DateTime.Now.AddYears(5);
                Response.Cookies.Add(cookie);

                this.ViewData["visits_times"] = Request.Cookies["cook"].Value;
                
            }
            return View("Part1View");
        }
    }
}