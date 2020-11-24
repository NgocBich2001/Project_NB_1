using System;
using Grocery.Presenation;
using Grocery.Utiility;
using System.Text;

namespace Grocery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            DangNhap lg = new DangNhap();
            bool ok = lg.HienThi(10, 5, "14", "5");
            if (ok)
            {
                FormMenuMain.HienThi();
            }
            else
                Environment.Exit(0);
        }
            
    }
}
