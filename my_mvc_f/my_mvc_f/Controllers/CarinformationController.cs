using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using my_mvc_f.App_Start;
using my_mvc_f.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace my_mvc_f.Controllers
{
    public class CarinformationController : Controller
    {

        //初始化对象
        MongoContext _dbContext;
        //构造器
        public CarinformationController()
        {
            _dbContext = new MongoContext();
        }
        // GET: Carinformation
        public ActionResult Index()
        {
            var carDetials = _dbContext._database.GetCollection<CarModel>("CarModel").FindAll().ToList();

            return View(carDetials);
        }

        // GET: Carinformation/Details/5
        public ActionResult Details(string id)
        {
            var carId = Query<CarModel>.EQ(p => p.Id, new ObjectId(id));
            var carDetail = _dbContext._database.GetCollection<CarModel>("CarModel").FindOne(carId);
            return View(carDetail);
        }

        // GET: Carinformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carinformation/Create
        [HttpPost]
        //修改至模型类
        public ActionResult Create(CarModel carmodel)
        {
            try
            {


                // get a mongodbCollection instance represent a collection on this database.

                var document = _dbContext._database.GetCollection<BsonDocument>("CarModel");

                //added filter to check duplicate records on bases of carname and color

                var query = Query.And(Query.EQ("Carname", carmodel.Carname), Query.EQ("Color", carmodel.Color));

                //will return count if same document exits else will return 0.

                var count = document.FindAs<CarModel>(query).Count();


                //if it is 0 then only we are going to insert document


                if (count == 0)
                {
                    var result = document.Insert(carmodel);
                }
                else
                {
                    TempData["Message"] = "Carname already exit!";
                    return View("Create", carmodel);
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message1 = "Error!";
                return View();
            }
        }

        // GET: Carinformation/Edit/5
        public ActionResult Edit(string id)
        {

            var document = _dbContext._database.GetCollection<CarModel>("CarModel");
            //query.eq 前者是数据库中的id后者是从前台传过来的对象
            var carDetailscount = document.FindAs<CarModel>(Query.EQ("_id", new ObjectId(id))).Count();
         
            if (carDetailscount > 0)
            {
                var carObjectid = Query<CarModel>.EQ(p => p.Id, new ObjectId(id));

                var carDetail = _dbContext._database.GetCollection<CarModel>("CarModel").FindOne(carObjectid);

                return View(carDetail);
            }
            return RedirectToAction("Index");

            //  return View();
        }

        // POST: Carinformation/Edit/5
        #region
            /// <summary>
            /// s实现的是HTTPPOST的更新数据
            /// </summary>
            /// <param name="id"></param>
            /// <param name="carmodel"></param>
            /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(string id, CarModel carmodel)
        {
            try
            {
                
                //对数据库编辑的操作全部放在httppost中
                var document = _dbContext._database.GetCollection<CarModel>("CarModel");
                var carDetailscount = document.FindAs<CarModel>(Query.EQ("_id", new ObjectId(id))).Count();
                if (carDetailscount > 0)
                // TODO: Add update logic here
                {
                    var carObjectid = Query<CarModel>.EQ(p => p.Id, new ObjectId(id));

                    var carDetail = _dbContext._database.GetCollection<CarModel>("CarModel").FindOne(carObjectid);

                    return View(carDetail);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "This is an error!";
                return View();
            }
        }
        #endregion
        // GET: Carinformation/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            //Mongo Query
            var carobjectid = Query<CarModel>.EQ(p => p.Id, new ObjectId(id));
            var cardetails = _dbContext._database.GetCollection<CarModel>("CarModel").FindOne(carobjectid);  //it's a string query.

            return View(cardetails);
        }

        // POST: Carinformation/Delete/5
        [HttpPost]
        public ActionResult Delete(string id,CarModel carmodel)
        {
            try
            {
                //Mongo Query  
                var carObjectid = Query<CarModel>.EQ(p => p.Id, new ObjectId(id));
                // Document Collections  
                var collection = _dbContext._database.GetCollection<CarModel>("CarModel");
                // Document Delete which need ObjectId to Delete Data   
                var result = collection.Remove(carObjectid, RemoveFlags.Single);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
