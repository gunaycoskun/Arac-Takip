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
    [Table("tbl_Marka")]
    public class tbl_Marka
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string MarkaAD { get; set; }
        //public string ModelID { get; set; }
    }
}
