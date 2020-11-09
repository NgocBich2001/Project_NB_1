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
            /*LogIn lg = new LogIn();
            bool ok = lg.HienThi(10, 5, "1", "1");
            if (ok)
            {
                  FormMenuMain.HienThi();
            }
            else
                Environment.Exit(0);*/

            FormMenuMain.HienThi();
        }
            
    }
}
