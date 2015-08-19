using AngularQuinterest.Models;
using CoderCamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularQuinterest.Services
{
    public class UserServices : AngularQuinterest.Services.IUserServices
    {
        private IGenericRepository _repo;

        public UserServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public ApplicationUser Profile(string id)
        {
            return _repo.Query<ApplicationUser>()
                .Include(u => u.Boards)
                .Include(u => u.Pins)
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public IList<Pin> PinsOnBoard(int boardId)
        {
            return _repo.Query<Pin>().Where(p => p.BoardId == boardId).ToList();
        }

    }
}