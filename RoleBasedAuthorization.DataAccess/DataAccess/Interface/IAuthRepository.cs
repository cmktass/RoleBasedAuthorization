using RoleBasedAuthorization.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.DataAccess.DataAccess.Interface
{
    public interface IAuthRepository
    {
        Task<Response<int>> Register(UserVM user);

        Task<Response<UserVM>> Login(string userName, string password);
        Task<bool> UserExist(string userName);
    }
}
