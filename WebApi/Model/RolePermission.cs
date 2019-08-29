using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class RolePermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolePermissionId { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

    }
}
