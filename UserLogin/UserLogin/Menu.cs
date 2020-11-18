﻿using System;
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
                        Signup();
                        break;
                    default:
                        break;
                }
            }
        }
        private void Signup()
        {
            Write w = new Write();
            Console.Write("UserName: ");
            string username = Console.ReadLine();
            Console.Clear();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            byte[] salt = Hash.GenerateSalt();
            Console.WriteLine(Convert.ToBase64String(salt));
            byte[] hashedPassword = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password),salt);
            w.SaveUser(username, Convert.ToBase64String(hashedPassword), Convert.ToBase64String(salt));
        }
        private void Login()
        {
            Read r = new Read();
            Console.Write("UserName: ");
            string username = Console.ReadLine();
            Console.Clear();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            r.ReadUsers(username,password);
        }
        public string HashPsw(string psw)
        {
            byte[] salt = Hash.GenerateSalt();
            byte[] hashedPassword = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(psw), salt);
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
