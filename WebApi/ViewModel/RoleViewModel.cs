using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModel
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<PermissionViewModel> Permissions { get; set; }
    }
}
