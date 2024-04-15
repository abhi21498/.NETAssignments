using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDBWebAPI.Interface;
using MongoDBWebAPI.Models;

namespace MongoDBWebAPI
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<User> _user;

        public UsersService(IOptions<MongoDBConnection> settings, IMongoClient mongoClient) {
            var db = mongoClient.GetDatabase(settings.Value.Database);
            _user=db.GetCollection<User>(settings.Value.CollectionName);
        }
        public User CreateUser(User user)
        {
            _user.InsertOne(user);
            return user;

        }

        public void DeleteUser(string id)
        {
            _user.DeleteOne(x=>x.Id==id);

        }

        public List<User> GetAllUsers()
        {
           return _user.Find(x=>true).ToList();
        }

        public User GetUserById(string id)
        {
            return _user.Find(x=>x.Id==id).FirstOrDefault();
        }

        public void UpdateUser(string id, User user)
        {
            _user.ReplaceOne(x=>x.Id==id, user);
        }
    }
}
