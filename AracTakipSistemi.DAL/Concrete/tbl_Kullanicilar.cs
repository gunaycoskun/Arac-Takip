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
    [Table("tbl_Kullanicilar")]
    public class tbl_Kullanicilar
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OlusturulmaTarihi { get; set; }
    }

}