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
    [Table("tbl_Arac")]
    public class tbl_Arac
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Plaka { get; set; }
        public string SasiNo { get; set; }
        public string Renk { get; set; }
        public string Yil { get; set; }
        public string MarkaID { get; set; }
        public string ModelID { get; set; }
        public string MusteriID { get; set; }
    }
}
