using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Utiility
{
    class DangNhap
    {
        private string User;
        private string Password;
        public DangNhap()
        {
            User = "";
            Password = "";
        }    
        public DangNhap(string user, string pass)
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
            IO.BoxTitle("    ***ĐĂNG NHẬP***", x, y, 15, 60);
            IO.Writexy("User: ", x + 3, y + 5);
            IO.Writexy("Password: ", x + 3, y + 8);
            IO.Writexy("Đăng nhập!", x + 40, y + 10);
            IO.Writexy("Ngầm định(User: 14- Password: 5)", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
            IO.Writexy("                               ", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
            do
            {
                this.User = IO.ReadString(x + 9, y + 5);
                this.Password = IO.ReadPassword(x + 14, y + 8);
                IO.Writexy("Nhấn Enter để nhập hoặc nhấn phím Esc để thoát!", x + 2, y + 12);
                IO.Writexy("Đăng nhập!", x + 40, y + 10, ConsoleColor.Blue, ConsoleColor.White);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter)
                {
                    if (this.User == user && this.Password == pass)
                        return true;
                    else
                    {
                        IO.Clear(x + 2, y + 12, 55, ConsoleColor.Black);
                        IO.Writexy("Tài khoản hoặc mật khẩu bạn đăng nhập sai. Xin vui lòng nhập lại!", x + 2, y + 12, ConsoleColor.Black, ConsoleColor.White);
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
