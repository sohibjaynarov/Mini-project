using dars.IRepositories;
using dars.Models;
using dars.Service;
using Newtonsoft.Json;
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
            string data = File.ReadAllText(Constants.Path);

            List<User> users = JsonConvert.DeserializeObject<List<User>>(data);

            foreach (var user in users)
            {

                if (username == user.Username && password == user.Password)
                {
                    result = true;
                }
            }

            return result;
        }

        public User Create(User user)
        {
            IList<User> users = new List<User>();

            string data = File.ReadAllText(Constants.Path);

            users = JsonConvert.DeserializeObject<IList<User>>(data);

            users.Add(user);

            string json = JsonConvert.SerializeObject(users);

            File.WriteAllText(Constants.Path, json);

            return user;
        }

        public bool Delete(string password)
        {
            bool result = false;

            string data = File.ReadAllText(Constants.Path);

            IList<User> users = new List<User>();

            users = JsonConvert.DeserializeObject<IList<User>>(data);


            foreach (var user in users)
            {
                if(password == user.Password)
                {
                    users.Remove(user);
                    result=true;

                    break;
                }
            }
            string json = JsonConvert.SerializeObject(users);

            File.WriteAllText(Constants.Path, json);

            
            return result;
        }

        public User Get(string username)
        {
            User result = null;

            string data = File.ReadAllText(Constants.Path);

            IList<User> users = JsonConvert.DeserializeObject<IList<User>>(data);

            foreach (var user in users)
            {

                if (username == user.Username)
                {
                    result = user;
                }
            }

            return result;
        }

        public List<User> GetAll()
        {
            string data = File.ReadAllText(Constants.Path);

            List<User> users = JsonConvert.DeserializeObject<List<User>>(data);

            return users;
        }

        public User Update(User user, string username)
        {
            string data = File.ReadAllText(Constants.Path);

            IList<User> users = JsonConvert.DeserializeObject<IList<User>>(data);

            foreach (User myUser in users)
            {
                if (myUser.Username == username)
                {
                    user.Id = myUser.Id;
                    users.Remove(myUser);
                    users.Add(user);
                    break;
                }
            }
            string json = JsonConvert.SerializeObject(users);

            File.WriteAllText(Constants.Path, json);

            return user;
        }
    }
}