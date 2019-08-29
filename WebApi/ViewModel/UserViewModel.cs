using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserStatusViewModel Status { get; set; }

        public ICollection<RoleViewModel> UserRoles { get; set; }
    }
}
