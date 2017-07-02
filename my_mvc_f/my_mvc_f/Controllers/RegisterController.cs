using my_mvc_f.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_mvc_f.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        //和前台VIEW 中的输入要相同
        //This input's name,CharcterName,will match up with action's parms,so this will automaically map up.
        public ActionResult Index(string CharacterName)
        {
            var model = new my_mvc_f.Models.Character();
            model.Name = CharacterName;
            return View(model);
        }
    }
}