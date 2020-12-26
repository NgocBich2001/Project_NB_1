using System;
using Grocery.Utiility;
using System.Text;
using System.Collections.Generic;

namespace Grocery.Presenation
{
    
    public class FormMenuMain
    {
        
        public void HienChucNang_TKNhap()
        {
            do
            {
                Console.Clear();
                IO.BoxTitle("          **** CÁC CHỨC NĂNG ***", 1, 1, 13, 56);
                IO.Writexy("   *  1. Thống kê khoản chi theo ngày.    *", 12, 5);
                IO.Writexy("   *  2. Thống kê khoản chi theo tháng.   *", 12, 6);
                IO.Writexy("   *  3. Thống kê khoản chi theo năm.     *", 12, 7);
                IO.Writexy("   *  4. Quay lại.                        *", 12, 8);
                IO.Writexy("   ****************************************", 12, 9);

                FormThongKe tk = new FormThongKe();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        tk.TK_NgayNhap();
                        Console.ReadKey();
                        break;
                    case '2':
                        tk.TK_ThangNhap();
                        Console.ReadKey();
                        break;

                    case '3':
                        tk.TK_NamNhap();
                        Console.ReadKey();
                        break;
                    case '4':
                        HienChucNang_TK();
                        break;
                }
            } while (true);
        }
        public void HienChucNang_TKBan()
        {
            do
            {
                Console.Clear();
                IO.BoxTitle("          **** CÁC CHỨC NĂNG ***", 1, 1, 13, 56);
                IO.Writexy("   *  1. Thống kê khoản thu theo ngày.    *", 12, 5);
                IO.Writexy("   *  2. Thống kê khoản thu theo tháng.   *", 12, 6);
                IO.Writexy("   *  3. Thống kê khoản thu theo năm.     *", 12, 7);
                IO.Writexy("   *  4. Quay lại.                        *", 12, 8);
                IO.Writexy("   ****************************************", 12, 9);

                FormThongKe ftk = new FormThongKe();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        ftk.TK_NgayBan();
                        Console.ReadKey();
                        break;
                    case '2':
                        ftk.TK_ThangBan();
                        Console.ReadKey();
                        break;
                    case '3':
                        ftk.TK_NamBan();
                        Console.ReadKey();
                        break;
                    case '4':
                        HienThi();
                        break;
                }
            } while (true);
        }
        public void HienChucNang_TK()
        {
            do
            {

                Console.Clear();
                IO.BoxTitle("         *** CÁC CHỨC NĂNG ***", 1, 1, 13, 56);
                IO.Writexy("  *      1. Thống kê khoản thu       *", 12, 5);
                IO.Writexy("  *      2. Thống kê khoản chi       *", 12, 6);
                IO.Writexy("  *      3. Thống kê lợi nhuận       *", 12, 7);
                IO.Writexy("  *      4. Quay lại                 *", 12, 8);
                IO.Writexy("  ************************************", 12, 9);

                FormThongKe tk = new FormThongKe();

                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)
                {
                    case '1':
                        HienChucNang_TKBan();
                        break;
                    case '2':
                        HienChucNang_TKNhap();
                        break;

                    //case '3':
                    //    HienChucNang_TKLoiNhuan();
                    //    break;
                    case '4':
                        HienThi();
                        break;
                }
            } while (true);
        }
        public static void HienThi()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {
                
                Console.Clear();
                
                IO.BoxTitle("             *** CÁC CHỨC NĂNG ***         ", 5, 1, 22, 56);
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
                IO.Writexy("*       6. Thống kê.                       *", 12, 15);
                IO.Writexy("*                                          * ", 12, 16);
                IO.Writexy("*       7. Thoát.                          *",  12,  17);
                IO.Writexy("*                                          *",  12,  18);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *",  12,  19);
                IO.Writexy("********************************************", 12, 20);

                FormHangHoa hanghoa = new FormHangHoa();
                FormNhanVien nhanvien = new FormNhanVien();
                FormNhaCC nhacc = new FormNhaCC();
                FormHoaDonNhap hdn = new FormHoaDonNhap();
                FormHoaDonBan hdb = new FormHoaDonBan();
                FormMenuMain fm = new FormMenuMain();
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
                        fm.HienChucNang_TK();
                        break;
                    case '7':
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}
