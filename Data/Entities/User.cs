using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RoleType { get; set; }
        public string Status { get; set; }
    }
}
