using dars.IRepositories;
using dars.Models;
using dars.Repositories;
using System;
using System.Collections.Generic;
using ConsoleTables;

namespace dars
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IUserRepository repo = new UserRepository();

            while(true)
            {
                Console.WriteLine("1. Sign in\n" +
                                    "2. Sign up\n" +
                                    "0. Back\n");

                Console.Write(">");
                int input = int.Parse(Console.ReadLine());

                if(input == 1)
                {
                    Console.Write("Input your username: ");
                    string username = Console.ReadLine();
                    Console.Write("Input your password: ");
                    string password = Console.ReadLine();

                    bool check = repo.CheckForExist(username, password);

                    if(check)
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Get users\n" +
                                "2. Get your data\n" +
                                "3. Update your data\n" +
                                "4. Delete account\n" +
                                "0. Back\n");

                            Console.Write(">");
                            int input_menu = int.Parse(Console.ReadLine());

                            if (input_menu == 1)
                            {
                                List<User> users = repo.GetAll();

                                var table = new ConsoleTable("Id", "First name", "Last name", "Age", "Email", "Username");

                                foreach (var user in users)
                                {
                                    table.AddRow(user.Id, user.FirstName, user.LastName, user.Age, user.Email, user.Username);
                                }

                                table.Write();
                            }
                            else if (input_menu == 2)
                            {
                                User user = repo.Get(username);

                                var table = new ConsoleTable("Id", "First name", "Last name", "Age", "Email", "Username");

                                table.AddRow(user.Id, user.FirstName, user.LastName, user.Age, user.Email, user.Username);

                                table.Write();
                            }
                            else if (input_menu == 3)
                            {
                                Console.Write("Username: ");
                                string uname = Console.ReadLine();
                                Console.Write("Password: ");
                                string pword = Console.ReadLine();
                                Console.Write("First name: ");
                                string fname = Console.ReadLine();
                                Console.Write("Last name: ");
                                string lname = Console.ReadLine();
                                Console.Write("Age: ");
                                int age = int.Parse(Console.ReadLine());
                                Console.Write("Email: ");
                                string email = Console.ReadLine();

                                User user = new User()
                                {
                                    FirstName = fname,
                                    LastName = lname,
                                    Age = age,
                                    Email = email,
                                    Username = uname,
                                    Password = pword,
                                };

                                repo.Update(user, username);
                            }
                            else if (input_menu == 4)
                            {
                                Console.Write("Input your password: ");
                                string pword = Console.ReadLine();

                                bool checkUser = repo.CheckForExist(username, pword);

                                if (checkUser)
                                {
                                    repo.Delete(username);
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect password!");
                                }
                            }
                            else if (input_menu == 0)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password!");
                    }
                }
                else if (input == 2)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    Console.Write("First name: ");
                    string firstname = Console.ReadLine();
                    Console.Write("Last name: ");
                    string lastname = Console.ReadLine();
                    Console.Write("Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    User user = new User()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Age = age,
                        Email = email,
                        Username = username,
                        Password = password,
                    };

                    User myUser = repo.Create(user);

                    if(myUser == null)
                    {
                        Console.WriteLine("Not registred!");
                    }
                    else
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Get users\n" +
                                "2. Get your data\n" +
                                "3. Update your data\n" +
                                "4. Delete account\n" +
                                "0. Back\n");

                            Console.Write(">");
                            int input_menu = int.Parse(Console.ReadLine());

                            if (input_menu == 1)
                            {
                                List<User> users = repo.GetAll();

                                var table = new ConsoleTable("Id", "First name", "Last name", "Age", "Email", "Username");

                                foreach (var user1 in users)
                                {
                                    table.AddRow(user1.Id, user1.FirstName, user1.LastName, user1.Age, user1.Email, user1.Username);
                                }

                                table.Write();
                            }
                            else if (input_menu == 2)
                            {
                                User user1 = repo.Get(username);

                                var table = new ConsoleTable("Id", "First name", "Last name", "Age", "Email", "Username");

                                table.AddRow(user1.Id, user1.FirstName, user1.LastName, user1.Age, user1.Email, user1.Username);

                                table.Write();
                            }
                            else if (input_menu == 3)
                            {
                                Console.Write("Username: ");
                                string uname = Console.ReadLine();
                                Console.Write("Password: ");
                                string pword = Console.ReadLine();
                                Console.Write("First name: ");
                                string fname = Console.ReadLine();
                                Console.Write("Last name: ");
                                string lname = Console.ReadLine();
                                Console.Write("Age: ");
                                int ageNew = int.Parse(Console.ReadLine());
                                Console.Write("Email: ");
                                string emailNew = Console.ReadLine();

                                User user1 = new User()
                                {
                                    FirstName = fname,
                                    LastName = lname,
                                    Age = ageNew,
                                    Email = emailNew,
                                    Username = uname,
                                    Password = pword,
                                };

                                repo.Update(user1, username);
                            }
                            else if (input_menu == 4)
                            {
                                Console.Write("Input your password: ");
                                string pword = Console.ReadLine();

                                bool checkUser = repo.CheckForExist(username, pword);

                                if (checkUser)
                                {
                                    repo.Delete(username);
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect password!");
                                }
                            }
                            else if (input_menu == 0)
                            {
                                break;
                            }
                        }
                    }
                }

                }
            }



        }
    }



