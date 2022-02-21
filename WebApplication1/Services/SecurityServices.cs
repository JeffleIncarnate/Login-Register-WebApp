using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SecurityServices
    {
        UsersDAO usersDAO = new UsersDAO();

        public SecurityServices()
        {
            
        }

        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUderByNameAndPassword(user);

        }
    }
}
