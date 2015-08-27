using System;
namespace AngularQuinterest.Services
{
    public interface IAdminServices
    {
        AngularQuinterest.Models.ApplicationUser GetUser(string id);
    }
}
