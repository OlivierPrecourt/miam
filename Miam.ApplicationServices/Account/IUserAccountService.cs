using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.ApplicationsServices.Account
{
    public interface IUserAccountService
    {
        MayBe<ApplicationUser> ValidateUser(string email, string password);

        string HashPassword(string password);

        bool UserEmailExist(string email);
    }
}