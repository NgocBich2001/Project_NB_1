using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.Business;
using Grocery.Business.Interface;

namespace Grocery.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Interface của Business
    public class FormLoaiHang
    {
        public void Nhap()
        {
            do
            {
                IFLoaiHangBLL loaihang = new LoaiHangBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN LOẠI MÁY", 1, 1, 10, 100);
                IO.Writexy("Tên loại máy:", 5, 4);
                IO.Writexy("Đặc điểm:", 5, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, loaihang.XemDSLoaiHang(), 5, 0);
                LoaiHang lh = new LoaiHang();
                lh.tenloai = IO.ReadString(19, 4);
                lh.dacdiem = IO.ReadString(15, 6);
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, loaihang.XemDSLoaiHang(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    loaihang.ThemLoaiHang(lh);
            } while (true);
        }
        public void Sua()
        {
            IFLoaiHangBLL loaihang = new LoaiHangBLL();
            Console.Clear();
            IO.BoxTitle("                                   CẬP NHẬT THÔNG TIN LOẠI MÁY", 1, 1, 10, 100);
            IO.Writexy("Mã loại máy:", 5, 4);
            IO.Writexy("Tên loại máy:", 40, 4);
            IO.Writexy("Đặc điểm:", 5, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, loaihang.XemDSLoaiHang(), 5, 0);

            int malh;
            string tenlh;
            string dacdiem;

            malh = int.Parse(IO.ReadNumber(18, 4));
            LoaiHang lh = loaihang.LayLoaiHang(malh);
            IO.Writexy(lh.tenloai, 54, 4);
            IO.Writexy(lh.dacdiem, 15, 6);

            tenlh = IO.ReadString(54, 4);
            if (tenlh != lh.tenloai && tenlh != null)
                lh.tenloai = tenlh;
            dacdiem = IO.ReadString(15, 6);
            if (dacdiem != lh.dacdiem && dacdiem != null)
                lh.dacdiem = dacdiem;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, loaihang.XemDSLoaiHang(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                loaihang.SuaLoaiHang(lh);
                Hien(1, 13, loaihang.XemDSLoaiHang(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int malh = 0;
            do
            {
                Console.Clear();
                IFLoaiHangBLL loaihang = new LoaiHangBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA LOẠI MÁY", 1, 1, 5, 100);
                IO.Writexy("Nhập mã loại máy cần xóa:", 5, 4);
                Hien(1, 8, loaihang.XemDSLoaiHang(), 5, 0);
                malh = int.Parse(IO.ReadNumber(31, 4));
                if (malh == 0)
                    break;
                else
                    loaihang.XoaLoaiHang(malh);
                Hien(1, 8, loaihang.XemDSLoaiHang(), 5, 1);
            } while (true);
            HienChucNang();
        }
        public void Xem()
        {
            IFLoaiHangBLL loaihang = new LoaiHangBLL();
            Console.Clear();
            Hien(1, 1, loaihang.XemDSLoaiHang(), 5, 1);
            HienChucNang();
        }
        public void TimTen()
        {
            string tenlh = "";
            do
            {
                Console.Clear();
                IFLoaiHangBLL loaihang = new LoaiHangBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM LOẠI MÁY", 1, 1, 5, 100);
                IO.Writexy("Nhập tên loại máy cần tìm:", 3, 4);
                Hien(1, 8, loaihang.XemDSLoaiHang(), 5, 0);
                tenlh = IO.ReadString(30, 4);
                List<LoaiHang> list = loaihang.TimLoaiHang(new LoaiHang(0, tenlh, null));
                Hien(1, 8, list, 5, 1);
                if (tenlh == "")
                    break;
            } while (true);
            HienChucNang();
        }
        public void TimMa()
        {
            int malh = 0;
            do
            {
                Console.Clear();
                IFLoaiHangBLL loaihang = new LoaiHangBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM LOẠI MÁY", 1, 1, 5, 100);
                IO.Writexy("Nhập mã loại máy cần tìm:", 3, 4);
                Hien(1, 8, loaihang.XemDSLoaiHang(), 5, 0);
                malh = int.Parse(IO.ReadNumber(29, 4));
                List<LoaiHang> list = loaihang.TimLoaiHang(new LoaiHang(malh, null, null));
                Hien(1, 8, list, 5, 1);
                if (malh == 0)
                    break;
            } while (true);
            HienChucNang();
        }
        public void Hien(int xx, int yy, List<LoaiHang> list, int n, int type)
        {
            int head = 0;
            int curpage = 1;
            int totalpage = list.Count % n == 0 ? list.Count / n : list.Count / n + 1;
            int final = list.Count <= n ? list.Count : n;
            int x, y, d;
            do
            {
                IO.Clear(xx, yy, 1500, ConsoleColor.Black);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                                     DANH SÁCH LOẠI MÁY", x, y);
                IO.Writexy("┌──────────────┬─────────────────────────┬────────────────────────────────────────────────────────┐", x, y + 1);
                IO.Writexy("│ Mã loại hàng │      Tên loại hàng      │                        Đặc điểm                        │", x, y + 2);
                IO.Writexy("├──────────────┼─────────────────────────┼────────────────────────────────────────────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].maloai.ToString(), x + 1, y + d, 15);
                    IO.Writexy("│", x + 15, y + d);
                    IO.Writexy(list[i].tenloai, x + 16, y + d, 26);
                    IO.Writexy("│", x + 41, y + d);
                    IO.Writexy(list[i].dacdiem, x + 42, y + d, 57);
                    IO.Writexy("│", x + 98, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────────┼─────────────────────────┼────────────────────────────────────────────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────────┴─────────────────────────┴────────────────────────────────────────────────────────┘", x, y + d - 1);
                IO.Writexy(" Trang " + curpage + "/" + totalpage, x, y + d);
                IO.Writexy(" Trang " + curpage + "/" + totalpage + "          Nhấn PagegUp để xem trước, PagegDown để xem tiep, Esc để thoát...", x, y + d);
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
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Nhập danh sách loại hàng ",
                " F2.Sửa thông tin loại hàng ",
                " F3.Xóa loại hàng ",
                " F4.Hiển thị danh sách loại hàng ",
                " F5.Tìm kiếm loại hàng ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuLH mnlh = new MenuLH(mn);
            mnlh.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuLH : Menu
        {
            public MenuLH(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormLoaiHang loaihang = new FormLoaiHang();
                switch (location)
                {
                    case 0:
                        loaihang.Nhap();
                        break;
                    case 1:
                        loaihang.Sua();
                        break;
                    case 2:
                        loaihang.Xoa();
                        break;
                    case 3:
                        loaihang.Xem();
                        break;
                    case 4:
                        loaihang.HienTimKiem();
                        break;
                    case 5:
                        FormMenuChinh.Hien();
                        break;
                }
            }
        }
        public void HienTimKiem()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1.Tìm kiếm loại hàng theo mã ",
                " F2.Tìm kiếm loại hàng theo tên ",
                " F3.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuTimKiem mntk = new MenuTimKiem(mn);
            mntk.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuTimKiem : Menu
        {
            public MenuTimKiem(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormLoaiHang loaihang = new FormLoaiHang();
                switch (location)
                {
                    case 0:
                        loaihang.TimMa();
                        break;
                    case 1:
                        loaihang.TimTen();
                        break;
                    case 2:
                        loaihang.HienChucNang();
                        break;
                }
            }
        }
    }
}
