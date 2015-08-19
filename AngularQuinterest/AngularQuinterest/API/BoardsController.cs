using AngularQuinterest.Models;
using AngularQuinterest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularQuinterest.API
{
    //[Authorize]
    public class BoardsController : ApiController
    {
        private IBoardServices _service;

        public BoardsController(IBoardServices service)
        {
            _service = service;
        }

        // GET: api/Boards
        public IEnumerable<Board> Get()
        {
            var userId = this.User.Identity.GetUserId();
            return _service.BoardList(userId);
            
        }

        // GET: api/Boards/5
        public Board Get(int id)
        {
            return _service.FindBoard(id);
        }




        // POST: api/Boards
        public HttpResponseMessage Post(Board board)
        {
            if (ModelState.IsValid) {
                if (board.Id == 0)
                {
                    _service.Create(board);
                    return Request.CreateResponse(HttpStatusCode.Created, board);
                }
                else {
                    _service.Edit(board.Id, board);
                    return Request.CreateResponse(HttpStatusCode.OK, board);
                }

            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }


        // PUT: api/Boards/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Boards/5
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
