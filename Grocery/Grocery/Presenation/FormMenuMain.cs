using System;
using Grocery.Utiility;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Grocery.Presenation;

namespace Grocery.Presenation
{
    
    public class FormMenuMain
    {
        public static void HienThi()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1: Hàng hóa.",
                " F2: Nhân viên.",
                " F3: Nhà cung cấp.",
                " F4: Hóa đơn nhập",
                " F5: Hóa đơn bán.",
                " F6: Kết thúc."
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
                FormNhanVien nhanvien = new FormNhanVien();
                FormNhaCC nhacc = new FormNhaCC();
                FormHoaDonNhap hdn = new FormHoaDonNhap();
                FormHoaDonBan hdb = new FormHoaDonBan();
                switch (vitri)
                {
                    case 0:
                        hanghoa.HienChucNang();
                        break;
                        
                    case 1:
                        nhanvien.HienChucNang();
                        break;

                    case 2:
                        nhacc.HienChucNang();
                        break;
                    case 3:
                        hdn.HienChucNang();
                        break;
                    case 4:
                        hdb.HienChucNang();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;
                }
                
            }
            
        }
    }
}
