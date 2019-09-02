using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    PermissionId = 1,
                    Name = "Read"
                },
                new Permission
                {
                    PermissionId = 2,
                    Name = "Write"
                },
                new Permission
                {
                    PermissionId = 3,
                    Name = "Create"
                },
                new Permission
                {
                    PermissionId = 4,
                    Name = "Update"
                },
                new Permission
                {
                    PermissionId = 5,
                    Name = "All"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    Name = "Administrator"
                },
                new Role
                {
                    RoleId = 2,
                    Name = "Regular"
                },
                new Role
                {
                    RoleId = 3,
                    Name = "View"
                }
            );


            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission() { RolePermissionId = 1007, RoleId = 1, PermissionId = 1 },
                new RolePermission() { RolePermissionId = 1008, RoleId = 1, PermissionId = 2 },
                new RolePermission() { RolePermissionId = 1009, RoleId = 1, PermissionId = 3 },
                new RolePermission() { RolePermissionId = 1010, RoleId = 1, PermissionId = 4 },
                new RolePermission() { RolePermissionId = 1011, RoleId = 1, PermissionId = 5 },
                new RolePermission() { RolePermissionId = 1012, RoleId = 2, PermissionId = 1 },
                new RolePermission() { RolePermissionId = 1013, RoleId = 2, PermissionId = 2 },
                new RolePermission() { RolePermissionId = 1014, RoleId = 2, PermissionId = 3 },
                new RolePermission() { RolePermissionId = 1015, RoleId = 3, PermissionId = 1 }
            );




            modelBuilder.Entity<UserStatus>().HasData(
                new UserStatus { UserStatusId = 1, Name = "Active" },
                new UserStatus { UserStatusId = 2, Name = "Pending" },
                new UserStatus { UserStatusId = 3, Name = "Deleted" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 3, FirstName = "Mike", LastName = "Solomon", UserStatusId = 1 }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole() { UserRoleId = 4, UserId = 3, RoleId = 1 } 
            );
        }
    }
}
