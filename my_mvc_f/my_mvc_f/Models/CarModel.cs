using MongoDB.Bson;//用于控制bson序列化和反序列化
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using my_mvc_f.App_Start;

namespace my_mvc_f.Models
{
    public class CarModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Carname")]
        public string Carname { get; set; }
        [BsonElement("Price")]
        public int Price { get; set; }
        [BsonElement("Color")]
        public string Color { get; set; }
        [BsonElement("Engineno")]//bson attr+bson elementname
        public string Engineno { get; set; }
        [BsonElement("RegistrationDate")]
        public string RegistrationDate { get; set; }

        [BsonElement("Model")]
        public string Model { get; set; }

        [BsonElement("Chassisno")]
        public string Chassisno { get; set; }
    }
}   