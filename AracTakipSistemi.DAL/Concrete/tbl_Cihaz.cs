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
    [Table("tbl_Cihaz")]
    public class tbl_Cihaz
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; }
        public string CihazAd { get; set; }
        public string CihazIP { get; set; }
        public string CihazPort { get; set; }
        public decimal XKonum { get; set; }
        public decimal YKonum { get; set; }
    }
}
