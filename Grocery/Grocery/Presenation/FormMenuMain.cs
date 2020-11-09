using System;
using Grocery.Utiility;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using ComputerStore.Presenation;

namespace Grocery.Presenation
{
    
    public class FormMenuMain
    {
        public static void HienThi()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                "F1: Hàng hóa",
                "F2: Kết thúc",
                //"F2: Hàng hóa",
                //"F4: Nhà cung cấp",
                //"F5: Nhân viên",
                //"F6: Hóa đơn nhập",
                //"F8: Hóa đơn bán",
                //"F10: Kết thúc"
            };
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuGrocery mnc = new MenuGrocery(mn);
            mnc.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuGrocery : Menu
        {
            public MenuGrocery(string[] mn) : base(mn)
            { }
            public override void ThucHien(int vitri)
            {
                FormHangHoa hanghoa = new FormHangHoa();
                switch (vitri)
                {
                    case 0:
                        hanghoa.HienChucNang();
                        break;

                    case 1:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
