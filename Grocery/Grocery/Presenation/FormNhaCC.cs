using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;

namespace Grocery.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormNhaCC
    {
        public void Nhap()
        {
            do
            {
                IFNhaCCBLL nhacc = new NhaCCBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 100);
                IO.Writexy("Tên nhà cung cấp:", 5, 4);
                IO.Writexy("Địa chỉ:", 5, 6);
                IO.Writexy("Số điện thoại:", 55, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, nhacc.XemDSNhaCC(), 5, 0);
                NCC nc = new NCC();
                nc.tenncc= IO.ReadString(25, 4);
                nc.diachi = IO.ReadString(14, 6);
                nc.sdt = int.Parse(IO.ReadNumber(70, 6));
                Console.SetCursorPosition(55, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, nhacc.XemDSNhaCC(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    nhacc.ThemNhaCC(nc);
            } while (true);
        }
        public void Sua()
        {
            IFNhaCCBLL nhacc = new NhaCCBLL();
            Console.Clear();
            IO.BoxTitle("                                   CẬP NHẬT THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 100);
            IO.Writexy("Mã nhà cung cấp:", 5, 4);
            IO.Writexy("Tên nhà cung cấp:", 52, 4);
            IO.Writexy("Địa chỉ:", 5, 6);
            IO.Writexy("Số điện thoại:", 52, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, nhacc.XemDSNhaCC(), 5, 0);

            int mancc;
            string tenncc;
            string diachi;
            int sdt;

            mancc = int.Parse(IO.ReadNumber(23, 4));
            NCC nc = nhacc.LayNCC(mancc);
            IO.Writexy(nc.tenncc, 53, 4);
            IO.Writexy(nc.diachi, 14, 6);
            IO.Writexy(nc.sdt.ToString(), 70, 6);

            tenncc = IO.ReadString(52, 4);
            if (tenncc != nc.tenncc && tenncc != null)
                nc.tenncc = tenncc;
            diachi = IO.ReadString(14, 6);
            if (diachi != nc.diachi && diachi != null)
                nc.diachi = diachi;
            sdt = int.Parse(IO.ReadNumber(70, 6));
            if (sdt != nc.sdt && sdt > 0)
                 nc.sdt = sdt;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, nhacc.XemDSNhaCC(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                nhacc.SuaNhaCC(nc);
                Hien(1, 13, nhacc.XemDSNhaCC(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int mancc = 0;
            do
            {
                Console.Clear();
                IFNhaCCBLL nhacc = new NhaCCBLL();
                Console.Clear();
                IO.BoxTitle("                                  XÓA NHÀ CUNG CẤP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhà cung cấp cần xóa:", 5, 4);
                Hien(1, 8, nhacc.XemDSNhaCC(), 5, 0);
                mancc = int.Parse(IO.ReadNumber(35, 4));
                if (mancc == 0)
                    break;
                else
                    nhacc.XoaNhaCC(mancc);
                Hien(1, 8, nhacc.XemDSNhaCC(), 5, 1);
            } while (true);
            HienChucNang();
        }
        public void Xem()
        {
            IFNhaCCBLL nhacc = new NhaCCBLL();
            Console.Clear();
            Hien(1, 1, nhacc.XemDSNhaCC(), 5, 1);
            HienChucNang();
        }
        public void TimTen()
        {
            string tenncc = "";
            do
            {
                Console.Clear();
                IFNhaCCBLL nhacc = new NhaCCBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM NHÀ CUNG CẤP", 1, 1, 5, 100);
                IO.Writexy("Nhập tên nhà cung cấp cần tìm:", 5, 4);
                Hien(1, 8, nhacc.XemDSNhaCC(), 5, 0);
                tenncc = IO.ReadString(35, 4);
                List<NCC> list = nhacc.TimNhaCC(new NCC(0, tenncc, null, 0));
                Hien(1, 8, list, 5, 1);
                if (tenncc == "")
                    break;
            } while (true);
            HienChucNang();
        }
        public void TimMa()
        {
            int mancc = 0;
            do
            {
                Console.Clear();
                IFNhaCCBLL nhacc = new NhaCCBLL();
                Console.Clear();
                IO.BoxTitle("                                TÌM KIẾM NHÀ CUNG CẤP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhà cung cấp cần tìm:", 5, 4);
                Hien(1, 8, nhacc.XemDSNhaCC(), 5, 0);
                mancc = int.Parse(IO.ReadNumber(35, 4));
                List<NCC> list = nhacc.TimNhaCC(new NCC(mancc, null, null, 0));
                Hien(1, 8, list, 5, 1);
                if (mancc == 0)
                    break;
            } while (true);
            HienChucNang();
        }
        public void Hien(int xx, int yy, List<NCC> list, int n, int type)
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
                IO.Writexy("                                   DANH SÁCH NHÀ CUNG CẤP", x, y);
                IO.Writexy("┌─────────────────┬───────────────────────────┬─────────────────────────┬────────────────────┐", x, y + 1);
                IO.Writexy("│ Mã nhà cung cấp │     Tên nhà cung cấp      │       Địa chỉ           │    Số điện thoại   │", x, y + 2);
                IO.Writexy("├─────────────────┼───────────────────────────┼─────────────────────────┼────────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 18);
                    IO.Writexy(list[i].mancc.ToString(), x + 1, y + d, 18);
                    IO.Writexy("│", x + 18, y + d);
                    IO.Writexy(list[i].tenncc.ToString(), x + 19, y + d, 27);
                    IO.Writexy("│", x + 46, y + d);
                    IO.Writexy(list[i].diachi.ToString(), x + 47, y + d, 25);
                    IO.Writexy("│", x + 72, y + d);
                    IO.Writexy(list[i].sdt.ToString(), x + 73, y + d, 20);
                    IO.Writexy("│", x + 93, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────────┼───────────────────────────┼─────────────────────────┼────────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────────┴───────────────────────────┴─────────────────────────┴────────────────────┘", x, y + d - 1);
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
        public class MenuNCC : Menu
        {
            public MenuNCC(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormNhaCC nhacc = new FormNhaCC();
                switch (location)
                {
                    case 0:
                        nhacc.Nhap();
                        break;
                    case 1:
                        nhacc.Sua();
                        break;
                    case 2:
                        nhacc.Xoa();
                        break;
                    case 3:
                        nhacc.Xem();
                        break;
                    case 4:
                        nhacc.HienTim();
                        break;
                    case 5:
                        FormMenuMain.HienThi();
                        break;
                }
            }
        }
        public void HienChucNang()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1:Nhập danh sách nhà cung cấp. ",
                " F2:Sửa nhà cung cấp. ",
                " F3:Xóa nhà cung cấp. ",
                " F4:Hiển thị danh sách nhà cung cấp. ",
                " F5:Tìm kiếm nhà cung cấp. ",
                " F6:Quay lại. "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuNCC ncc = new MenuNCC(mn);
            ncc.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
       
        public void HienTim()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1:Tìm kiếm nhà cung cấp theo mã. ",
                " F2:Tìm kiếm nhà cung cấp theo tên. ",
                " F3:Quay lại. "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuTim ncc = new MenuTim(mn);
            ncc.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuTim : Menu
        {
            public MenuTim(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormNhaCC nhacc = new FormNhaCC();
                switch (location)
                {
                    case 0:
                        nhacc.TimMa();
                        break;
                    case 1:
                        nhacc.TimTen();
                        break;
                    case 2:
                        nhacc.HienChucNang();
                        break;
                }
            }
        }
    }
}