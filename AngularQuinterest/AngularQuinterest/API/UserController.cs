using AngularQuinterest.Models;
using AngularQuinterest.Services;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularQuinterest.Models.DataModels;

namespace AngularQuinterest.API
{
    public class UserController : ApiController
    {

        private IUserServices _userService;
        private IPinServices _pinService;

        public UserController(IUserServices userService, IPinServices pinService)
        {
            _userService = userService;
            _pinService = pinService;
        }

        // GET: api/User
        public ApplicationUser Get()
        {
            var id = this.User.Identity.GetUserId();
            return _userService.Profile(id);
        }

        // GET: api/User/5
        public IList<Pin> Get(int id)
        {
            return _userService.PinsOnBoard(id);
        }

        // POST: api/User
        public HttpResponseMessage Post(PinItDataModel data)
        {
            var userId = this.User.Identity.GetUserId();
            var pin = _pinService.FindPin(data.PinId);
            var newPin = _pinService.PinIt(pin, userId, data.BoardId);

            return Request.CreateResponse(HttpStatusCode.Created, newPin);
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
