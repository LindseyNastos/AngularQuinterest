using AngularQuinterest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using AngularQuinterest.Services;

namespace AngularQuinterest.API
{
    public class AdminController : ApiController
    {
        private IAdminServices _service;

        public AdminController(IAdminServices service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        [Route("api/admin/isAdmin")]
        // GET: api/Admin
        public IHttpActionResult IsAdmin()
        {
            var claim = this.User as ClaimsPrincipal;
            var userId = this.User.Identity.GetUserId();

            var usersAndPerms = new UsersAndPermissions
            {
                DisplayName = _service.GetUser(userId).DisplayName,
                UserClaim = claim.HasClaim("IsAdmin", "true")
            };
            return Ok(usersAndPerms);
        }

        // GET: api/Admin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
