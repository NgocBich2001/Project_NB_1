using System;
using Grocery.Utiility;

namespace Grocery
{
    class Program
    {
        static void Main(string[] args)
        {
            LogIn lg = new LogIn();
            bool ok = lg.HienThi(10, 5, "1", "1");
            if (ok)
            {
                HienThi();
            }
            else
                Environment.Exit(0);
        }
        public static void HienThi()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                "F1: Loại hàng",
                "F2: Hàng hóa",
                "F3: Giá bán",
                "F4: Nhà cung cấp",
                "F5: Nhân viên",
                "F6: Hóa đơn nhập",
                "F7: Hóa đơn nhập chi tiết",
                "F8: Hóa đơn bán",
                "F9: Hóa đơn bán chi tiết",
                "F10: Kết thúc"
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.ReadKey();
        }    
    }
}
