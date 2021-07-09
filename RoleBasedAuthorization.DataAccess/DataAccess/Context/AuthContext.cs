using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoleBasedAuthorization.DataAccess.DataAccess.Context
{
    public class AuthContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=RoleBasedAuthorization;Integrated Security=SSPI;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasOne<User>(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>().HasOne<Role>(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
