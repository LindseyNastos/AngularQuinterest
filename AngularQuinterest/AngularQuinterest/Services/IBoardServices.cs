using System;
namespace AngularQuinterest.Services
{
    public interface IBoardServices
    {
        System.Collections.Generic.IList<AngularQuinterest.Models.Board> BoardList(string userId);
        void Create(AngularQuinterest.Models.Board board);
        void Delete(int id);
        void Edit(int id, AngularQuinterest.Models.Board board);
        AngularQuinterest.Models.Board FindBoard(int boardId);
    }
}
