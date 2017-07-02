using MongoDB.Driver;
using System;
using System.Configuration;

namespace my_mvc_f.App_Start
{
    public class MongoContext
    {

        #region

        #endregion
        //申明三个变量

        MongoClient _client;
        MongoServer _server;

        #region
        /// <summary>
        /// In this class first we have declared 3 variables
        /// MongoClient
        /// MongoServer
        /// MongoDatabase
        /// Then in the constructor of the class, we are getting values of Mongo Database from appSettings 
        /// which we have set. Next we are passing these values to 
        /// [MongoCredential.CreateMongoCRCredential] method for creating MongoCredential, and then in 
        /// the next step, we are setting MongoClientSettings, for this setting we need to pass 
        /// MongoCredential; along with that, we need to pass Host name and Port number of MongoDB.
        /// </summary>
        #endregion
        public MongoDatabase _database;
        public MongoContext() {//构造器
            //reading credentials from the web.config file.
            var MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];//read the cardatabase
            var MongoUsername = ConfigurationManager.AppSettings["MongoUsername"];//demouser
            var MongoPassword = ConfigurationManager.AppSettings["MongoPassword"];//pass@123
            var MongoPort = ConfigurationManager.AppSettings["MongoPort"];//27017
            var MongoHost = ConfigurationManager.AppSettings["MongoHost"];//localhost


            //create credentials
            var credential = MongoCredential.CreateMongoCRCredential(MongoDatabaseName,MongoUsername,MongoPassword);


            //create the mongoclienttsettings
            var settings = new MongoClientSettings {
                Credentials = new[] { credential},
                Server=new MongoServerAddress(MongoHost,Convert.ToInt32(MongoPort))
            };

            _client = new MongoClient(settings);
            _server = _client.GetServer();
            _database = _server.GetDatabase(MongoDatabaseName);
        }

    }
}