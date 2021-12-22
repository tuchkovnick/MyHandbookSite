using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Domain
{
    public class MyHandbookSiteUser : IdentityUser
    {
        public string Image { set; get; }
    }
}
