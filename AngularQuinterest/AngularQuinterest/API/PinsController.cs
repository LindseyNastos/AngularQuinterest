using AngularQuinterest.Models;
using AngularQuinterest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AngularQuinterest.API
{
    public class PinsController : ApiController
    {
        private IPinServices _service;

        public PinsController(IPinServices service)
        {
            _service = service;
        }

        // GET: api/Pins
        public IEnumerable<Pin> Get()
        {
            return _service.PinList();
        }

        // GET: api/Pins/5
        public Pin Get(int id)
        {
            return _service.FindPin(id);
        }

        // POST: api/Pins
        public HttpResponseMessage Post(Pin pin)
        {
           //var userId = ?!?!?

            if (ModelState.IsValid)
            {
                if (pin.Id == 0)
                {
                    _service.Create(pin);

                    return Request.CreateResponse(HttpStatusCode.Created, pin);
                }

                //else if (pin.UserId == userId)
                //{
                //    _service.PinIt(pin, userId);

                //    return Request.CreateResponse(HttpStatusCode.Created, pin);
                //}

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
