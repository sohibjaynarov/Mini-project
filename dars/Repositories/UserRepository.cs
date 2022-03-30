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
        public bool CheckForExist(string username, string password)
        {
            bool result = false;
            string[] files = Directory.GetFiles(Constants.Path);
            foreach(string file in files)
            {
                string[] data = File.ReadAllLines(file);

                if(username == data[5] && password == data[6])
                {
                    result = true;
                }
            }

            return result;
        }

        public User Create(User user)
        {
            string path = Helpers.Path(user.Id);
            string data = user.ToString();
            File.WriteAllText(path, data);

            return user;
        }

        public bool Delete(string username)
        {
            bool result = false;
            string[] files = Directory.GetFiles(Constants.Path);
            foreach (string file in files)
            {
                string[] data = File.ReadAllLines(file);

                if (username == data[5])
                {
                    File.Delete(file);
                    result = true;
                }
            }

            return result;
        }

        public User Get(string username)
        {
            User user = null;
            string[] files = Directory.GetFiles(Constants.Path);
            foreach (string file in files)
            {
                string[] data = File.ReadAllLines(file);

                if (username == data[5])
                {
                    user = new User()
                    {
                        Id = Guid.Parse(data[0]),
                        FirstName = data[1],
                        LastName = data[2],
                        Age = int.Parse(data[3]),
                        Email = data[4],
                        Username = data[5],
                        Password = data[6]
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
                string[] data = File.ReadAllLines(file);
                users.Add(new User()
                {
                    Id = Guid.Parse(data[0]),
                    FirstName = data[1],
                    LastName = data[2],
                    Age = int.Parse(data[3]),
                    Email = data[4],
                    Username = data[5],
                    Password = data[6]
                });
            }

            return users;
        }

        public User Update(User user, string username)
        {
            string[] files = Directory.GetFiles(Constants.Path);
            foreach (string file in files)
            {
                string[] data = File.ReadAllLines(file);
                if (username == data[5])
                {
                    user.Id = Guid.Parse(data[0]);
                    string userData = user.ToString();
                    File.WriteAllText(file, userData);
                }
            }

            return user;
        }
    }
}
