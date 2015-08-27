using AngularQuinterest.Models;
using CoderCamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularQuinterest.Services
{
    public class PinServices : AngularQuinterest.Services.IPinServices
    {
        private IGenericRepository _repo;

        public PinServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        

        public IList<Pin> PinList()
        {
            return _repo.Query<Pin>().OrderBy(p => Guid.NewGuid()).ToList();
            
        }

        public Pin FindPin(int pinId)
        {
            return _repo.Query<Pin>().Include(p => p.Board).Where(p => p.Id == pinId).FirstOrDefault();
        }

        //public Board FindBoard(int boardId)
        //{
        //    return _repo.Query<Board>()
        //        .Where(b => b.Id == boardId)
        //        .Include(b => b.Pins)
        //        .FirstOrDefault();
        //}

        //public ApplicationUser FindUser(string userId)
        //{
        //    return _repo.Query<ApplicationUser>()
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.Pins)
        //        .FirstOrDefault();
        //}



        public int UpdatePinCount(int boardId)
        {
            var count = _repo.Query<Pin>()
                .Where(p => p.BoardId == boardId)
                .Count();
            var board = _repo.Find<Board>(boardId);
            board.NumPinsOnBoard = count;
            _repo.SaveChanges();
            return count;
        }


        public void Create(Pin pin, string userId)
        {
            pin.UserId = userId;
            _repo.Add<Pin>(pin);
            _repo.SaveChanges();
            var boardId = pin.BoardId;
            this.UpdatePinCount(boardId);
        }


        public Pin PinIt(Pin pin, string userId, int boardId)
        {
            var newPin = new Pin
            {
                Title = pin.Title,
                BoardId = pin.BoardId,
                ImageUrl = pin.ImageUrl,
                Website = pin.Website,
                ShortDescription = pin.ShortDescription,
                LongDescription = pin.LongDescription,
                UserId = userId
            };

            _repo.Add<Pin>(pin);
            _repo.SaveChanges();
            this.UpdatePinCount(boardId);

            return newPin;

        }


        public void Edit(int id, Pin pin)
        {
            var original = this.FindPin(id);
            var originalBoardId = original.BoardId;
            original.BoardId = pin.BoardId;
            original.ImageUrl = pin.ImageUrl;
            original.LongDescription = pin.LongDescription;
            original.ShortDescription = pin.ShortDescription;
            original.Title = pin.Title;
            original.UserId = pin.UserId;
            original.Website = pin.Website;

            _repo.SaveChanges();

            if (originalBoardId != pin.BoardId)
            {
                this.UpdatePinCount(originalBoardId);
                this.UpdatePinCount(pin.BoardId);
            }
        }

        public void Delete(int id)
        {
            var board = this.FindPin(id).Board;

            _repo.Delete<Pin>(id);
            _repo.SaveChanges();

            this.UpdatePinCount(board.Id);
        }

    }
}