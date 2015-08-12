using AngularQuinterest.Models;
using AngularQuinterest.Services;
using System;
using System.Collections.Generic;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
