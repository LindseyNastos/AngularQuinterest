﻿using System;
namespace AngularQuinterest.Services
{
    public interface IPinServices
    {
        void Create(AngularQuinterest.Models.Pin pin, string userId);
        void Delete(int id);
        void Edit(int id, AngularQuinterest.Models.Pin pin);
        AngularQuinterest.Models.Pin FindPin(int pinId);
        AngularQuinterest.Models.ApplicationUser FindUser(string userId);
        AngularQuinterest.Models.Pin PinIt(AngularQuinterest.Models.Pin pin, string userId, int boardId);
        System.Collections.Generic.IList<AngularQuinterest.Models.Pin> PinList();
        int UpdatePinCount(int boardId);
    }
}
