using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_mvc_f.Controllers
{
    public class List_PushController : Controller
    {
        // GET: List_Push
        public ActionResult Create(string characterName)
        {
            //Models.Character.Create(characterName);
            //return View(Models.Character.GetAll());
            return RedirectToAction("Index");
            //return View();
        }
        public ActionResult Index(string characterName) {
            Models.Character.Create(characterName);
            return View(Models.Character.GetAll());
        }
    }
}