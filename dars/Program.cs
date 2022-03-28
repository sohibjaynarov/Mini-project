using dars.IRepositories;
using dars.Models;
using dars.Repositories;

namespace dars
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IUserRepository repo = new UserRepository();

            User user = new User()
            {
                FirstName = "Sohib",
                LastName = "Jaynarov"
            };


            //repo.Create(user);

            //repo.Delete(0);

            //User user1 = repo.Get(10);

            //if(user1 != null)
            //    Console.WriteLine(user1.FirstName + " " + user1.LastName);
            //else
            //    Console.WriteLine("Bunday foydalanuvchi mavjud emas!");

            //List<User> users = repo.GetAll();

            //foreach(User user1 in users)
            //    Console.WriteLine(user1.FirstName + " " + user1.LastName);

            // repo.Update(user, 0);



        }
    }
}


