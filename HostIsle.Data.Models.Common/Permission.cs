namespace HostIsle.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Permission
    {
        public string Id { get; set; }

        public string RoleId { get; set; }

        public ApplicationRole Role { get; set; }

        public string Action { get; set; }

        public string PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
