using dars.Models;
using System;
using System.Collections.Generic;

namespace dars.IRepositories
{
    internal interface IUserRepository
    {
        User Create(User user);
        User Update(User user, string username);
        bool Delete(string username);
        User Get(string username);
        List<User> GetAll();
        bool CheckForExist(string username, string password);
    }
}
