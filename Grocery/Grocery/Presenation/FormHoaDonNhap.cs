using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;
using System.Collections.Generic;

namespace Grocery.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormHoaDonNhap
    {
        public void Nhap()
        {
            do
            {
                IFHoaDonNhapBLL hdn = new HoaDonNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 15, 100);
                IO.Writexy("Mã nhà cung cấp:", 5, 4);
                IO.Writexy("Nhân viên giao:", 5, 6);
                IO.Writexy("Mã nhân viên nhận:", 5, 8);
                IO.Writexy("Ngày nhận: ",39,8);
                IO.Writexy("Mã hàng:",5,10);
                IO.Writexy("Số lượng:",25,10);
                IO.Writexy("Đơn giá nhập:",40,10);
                IO.Writexy("Thành tiền:",5,12);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 13);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 14);
                Hien(1, 16, hdn.XemDSHoaDonNhap(), 5, 0);
                HoaDonNhap hoadn = new HoaDonNhap();
                do
                {
                    hoadn.mancc = int.Parse(IO.ReadNumber(22, 4));
                    if(hoadn.mancc<0)
                    {
                        IO.Clear(5, 14, 111, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!",5,14);
                    }    
                } while (hoadn.mancc < 0);
                IO.Clear(5, 14, 111, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 14);
                do
                {
                    hoadn.nvgiao = IO.ReadString(21, 6);
                    if (hoadn.nvgiao == null)
                    {
                        IO.Clear(5, 14, 111, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 14);
                    }
                } while (hoadn.nvgiao == null);
                do
                {
                    hoadn.manvnhan = int.Parse(IO.ReadNumber(25, 8));
                    if (hoadn.manvnhan < 0)
                    {
                        IO.Clear(5, 14, 111, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 14);
                    }
                } while (hoadn.manvnhan < 0);
                do
                {
                    hoadn.ngaynhan = IO.ReadString(52, 8);
                    if (hoadn.ngaynhan == null)
                    {
                        IO.Clear(5, 14, 111, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 14);
                    }
                } while (hoadn.ngaynhan == null);
                do
                {
                    hoadn.mahang = int.Parse(IO.ReadNumber(13, 10));
                    if (hoadn.mahang < 0)
                    {
                        IO.Clear(5, 14, 111, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 14);
                    }
                } while (hoadn.mahang < 0);
                do
                {
                    hoadn.soluong = int.Parse(IO.ReadNumber(35, 10));
                    if (hoadn.soluong < 0)
                    {
                        IO.Clear(5, 14, 111, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 14);
                    }
                } while (hoadn.soluong < 0);
                do
                {
                    hoadn.gianhap = double.Parse(IO.ReadNumber(54, 10));
                    if (hoadn.gianhap < 0)
                    {
                        IO.Clear(5, 14, 111, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 14);
                    }
                } while (hoadn.gianhap < 0);
                IO.Writexy(hoadn.thanhtien.ToString(), 17, 12);
                Console.SetCursorPosition(55, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, hdn.XemDSHoaDonNhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    hdn.ThemHoaDonNhap(hoadn);
            } while (true);
        }
        public void Sua()
        {
            IFHoaDonNhapBLL hdn = new HoaDonNhapBLL();
            HoaDonNhapBLL HDNBLL = new HoaDonNhapBLL();
            Console.Clear();
            IO.BoxTitle("                                   SỬA THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 15, 100);
            IO.Writexy("Mã hóa đơn nhập:", 5, 4);
            IO.Writexy("Mã nhà cung cấp:", 40, 4);
            IO.Writexy("Nhân viên giao:", 5, 6);
            IO.Writexy("Mã nhân viên nhận:", 5, 8);
            IO.Writexy("Ngày nhận: ", 40, 8);
            IO.Writexy("Mã hàng:", 5, 10);
            IO.Writexy("Số lượng:", 25, 10);
            IO.Writexy("Đơn giá nhập:", 40, 10);
            IO.Writexy("Thành tiền:", 5, 12);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 13);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 14);
            Hien(1, 16, hdn.XemDSHoaDonNhap(), 5, 0);

            int mahdn;
            int mancc;
            string nvgiao;
            int manvnhan;
            string ngaynhan;
            int mahang;
            int soluong;
            double gianhap;
            do
            {
                mahdn = int.Parse(IO.ReadNumber(23, 4));
                if (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false)
                {
                    IO.Clear(5, 14, 80, ConsoleColor.Black);
                    IO.Writexy("Không tồn tại mã hóa đơn nhập này. Vui lòng kiểm tra lại!", 5, 14);
                }
            } while (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false);
            HoaDonNhap hdnhap = hdn.LayHoaDonNhap(mahdn);
            IO.Writexy(hdnhap.mancc.ToString(),58, 4);
            IO.Writexy(hdnhap.nvgiao, 21, 6);
            IO.Writexy(hdnhap.manvnhan.ToString(), 25, 8);
            IO.Writexy(hdnhap.ngaynhan, 50, 8);
            IO.Writexy(hdnhap.mahang.ToString(), 13, 10);
            IO.Writexy(hdnhap.soluong.ToString(), 35, 10);
            IO.Writexy(hdnhap.gianhap.ToString(), 54, 10);

            mancc = int.Parse(IO.ReadNumber(58, 4));
            if (mancc != hdnhap.mancc && mancc > 0)
                hdnhap.mancc = mancc;
            nvgiao = IO.ReadString(21, 6);
            if (nvgiao != hdnhap.nvgiao && nvgiao != null)
                hdnhap.nvgiao = nvgiao;
            manvnhan = int.Parse(IO.ReadNumber(25, 8));
            if (manvnhan != hdnhap.manvnhan && manvnhan > 0)
                hdnhap.manvnhan = manvnhan;
            ngaynhan = IO.ReadString(50, 8);
            if (ngaynhan != hdnhap.ngaynhan && ngaynhan != null)
                hdnhap.ngaynhan = ngaynhan;
            mahang = int.Parse(IO.ReadNumber(13, 10));
            if (mahang != hdnhap.mahang && mahang > 0)
                hdnhap.mahang = mahang;
            soluong = int.Parse(IO.ReadNumber(35, 10));
            if (soluong != hdnhap.soluong && soluong > 0)
                hdnhap.soluong = soluong;
            gianhap = double.Parse(IO.ReadNumber(54, 10));
            if (gianhap != hdnhap.gianhap && gianhap > 0)
                hdnhap.gianhap = gianhap;
            IO.Writexy(hdnhap.thanhtien.ToString(), 17, 12);

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 16, hdn.XemDSHoaDonNhap(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdn.SuaHoaDonNhap(hdnhap);
                Hien(1, 16, hdn.XemDSHoaDonNhap(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int mahdn = 0;
            do
            {
                Console.Clear();
                IFHoaDonNhapBLL hdn = new HoaDonNhapBLL();
                HoaDonNhapBLL HDNBLL = new HoaDonNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                  XÓA HÓA ĐƠN NHẬP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn nhập cần xóa:", 5, 4);
                Hien(1, 8, hdn.XemDSHoaDonNhap(), 5, 0);
                do
                {
                    mahdn = int.Parse(IO.ReadNumber(35, 4));
                    if (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã hóa đơn nhập này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                        hdn.XoaHoaDonNhap(mahdn);
                    Console.Clear();
                    Hien(1, 8, hdn.XemDSHoaDonNhap(), 5, 1);
                } while (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false);
            } while (true);
        }
        public void Xem()
        {
            IFHoaDonNhapBLL hdn = new HoaDonNhapBLL();
            Console.Clear();
            Hien(1, 1, hdn.XemDSHoaDonNhap(), 5, 1);
            HienChucNang();
        }
        
        public void TimMa()
        {
            int mahdn = 0;
            do
            {
                Console.Clear();
                IFHoaDonNhapBLL hdn = new HoaDonNhapBLL();
                HoaDonNhapBLL HDNBLL = new HoaDonNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                TÌM KIẾM HÓA ĐƠN NHẬP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn nhập cần tìm:", 5, 4);
                Hien(1, 8, hdn.XemDSHoaDonNhap(), 5, 0);
                do
                {
                    mahdn = int.Parse(IO.ReadNumber(35, 4));
                    if (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã hóa đơn nhập này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<HoaDonNhap> list = hdn.TimHoaDonNhap(new HoaDonNhap(mahdn, 0, null, 0, null, 0, 0, 0, 0));
                        Hien(1, 8, list, 5, 1);
                    }    
                } while (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false);
            } while (true);
        }
        public void Hien(int xx, int yy, List<HoaDonNhap> list, int n, int type)
        {
            int head = 0;
            int curpage = 1;
            int totalpage = list.Count % n == 0 ? list.Count / n : list.Count / n + 1;
            int final = list.Count <= n ? list.Count : n;
            int x, y, d;
            do
            {
                IO.Clear(xx, yy, 1800, ConsoleColor.Black);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                                   DANH SÁCH HÓA ĐƠN NHẬP", x, y);
                IO.Writexy("┌────────┬─────────┬────────────────┬────────────┬────────────┬───────────┬──────────┬──────────┬─────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDN │ Mã NCC  │ Nhân viên giao │ Mã NV nhận │ Ngày nhận  │ Mã hàng   │ Số lượng │ Giá nhập │ Thành tiền  │", x, y + 2);
                IO.Writexy("├────────┼─────────┼────────────────┼────────────┼────────────┼───────────┼──────────┼──────────┼─────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 18);
                    IO.Writexy(list[i].mahdn.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 9, y + d);
                    IO.Writexy(list[i].mancc.ToString(), x + 10, y + d, 9);
                    IO.Writexy("│", x + 19, y + d);
                    IO.Writexy(list[i].nvgiao.ToString(), x + 20,  y + d, 16);
                    IO.Writexy("│", x + 36, y + d);
                    IO.Writexy(list[i].manvnhan.ToString(), x + 37, y + d, 12);
                    IO.Writexy("│", x + 49, y + d);
                    IO.Writexy(list[i].ngaynhan.ToString(), x + 50, y + d, 12);
                    IO.Writexy("│", x + 62,  y + d);
                    IO.Writexy(list[i].mahang.ToString(), x + 63, y + d, 11);
                    IO.Writexy("│", x + 74, y + d);
                    IO.Writexy(list[i].soluong.ToString(), x + 75, y + d, 10);
                    IO.Writexy("│", x + 85, y + d);
                    IO.Writexy(list[i].gianhap.ToString(), x + 86, y + d, 10);
                    IO.Writexy("│", x + 96, y + d);
                    IO.Writexy(list[i].thanhtien.ToString(), x + 97, y + d, 13);
                    IO.Writexy("│", x + 110, y + d);
                    if (i < final - 1)
                        IO.Writexy("├────────┼─────────┼────────────────┼────────────┼────────────┼───────────┼──────────┼──────────┼─────────────┼", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└────────┴─────────┴────────────────┴────────────┴────────────┴───────────┴──────────┴──────────┴─────────────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "          Nhấn PagegUp để xem trước, PagegDown để xem tiếp, Esc để thoát...", x, y + d);
                if (type == 0)
                    break;
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.PageDown)
                {
                    if (curpage < totalpage)
                        curpage += 1;
                    else
                        curpage = 1;
                }
                else if (kt.Key == ConsoleKey.PageUp)
                {
                    if (curpage > 1)
                        curpage -= 1;
                    else
                        curpage = totalpage;
                }
                else if (kt.Key == ConsoleKey.Escape)
                    break;
            } while (true);
        }
        public void HienChucNang()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {

                Console.Clear();

                IO.BoxTitle("  *** CÁC CHỨC NĂNG CỦA HÓA ĐƠN NHẬP ***         ", 5, 1, 20, 56);
                IO.Writexy("*       1. Thêm hóa đơn nhập.              *", 12, 5);
                IO.Writexy("*                                          *", 12, 6);
                IO.Writexy("*       2. Sửa hóa đơn nhập.               *", 12, 7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*       3. Xóa hóa đơn nhập.               *", 12, 9);
                IO.Writexy("*                                          *", 12, 10);
                IO.Writexy("*       4. Xem danh sách hóa đơn nhập.     *", 12, 11);
                IO.Writexy("*                                          *", 12, 12);
                IO.Writexy("*       5. Tìm kiếm hóa đơn nhập.          *", 12, 13);
                IO.Writexy("*                                          *", 12, 14);
                IO.Writexy("*       6. Quay lại.                       *", 12, 15);
                IO.Writexy("*                                          *", 12, 16);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *", 12, 17);
                IO.Writexy("********************************************", 12, 19);

                FormHoaDonNhap HDN = new FormHoaDonNhap();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        HDN.Nhap();
                        break;

                    case '2':
                        HDN.Sua();
                        break;

                    case '3':
                        HDN.Xoa();
                        break; 

                    case '4':
                        HDN.Xem();
                        break;

                    case '5':
                        HDN.TimMa();
                        break;

                    case '6':
                        FormMenuMain.HienThi();
                        break;
                }
            } while (true);
        }
    }
}