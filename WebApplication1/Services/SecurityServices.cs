using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SecurityServices
    {
        List<UserModel> knowsUsers = new List<UserModel>();

        public SecurityServices()
        {
            knowsUsers.Add(new UserModel { Id = 0, UserName = "Bill", Password = "bigbucks" });
            knowsUsers.Add(new UserModel { Id = 1, UserName = "Dhruv", Password = "rayatIsCool" });
            knowsUsers.Add(new UserModel { Id = 2, UserName = "Xavier", Password = "narayanIsCool" });
            knowsUsers.Add(new UserModel { Id = 3, UserName = "Bunny", Password = "bunnyIsCool" });
        }

        public bool IsValid(UserModel user)
        {

            return knowsUsers.Any( x => x.UserName == user.UserName && x.Password == user.Password );

        }
    }
}
