using MongoDBWebAPI.Models;

namespace MongoDBWebAPI.Interface
{
    public interface IUsersService
    {
        public User CreateUser(User _user);
        public User GetUserById(string id);
        public void UpdateUser(string id,User _user);
         public List<User> GetAllUsers();
        public void DeleteUser(string id);
    }
}
