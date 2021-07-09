using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.DataAccess.DataAccess.Context;
using RoleBasedAuthorization.DataAccess.DataAccess.Interface;
using RoleBasedAuthorization.Entities.DataModel;
using RoleBasedAuthorization.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.DataAccess.DataAccess.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        public Task<Response<UserVM>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> Register(UserVM userVM)
        {
            Response<int> response = new Response<int>();
            if (await UserExist(userVM.UserName))
            {
                User user = new User();
                CreatePasswordHash(userVM.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UserName = userVM.UserName;
                user.Name = userVM.Name;
                user.Surname = userVM.Surname;
                
                using var context = new AuthContext();
                await context.AddAsync(user);
                await context.SaveChangesAsync();
                
                response.Data = user.Id;
                response.Errors = "No Error";
            }
            else
            {
                response.Errors = "User already exists";
            }
           
            return response;
        }

      

        public async Task<bool> UserExist(string userName)
        {
            using var context = new AuthContext();
            if (await context.Users.AnyAsync(u => u.UserName == userName))
            {
                return false;
            }
            else return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        Task<Response<Entities.ViewModel.UserVM>> IAuthRepository.Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

       
    }
}
