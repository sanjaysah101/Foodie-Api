using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Api.Models
{
    public class User
    {
        [Key]
        public int Id {get;set;}
        public string? Name {get;set;} = "new User";
        public RoleClass Role {get;set;} = RoleClass.Admin;
        public List<Category>? Categories { get; set; }
    }
}