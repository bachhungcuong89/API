using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Model
{
    public class AuthenticateModel
    {
        [Required]
        public string User_name { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class Role
    {
        public static int Admin = 1;
        public static int Business = 2;
    }
}
