using Assignment3.Services.Part2DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class Part2Controller : Controller
    {
        // GET: Part2
        public ActionResult Index()
        {
            SlideshowDAO slideshowDAO = new SlideshowDAO();
            return View("Part2View", slideshowDAO.GetImages());
        }
    }
}