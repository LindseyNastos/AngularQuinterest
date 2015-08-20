using System;
namespace AngularQuinterest.Services
{
    public interface IUserServices
    {
        System.Collections.Generic.IList<AngularQuinterest.Models.Pin> PinsOnBoard(int boardId);
        AngularQuinterest.Models.ApplicationUser Profile(string id);
    }
}
