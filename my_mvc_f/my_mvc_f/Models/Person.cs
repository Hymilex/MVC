using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
namespace my_mvc_f.Models
{
    public class Person
    {
        #region
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string connectionstring = "mongodb://localhost";
        //数据库名字
        public string databaseName = "test";
        #endregion
        //集合名
        public string collectionName = "userCollection";



        //省份证号
        public int id { get; set; }
        //名字
        public string name { get; set; }
        //性别
        public string sex { set; get; }
        //年龄
        public int age { set; get; }
        //出生年月日
        public DateTime birthday { get; set; }
        //手机
        public int phone_num { get; set; }
        //住址
        public string address { get; set; }

    }
}