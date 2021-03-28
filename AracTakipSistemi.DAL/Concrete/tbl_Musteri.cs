using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracTakipSistemi.DAL.Concrete
{
    [Table("tbl_Musteri")]
    public class tbl_Musteri
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string MusteriTC { get; set; }
        public string MusteriAdSoyad { get; set; }
        public string MusteriTel { get; set; }
        public string MusteriEMail { get; set; }
        public string AracID { get; set; }
    }
}
