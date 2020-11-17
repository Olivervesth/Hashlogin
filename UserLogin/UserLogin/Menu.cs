using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class Menu
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("1.Login\n2.Signup");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                         Login();
                        break;
                    case 2:
                        // Signup();
                        break;
                    default:
                        break;
                }
            }
        }
        private void Login()
        {
            Read r = new Read();
            Console.WriteLine("UserName: ");
            string username = Console.ReadLine();
                Console.Clear();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            r.ReadUsers(StringToSaltHash(password),username);
        }
        public string StringToSaltHash(string psw)
        {
            byte[] salt = Hash.GenerateSalt();
            byte[] hashedPassword = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(psw), salt);
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
