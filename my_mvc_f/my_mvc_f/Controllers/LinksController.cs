using my_mvc_f.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_mvc_f.Controllers
{
    public class LinksController : Controller
    {
        // GET: Links
        //CREATE THE CONTROLLER AND THEN MAKE THE INDEX.
        public ActionResult Index()
        {
            var model = new Character();
            model.Name = "Hux";
           // var name = "Hux";
            return View(model);
        }
        //设置不同的返回方式，并且可以打断点在其下位置 按住F5对其进行执行
        public string Welcome() {
            return "hello world! This is another mvc!";//按ctrl shift b 进行编译 断点调试

        }
        //带参数的返回类型
        public string Hello(string name="simon") {
            //对传输的值进行安全处理
            return "welcome" + HttpUtility.HtmlEncode(name);// 同样也可以使用Server.HtmlEncode(name)对其进行编码
            //当然也可以对其进行默认参数设置。name="simon"
            // ? name=jack 进行传值实现
        }
        public ActionResult Jack(string name="Jack",int num=5) {
            ViewBag.Message = name;
            ViewBag.Times = num;
            return View();
        }
    }
}