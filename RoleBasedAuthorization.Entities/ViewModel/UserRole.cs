using System;
using System.Collections.Generic;
using System.Text;

namespace RoleBasedAuthorization.Entities.ViewModel
{
    public class UserRole
    {
        public int UserId { get; set; }
        public UserVM User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
