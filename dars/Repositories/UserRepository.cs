using dars.IRepositories;
using dars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dars.Repositories
{
    internal class UserRepository : IUserRepository
    {
        List<User> users = new List<User>();

        public User Create(User user)
        {
            user.Id =  users.Count + 1;
            users.Add(user);
            return user;
        }

        public bool Delete(int id)
        {
            User myUser = users.Find(p => p.Id == id);
            if (myUser == null)
                return false;

            users.Remove(myUser);
            return true;

        }

        public User Get(int id)
        {
            return users.Find(p => p.Id == id);
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User Update(User user, int id)
        {
            User myUser = users.Find(p => p.Id == id);

            if(myUser == null)
                return null;

            user.Id = id;

            users.Remove(myUser);

            users.Add(user);
            return myUser;
        }
    }
}
