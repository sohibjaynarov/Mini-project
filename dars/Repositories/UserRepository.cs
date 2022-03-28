using dars.IRepositories;
using dars.Models;
using dars.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace dars.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            string path = Helpers.Path(user.Id);
            string data = user.ToString();
            File.WriteAllText(path, data);

            return user;
        }

        public bool Delete(Guid id)
        {
            bool result = false;
            string[] files = Directory.GetFiles(Constants.Path);
            foreach (string file in files)
            {
                string[] data = File.ReadAllText(file).Split();

                if (id == Guid.Parse(data[0]))
                {
                    File.Delete(file);
                    result = true;
                }
            }

            return result;
        }

        public User Get(Guid id)
        {
            User user = null;
            string[] files = Directory.GetFiles(Constants.Path);
            foreach (string file in files)
            {
                string[] data = File.ReadAllText(file).Split();

                if (id == Guid.Parse(data[0]))
                {
                    user = new User()
                    {
                        Id = Guid.Parse(data[0]),
                        FirstName = data[1],
                        LastName = data[2],
                    };
                }
            }

            return user;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            string[] files = Directory.GetFiles(Constants.Path);
            foreach (string file in files)
            {
                string[] data = File.ReadAllText(file).Split();
                users.Add(new User()
                {
                    Id = Guid.Parse(data[0]),
                    FirstName = data[1],
                    LastName = data[2],
                });
            }

            return users;
        }

        public User Update(User user, Guid id)
        {
            string[] files = Directory.GetFiles(Constants.Path);
            foreach (string file in files)
            {
                string[] data = File.ReadAllText(file).Split();
                if (id == Guid.Parse(data[0]))
                {
                    string userData = user.ToString();
                    File.WriteAllText(file, userData);
                }
            }

            return user;
        }
    }
}
