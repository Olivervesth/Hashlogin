﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Write
    {
        public void SaveUser(string name, string psw)
        {
            if (!File.Exists(@".\users.txt"))
            {
                File.Create(@".\users.txt");
            }
            StreamWriter write = new StreamWriter(@".\users.txt",true);//Append true streamwriter lets us write to the file
            write.WriteLine(name + ":" + psw);
            write.Flush();
            write.Close();
        }

    }
}
