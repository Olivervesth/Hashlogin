using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Read
    {
        public void ReadUsers(string user, string psw)
        {
            if (!File.Exists(@".\users.txt"))
            {
                return;
            }
            StreamReader read = new StreamReader(@".\users.txt");
            string file = read.ReadToEnd();
            string[] split = file.Split(':', '\n');

            /* if (line.Replace(" ", "").Trim().Contains(user))
             {

                 Console.WriteLine(line.ToString());
             }*/
            string username = "";
            string password = "";
            string salt = "";
            int i = 0;
            foreach (var item in split)
            {
                if (i == 0)
                {
                    username = item.Trim();
                    i++;
                }
                else if (i == 1)
                {
                    password = item.Trim();
                    i++;
                }
                else if (i == 2)
                {
                    i = 0;
                    salt = item.Trim();
                    if (username == user)
                    {
                        // byte[] hashedPassword = Hash.HashPassword(Encoding.UTF8.GetBytes(psw)); Encoding.UTF8.GetBytes(salt,0,32)
                        byte[] slt = Encoding.UTF8.GetBytes("9OsAQ2AjT7PmxDRowN43m6WX/HQVb6sJkHxVtFfnPVs=");
                        var Completecode = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(psw),slt);
                        string temp = Convert.ToBase64String(Completecode);
                        if (temp == password)
                        {
                            Console.WriteLine("You have logged in");
                        }
                    }
                }

            }

        }
    }
}
