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
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {
                
                Console.Clear();
                
                IO.BoxTitle("             *** CÁC CHỨC NĂNG ***         ", 5, 1, 20, 56);
                IO.Writexy("*       1. Hàng hóa.                       *", 12, 5);
                IO.Writexy("*                                          *",12, 6);
                IO.Writexy("*       2. Nhà cung cấp.                   *",  12,  7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*       3. Nhân viên.                      *",  12, 9);
                IO.Writexy("*                                          *", 12,  10);
                IO.Writexy("*       4. Hóa đơn nhập.                   *", 12,  11);
                IO.Writexy("*                                          * ", 12,  12);
                IO.Writexy("*       5. Hóa đơn bán.                    *",  12, 13);
                IO.Writexy("*                                          * ",  12,  14);
                IO.Writexy("*       6. Thoát.                          *",  12,  15);
                IO.Writexy("*                                          *",  12,  16);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *",  12,  17);
                IO.Writexy("********************************************", 12, 19);

                FormHangHoa hanghoa = new FormHangHoa();
                FormNhanVien nhanvien = new FormNhanVien();
                FormNhaCC nhacc = new FormNhaCC();
                FormHoaDonNhap hdn = new FormHoaDonNhap();
                FormHoaDonBan hdb = new FormHoaDonBan();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                
                {
                    case '1':
                        hanghoa.HienChucNang();
                        break;

                    case '2':
                        nhacc.HienChucNang();
                        break;

                    case '3':
                        nhanvien.HienChucNang();
                        break;
                    case '4':
                        hdn.HienChucNang();
                        break;
                    case '5':
                        hdb.HienChucNang();
                        break;

                    case '6':
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}
