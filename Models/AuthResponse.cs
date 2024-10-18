using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ani_server.Models
{
    public class AuthResponse
    {
          public string ErrorMessage { get; set; } = string.Empty;
          public string? Token { get; set; } = string.Empty; 
    }
}