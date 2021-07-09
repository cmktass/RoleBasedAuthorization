﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoleBasedAuthorization.Entities.DataModel
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
