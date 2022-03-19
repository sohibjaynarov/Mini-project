using dars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dars.IRepositories
{
    internal interface IUserRepository
    {
        User Create(User user);
        User Update(User user, int id);
        bool Delete(int id);
        User Get(int id);
        List<User> GetAll();
    }
}
