using AngularQuinterest.Models;
using AngularQuinterest.Services;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Security.Claims;

namespace AngularQuinterest.API
{
    [Authorize]
    public class PinsController : ApiController
    {
        private IPinServices _service;

        public PinsController(IPinServices service)
        {
            _service = service;
        }

        // GET: api/Pins
 
        public HttpResponseMessage Get()
        {
            var pins = _service.PinList(); 

            return Request.CreateResponse(HttpStatusCode.OK, pins);
        }

        // GET: api/Pins/5
        public Pin Get(int id)
        {
            return _service.FindPin(id);
        }

        // POST: api/Pins
        public HttpResponseMessage Post(Pin pin)
        {
            var userId = this.User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                if (pin.Id == 0)
                {
                    _service.Create(pin, userId);

                    return Request.CreateResponse(HttpStatusCode.Created, pin);
                }
                else
                {
                    _service.Edit(pin.Id, pin);
                    return Request.CreateResponse(HttpStatusCode.OK, pin);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT: api/Pins/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pins/5
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
