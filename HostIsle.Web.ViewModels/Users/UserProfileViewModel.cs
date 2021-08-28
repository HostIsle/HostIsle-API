namespace HostIsle.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class UserProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IFormFile Image { get; set; }
    }
}
