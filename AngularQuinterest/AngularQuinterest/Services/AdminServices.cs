using AngularQuinterest.Models;
using CoderCamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularQuinterest.Services
{
    public class AdminServices : AngularQuinterest.Services.IAdminServices
    {
        private IGenericRepository _repo;

        public AdminServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public ApplicationUser GetUser(string id)
        {
            return _repo.Find<ApplicationUser>(id);
        }
    }
}