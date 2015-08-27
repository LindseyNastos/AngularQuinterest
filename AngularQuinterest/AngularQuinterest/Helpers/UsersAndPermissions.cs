using AngularQuinterest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AngularQuinterest.Helpers
{
    public class UsersAndPermissions
    {
        public string DisplayName { get; set; }
        public Boolean UserClaim { get; set; }
    }
}