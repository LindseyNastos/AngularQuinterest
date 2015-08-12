using AngularQuinterest.Models;
using CoderCamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularQuinterest.Services
{
    public class BoardServices : AngularQuinterest.Services.IBoardServices
    {
        private IGenericRepository _repo;

        public BoardServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Board> BoardList()
        {
            return _repo.Query<Board>().ToList();
        }

        public Board FindBoard(int boardId)
        {
            return _repo.Query<Board>().Where(b => b.Id == boardId).FirstOrDefault();
        }

        

        public void Create(Board board)
        {
            _repo.Add<Board>(board);
            _repo.SaveChanges();
        }

        public void Edit(int id, Board board)
        {
            var original = this.FindBoard(id);
            original.BoardName = board.BoardName;
            original.Description = board.Description;
            original.ImageUrl = board.ImageUrl;
            //original.User = board.User;
            //original.UserId = board.UserId;

            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete<Board>(id);
            _repo.SaveChanges();
        }

    }
}