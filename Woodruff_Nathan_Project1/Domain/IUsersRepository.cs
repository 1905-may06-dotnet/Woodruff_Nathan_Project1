using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IUserRepository
    {

        //CRUD Operations
        //These are the domain entities

        void Add(User user);

        void Edit(User user);

        void Delete(int id);

        IEnumerable<User> GetUsers();

        User GetUserByName(string username);

        void Save();

    }
}
