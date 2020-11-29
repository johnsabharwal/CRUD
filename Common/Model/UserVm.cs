using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Enum;

namespace Common.Model
{
    public class UserVm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
 
        public string Email { get; set; }
        [Required]

        public string RoleType { get; set; } = "Admin";
        public string Status { get; set; }
        public string Mobile { get; set; }

    }
}
