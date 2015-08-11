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
            return _repo.Query<Pin>().ToList();
        }

        public Pin FindPin(int pinId)
        {
            return _repo.Query<Pin>().Where(c => c.Id == pinId).FirstOrDefault();
        }


        //public ApplicationUser FindUser(string userId)
        //{
        //    return _repo.Query<ApplicationUser>()
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.Pins)
        //        .FirstOrDefault();
        //}


        public void Create(Pin pin)
        {
            _repo.Add<Pin>(pin);
            _repo.SaveChanges();
        }


        public void PinIt(Pin pin, string userId)
        {
            var newPin = new Pin
            {
                Title = pin.Title,
                Board = pin.Board,
                BoardId = pin.BoardId,
                ImageUrl = pin.ImageUrl,
                Website = pin.Website,
                ShortDescription = pin.ShortDescription,
                LongDescription = pin.LongDescription,
                //UserId = userId
            };

            //var originalUser = this.FindUser(userId);
            //originalUser.Pins.Add(newPin);
            //temp:
            _repo.Add<Pin>(pin);

            _repo.SaveChanges();
        }


        public void Edit(int id, Pin pin)
        {
            var original = this.FindPin(id);
            original.Board = pin.Board;
            original.BoardId = pin.BoardId;
            original.ImageUrl = pin.ImageUrl;
            original.LongDescription = pin.LongDescription;
            original.ShortDescription = pin.ShortDescription;
            original.Title = pin.Title;
            //original.User = pin.User;
            //original.UserId = pin.UserId;
            original.Website = pin.Website;

            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete<Pin>(id);
            _repo.SaveChanges();
        }

    }
}