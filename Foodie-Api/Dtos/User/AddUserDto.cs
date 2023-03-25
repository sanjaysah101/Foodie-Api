using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Api.Dtos.User
{
    public class AddUserDto
    {
        public string? Name {get;set;} = "new User";
        public RoleClass Role {get;set;} = RoleClass.Admin;
    }
}