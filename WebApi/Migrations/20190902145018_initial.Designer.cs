﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi;

namespace WebApi.Migrations
{
    [DbContext(typeof(WebApiContext))]
    [Migration("20190902145018_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Model.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            Name = "Read"
                        },
                        new
                        {
                            PermissionId = 2,
                            Name = "Write"
                        },
                        new
                        {
                            PermissionId = 3,
                            Name = "Create"
                        },
                        new
                        {
                            PermissionId = 4,
                            Name = "Update"
                        },
                        new
                        {
                            PermissionId = 5,
                            Name = "All"
                        });
                });

            modelBuilder.Entity("WebApi.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Regular"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "View"
                        });
                });

            modelBuilder.Entity("WebApi.Model.RolePermission", b =>
                {
                    b.Property<int>("RolePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.HasKey("RolePermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            RolePermissionId = 1007,
                            Active = false,
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 1008,
                            Active = false,
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 1009,
                            Active = false,
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 1010,
                            Active = false,
                            PermissionId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 1011,
                            Active = false,
                            PermissionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 1012,
                            Active = false,
                            PermissionId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            RolePermissionId = 1013,
                            Active = false,
                            PermissionId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            RolePermissionId = 1014,
                            Active = false,
                            PermissionId = 3,
                            RoleId = 2
                        },
                        new
                        {
                            RolePermissionId = 1015,
                            Active = false,
                            PermissionId = 1,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("WebApi.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("UserStatusId");

                    b.HasKey("UserId");

                    b.HasIndex("UserStatusId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 3,
                            FirstName = "Mike",
                            LastName = "Solomon",
                            UserStatusId = 1
                        });
                });

            modelBuilder.Entity("WebApi.Model.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserRoleId = 4,
                            RoleId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("WebApi.Model.UserStatus", b =>
                {
                    b.Property<int>("UserStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("UserStatusId");

                    b.ToTable("UserStatuses");

                    b.HasData(
                        new
                        {
                            UserStatusId = 1,
                            Name = "Active"
                        },
                        new
                        {
                            UserStatusId = 2,
                            Name = "Pending"
                        },
                        new
                        {
                            UserStatusId = 3,
                            Name = "Deleted"
                        });
                });

            modelBuilder.Entity("WebApi.Model.RolePermission", b =>
                {
                    b.HasOne("WebApi.Model.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Model.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Model.User", b =>
                {
                    b.HasOne("WebApi.Model.UserStatus", "Status")
                        .WithMany()
                        .HasForeignKey("UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Model.UserRole", b =>
                {
                    b.HasOne("WebApi.Model.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Model.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}