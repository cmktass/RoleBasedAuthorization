using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoleBasedAuthorization.Entities.ViewModel
{
    public class UserVM
    {   
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
