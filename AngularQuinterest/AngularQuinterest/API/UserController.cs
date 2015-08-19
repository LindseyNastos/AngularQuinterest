using AngularQuinterest.Models;
using AngularQuinterest.Services;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularQuinterest.API
{
    public class UserController : ApiController
    {

        private IUserServices _service;

        public UserController(IUserServices service)
        {
            _service = service;
        }

        // GET: api/User
        public ApplicationUser Get()
        {
            var id = this.User.Identity.GetUserId();
            return _service.Profile(id);
        }

        // GET: api/User/5
        public IList<Pin> Get(int id)
        {
            return _service.PinsOnBoard(id);
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
