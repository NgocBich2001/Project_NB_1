using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Utiility
{
    class LogIn
    {
        private string User;
        private string Password;
        public LogIn()
        {
            User = "";
            Password = "";
        }    
        public LogIn(string user, string pass)
        {
            this.User = user;
            this.Password = pass;
        }    
        public string user
        {
            get
            {
                return User;
            }    
            set
            {
                if (value != "")
                    User = value;
            }    
        }
        public string pass
        {
            get
            {
                return Password;
            }    
            set
            {
                if (value != "")
                    Password = value;
            }    
        }
        public bool HienThi(int x, int y, string user, string password)
        {
            IO.BoxTitle("DANG NHAP", x, y, 15, 60);
            IO.Writexy("User: ", x + 3, y + 5);
            IO.Writexy("Password: ", x + 3, y + 8);
            IO.Writexy("Dang Nhap", x + 40, y + 10);
            IO.Writexy("Ngam dinh(User: 1- Password: 1)", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
            IO.Writexy("                               ", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            do
            {
                this.User = IO.ReadString(x + 9, y + 5);
                this.Password = IO.ReadPassword(x + 14, y + 8);
                IO.Writexy("Nhan Enter de dang nhap hoac nhan phim ESC de thoat!", x + 2, y + 12);
                IO.Writexy("Dang nhap", x + 40, y + 10, ConsoleColor.Blue, ConsoleColor.White);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter)
                {
                    if (this.User == user && this.Password == pass)
                        return true;
                    else
                    {
                        IO.Clear(x + 2, y + 12, 55, ConsoleColor.Black);
                        IO.Writexy("Tai khoan hoac mat khau sai, xin vui long nhap lai!", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
                        IO.Clear(x + 15, y + 5, 30, ConsoleColor.Black);
                        IO.Clear(x + 15, y + 8, 30, ConsoleColor.Black);
                    }
                }
                else
                    return false;
            } while (true);
        }
    }
}
