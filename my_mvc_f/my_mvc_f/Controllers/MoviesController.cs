using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using my_mvc_f.Models;

namespace my_mvc_f.Controllers
{

    #region
    /// <summary>
    /// 校验机制  dry  dont repeat yourself.在数据模型上设置校验方式
    /// </summary>
    #endregion


    public class MoviesController : Controller
    {
        //创建的私有变量
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        public ActionResult Index(string movieGenre,string searchString)
        {
            var GenreList = new List<string>();
            var genrequery = from d in db.Movies
                             orderby d.Gerne
                             select d.Gerne;

            //导入查询结果

            GenreList.AddRange(genrequery.Distinct());//去除重复项目
            ViewBag.movieGenre = new SelectList(GenreList);


            //添加搜索功能
            var movies = from m in db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString)) {
                //  s指向 title中包含search的movie
                movies = movies.Where(s=>s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                //  s指向 title中包含search的movie
                movies = movies.Where(s => s.Gerne==movieGenre);
            }
            //db.Movies.ToList()
            return View(movies);
        }
        //post
        [HttpPost]
        public string Index(FormCollection fc, string searchString) {
            return "<h3>From http post Index: "+searchString+"<br/>";
        }
        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Gerne,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }
        //get
        [HttpGet]
        // GET: Movies/Edit/5
        //这样写如果不传参数 整个程序也不会出错 int ?id 
        public ActionResult Edit(int? id)
        {
            //下面对id的值进行判断
            if (id == null)
            {
                //如果id为空  返回httprequest 状态码返回不正常
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //当合法时，去数据库中查找
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                //如果没找到 会这么显示
                return HttpNotFound();
            }
            //如果查询成功则显示
            return View(movie);
        }



        //http  get 为了实现获取某些资源
        //post 是为了创建某些资源 新的对象或者资源 修改
        // put delete
        //http 正确使用叫REST FOR 设计方式


       // 默认是打开页面的get方式

        // POST: Movies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。

        [HttpPost]
        [ValidateAntiForgeryToken] //为了防止跨页请求 防御黑客攻击
        //CRUD 的action
        //其中的BIND(Include="ID,..")这句话的意思是限制用户可修改的数据属性类型
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Gerne,Price")] Movie movie)
        {
            //首先验证状态是否有效
            if (ModelState.IsValid)
            {
                //状态改为修改
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                //若成功 则跳转到Index
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        //带了一个可为空的参数id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        //自定义actionname
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
