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
    [Table("tbl_MotorTip")]
   public class tbl_MotorTip
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string MotorAD { get; set; }
        public string MotorBeygir { get; set; }
        public string MotorCC { get; set; }
        public string YakitID { get; set; }
        public string Silindir { get; set; }
       
    }
}
