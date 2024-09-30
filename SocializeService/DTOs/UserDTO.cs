using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string NameUser { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty; 
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
