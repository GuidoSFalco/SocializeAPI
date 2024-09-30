using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeData.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string NameUser { get; set; }
        public string Pass { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
