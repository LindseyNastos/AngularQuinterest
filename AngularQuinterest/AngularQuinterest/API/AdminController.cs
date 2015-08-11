using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace AngularQuinterest.API
{
    public class AdminController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/admin/isAdmin")]
        // GET: api/Admin
        public bool IsAdmin()
        {
            var user = this.User as ClaimsPrincipal;
            return user.HasClaim("IsAdmin", "true");
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
