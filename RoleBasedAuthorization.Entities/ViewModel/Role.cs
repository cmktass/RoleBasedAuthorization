using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoleBasedAuthorization.Entities.ViewModel
{
    public class Role
    {
        [Required]
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
