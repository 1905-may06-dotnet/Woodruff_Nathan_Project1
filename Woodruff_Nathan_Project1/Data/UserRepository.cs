using Data.Entities;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _db;
        public UserRepository(Context db)
        {
            _db = db;
        }

        public void Add(Domain.User user)
        {
            _db.Users.Add(Mapper.Map(user));
        }

        public void Edit(Domain.User user)
        {
            if (_db.Users.Find(user.id) != null)
            {
                _db.Users.Update(Mapper.Map(user));
            }

        }

        public void Delete(int id)
        {

            var record = _db.Users.Where(q => q.Id == id).FirstOrDefault();

            if (record != null)
            {
                _db.Users.Remove(record);
            }
        }

        public IEnumerable<Domain.User> GetUsers()
        {
            return _db.Users.Select(r => Mapper.Map(r)).ToList();
        }

        public Domain.User GetUserByName(string username)
        {
            var record = _db.Users.Where(q => q.Username == username).FirstOrDefault();

            if (record != null)
            {
                return Mapper.Map(record);
            }
            else
            {
                return null;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
