using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Read
    {
        public void ReadUsers(string psw, string user)
        {
            if (!File.Exists(@".\users.txt"))
            {
                return;
            }
            StreamReader read = new StreamReader(@".\users.txt");
            string line;
            while((line = read.ReadLine()) !=null)
            {
                if (line.Replace(" ","").Trim() == $"{user}:{psw}")
                {
                    Console.WriteLine(line.ToString());
                }
            }

        }
    }
}
