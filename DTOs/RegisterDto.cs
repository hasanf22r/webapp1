using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp1.DTOs
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string RePassword { get; set; }
    }
}