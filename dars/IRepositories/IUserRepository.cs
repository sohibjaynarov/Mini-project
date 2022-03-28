using dars.Models;
using System;
using System.Collections.Generic;

namespace dars.IRepositories
{
    internal interface IUserRepository
    {
        User Create(User user);
        User Update(User user, Guid id);
        bool Delete(Guid id);
        User Get(Guid id);
        List<User> GetAll();
    }
}
