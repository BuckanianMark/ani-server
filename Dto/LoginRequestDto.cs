using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ani_server.Dto
{
    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}