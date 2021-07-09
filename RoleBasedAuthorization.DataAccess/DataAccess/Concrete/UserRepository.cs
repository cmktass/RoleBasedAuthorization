using RoleBasedAuthorization.DataAccess.DataAccess.Interface;
using RoleBasedAuthorization.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoleBasedAuthorization.DataAccess.DataAccess.Concrete
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {

    }
}
