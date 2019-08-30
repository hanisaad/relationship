using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;
using WebApi.ViewModel;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private WebApiContext _context;
        private readonly IMapper _mapper;

        public ValuesController(WebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //https://stackoverflow.com/questions/8869632/entity-framework-update-many-to-many-relationship-virtual-or-not

        [HttpGet]
        public IEnumerable<RoleViewModel> Get()
        {
            var roles = _context.Roles.Include(x => x.RolePermissions).ThenInclude(x => x.Permission).AsQueryable();

            var mapped = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(roles.ToList());

            return mapped;
        }


        [HttpPut]
        public void Put(RoleViewModel roleViewModel)
        {
            var role = _mapper.Map<RoleViewModel, Role>(roleViewModel);
            var permissions = _mapper.Map<List<PermissionViewModel>, List<Permission>>(roleViewModel.Permissions.ToList());

            _context.Roles.Update(role);

            role = _context.Roles.Where(x => x.RoleId == role.RoleId).Include(x => x.RolePermissions).ThenInclude(x => x.Permission).FirstOrDefault();

            foreach (var rolePermission in role.RolePermissions.ToList())
            {
                // Remove the rolepermission which are not in the list of new permission
                if (!permissions.Any(x => x.PermissionId == rolePermission.Permission.PermissionId))
                {
                    role.RolePermissions.Remove(rolePermission);
                }
                  
            }

            foreach (var permission in permissions)
            {
                // Add the permission which are not in the list of roles's permission
                if (!role.RolePermissions.Any(r => r.PermissionId == permission.PermissionId))
                {
                    var newRolePermission = new RolePermission { RoleId = role.RoleId, PermissionId = permission.PermissionId };
                    role.RolePermissions.Add(newRolePermission);
                }
               
            }

            _context.SaveChangesAsync();


        }




        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<UserViewModel>> Get()
        //{
        //    var users = _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).ThenInclude(x => x.RolePermissions).ThenInclude(x => x.Permission).ToList();

        //    var mapped = _mapper.Map<List<User>, List<UserViewModel>>(users);

        //    return mapped;
        //}



        //// POST api/values
        //[HttpPost]
        //public void Post()
        //{
        //    var permission1 = new Permission() { Name = "Read" };
        //    var permission2 = new Permission() { Name = "Write" };
        //    var permission3 = new Permission() { Name = "Create" };
        //    var permission4 = new Permission() { Name = "Update" };
        //    List<Permission> permissions = new List<Permission>() { permission1, permission2, permission3, permission4 };
        //    _context.Permissions.AddRangeAsync(permissions);


        //    var role1 = new Role() { Name = "Admin" };
        //    role1.RolePermissions = new List<RolePermission>
        //    {
        //        new RolePermission { Role = role1, Permission = permission1},
        //        new RolePermission { Role = role1, Permission = permission2},
        //        new RolePermission { Role = role1, Permission = permission3},
        //        new RolePermission { Role = role1, Permission = permission4},
        //    };

        //    _context.Roles.AddAsync(role1);

        //    var role2 = new Role() { Name = "Regular" };
        //    role2.RolePermissions = new List<RolePermission>
        //    {
        //        new RolePermission { Role = role2, Permission = permission1}
        //    };
        //    _context.Roles.AddAsync(role2);


        //    var userStatus1 = new UserStatus() { Name = "Active" };
        //    _context.UserStatuses.Add(userStatus1);

        //    var userStatus2 = new UserStatus() { Name = "Pending" };
        //    _context.UserStatuses.Add(userStatus2);

        //    var user1 = new User() { FirstName = "Hani", LastName = "Saad", Status = userStatus1 };
        //    user1.UserRoles = new List<UserRole>
        //    {
        //        new UserRole { User = user1, Role = role1},
        //        new UserRole { User = user1, Role = role2},
        //    };
        //    _context.Users.AddAsync(user1);

        //    var user2 = new User() { FirstName = "Lindsey", LastName = "Saad", Status = userStatus2 };
        //    user2.UserRoles = new List<UserRole>
        //    {
        //        new UserRole { User = user2, Role = role2}
        //    };
        //    _context.Users.AddAsync(user2);



        //    _context.SaveChangesAsync();
        //}

    }
}
