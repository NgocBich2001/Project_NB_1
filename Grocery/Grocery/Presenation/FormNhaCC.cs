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
                do
                {
                    nc.tenncc = IO.ReadString(25, 4);
                    if (nc.tenncc == null)
                    {
                        IO.Clear(5, 8, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin xui lòng nhập lại!", 5, 8);
                    }
                } while (nc.tenncc == null);
                IO.Clear(5, 8, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                do
                {
                    nc.diachi = IO.ReadString(14, 6);
                    if (nc.diachi == null)
                    {
                        IO.Clear(5, 8, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin xui lòng nhập lại!", 5, 8);
                    }
                } while (nc.diachi == null);
                IO.Clear(5, 8, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                do
                {
                    nc.sdt = IO.ReadNumber(70, 6);
                    if (nc.sdt == null)
                    {
                        IO.Clear(5, 8, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin xui lòng nhập lại!", 5, 8);
                    }
                } while (nc.sdt == null);
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
            NhaCCBLL NCBLL = new NhaCCBLL();
            Console.Clear();
            IO.BoxTitle("                                   SỬA THÔNG TIN NHÀ CUNG CẤP", 1, 1, 10, 100);
            IO.Writexy("Mã nhà cung cấp:", 5, 4);
            IO.Writexy("Tên nhà cung cấp:", 40, 4);
            IO.Writexy("Địa chỉ:", 5, 6);
            IO.Writexy("Số điện thoại:", 40, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 12, nhacc.XemDSNhaCC(), 5, 0);

            int mancc;
            string tenncc;
            string diachi;
            string sdt;
            do
            {
                mancc = int.Parse(IO.ReadNumber(23, 4));
                if (mancc < 0 || NCBLL.KiemTra(mancc) == false)
                {
                    IO.Clear(5, 8, 60, ConsoleColor.Black);
                    IO.Writexy("Không tồn tại mã nhà cung cấp này. Vui lòng kiểm tra lại!", 5, 8);
                }
            } while (mancc < 0 || NCBLL.KiemTra(mancc) == false);
            NCC nc = nhacc.LayNCC(mancc);
            IO.Writexy(nc.tenncc, 58, 4);
            IO.Writexy(nc.diachi, 14, 6);
            IO.Writexy(nc.sdt, 55, 6);

            tenncc = IO.ReadString(58, 4);
            if (tenncc != nc.tenncc && tenncc != null)
                nc.tenncc = tenncc;
            diachi = IO.ReadString(14, 6);
            if (diachi != nc.diachi && diachi != null)
                nc.diachi = diachi;
            sdt = IO.ReadNumber(55, 6);
            if (sdt != nc.sdt && sdt == null)
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
                NhaCCBLL NCBLL = new NhaCCBLL();
                Console.Clear();
                IO.BoxTitle("                                  XÓA NHÀ CUNG CẤP", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhà cung cấp cần xóa:", 5, 4);
                Hien(1, 8, nhacc.XemDSNhaCC(), 5, 0);
                do
                {
                    mancc = int.Parse(IO.ReadNumber(35, 4));
                    if (mancc < 0 || NCBLL.KiemTra(mancc) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã nahf cung cấp này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                        nhacc.XoaNhaCC(mancc);
                    Console.Clear();
                    Hien(1, 8, nhacc.XemDSNhaCC(), 5, 1);
                } while (mancc < 0 || NCBLL.KiemTra(mancc) == false);     
            } while (true);
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
                NhaCCBLL NCBLL = new NhaCCBLL();
                Console.Clear();
                IO.BoxTitle("                               TÌM KIẾM NHÀ CUNG CẤP THEO TÊN", 1, 1, 5, 100);
                IO.Writexy("Nhập tên nhà cung cấp cần tìm:", 5, 4);
                Hien(1, 8, nhacc.XemDSNhaCC(), 5, 0);
                do
                {
                    tenncc = IO.ReadString(35, 4);
                    if (tenncc == null || NCBLL.KiemTraTen(tenncc) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại tên nhà cung cấp này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<NCC> list = nhacc.TimNhaCC(new NCC(0, tenncc, null, null));
                        Hien(1, 8, list, 5, 1);
                    }    
                } while (tenncc == null || NCBLL.KiemTraTen(tenncc) == false);
            } while (true);
        }
        public void TimMa()
        {
            int mancc = 0;
            do
            {
                Console.Clear();
                IFNhaCCBLL nhacc = new NhaCCBLL();
                NhaCCBLL NCBLL = new NhaCCBLL();
                Console.Clear();
                IO.BoxTitle("                          TÌM KIẾM NHÀ CUNG CẤP THEO MÃ", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhà cung cấp cần tìm:", 5, 4);
                Hien(1, 8, nhacc.XemDSNhaCC(), 5, 0);
                do
                {
                    mancc = int.Parse(IO.ReadNumber(35, 4));
                    if (mancc < 0 || NCBLL.KiemTra(mancc) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã nhà cung cấp này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<NCC> list = nhacc.TimNhaCC(new NCC(mancc, null, null, null));
                        Hien(1, 8, list, 5, 1);
                    }    
                } while (mancc < 0 || NCBLL.KiemTra(mancc) == false);
            } while (true);
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
                IO.Clear(xx, yy, 1800, ConsoleColor.Black);
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
        public void HienChucNang()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {

                Console.Clear();

                IO.BoxTitle("   *** CÁC CHỨC NĂNG CỦA NHÀ CUNG CẤP ***         ", 5, 1, 20, 56);
                IO.Writexy("*       1. Thêm nhà cung cấp.              *", 12, 5);
                IO.Writexy("*                                          *", 12, 6);
                IO.Writexy("*       2. Sửa nhà cung cấp.               *", 12, 7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*       3. Xóa nhà cung cấp.               *", 12, 9);
                IO.Writexy("*                                          *", 12, 10);
                IO.Writexy("*       4. Xem danh sách nhà cung cấp.     *", 12, 11);
                IO.Writexy("*                                          *", 12, 12);
                IO.Writexy("*       5. Tìm kiếm nhà cung cấp.          *", 12, 13);
                IO.Writexy("*                                          *", 12, 14);
                IO.Writexy("*       6. Quay lại.                       *", 12, 15);
                IO.Writexy("*                                          *", 12, 16);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *", 12, 17);
                IO.Writexy("********************************************", 12, 19);

                FormNhaCC NCC = new FormNhaCC();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        NCC.Nhap();
                        break;

                    case '2':
                        NCC.Sua();
                        break;

                    case '3':
                        NCC.Xoa();
                        break;
                    case '4':
                        NCC.Xem();
                        break;
                    case '5':
                        NCC.HienTim();
                        break;

                    case '6':
                        FormMenuMain.HienThi();
                        break;
                }
            } while (true);
        }

        public void HienTim()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {

                Console.Clear();

                IO.BoxTitle("        *** TÌM KIẾM NHÀ CUNG CẤP***         ", 5, 1, 12, 56);
                IO.Writexy("*     1. Tìm kiếm nhà cung cấp theo mã.    *", 12, 5);
                IO.Writexy("*     2. Tìm kiếm nhà cung cấp theo tên.   *", 12, 6);
                IO.Writexy("*     3. Quay lại.                         *", 12, 7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *", 12, 9);
                IO.Writexy("********************************************", 12, 10);

                FormNhaCC NCC = new FormNhaCC();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        NCC.TimMa();
                        break;

                    case '2':
                        NCC.TimTen();
                        break;

                    case '3':
                        HienChucNang();
                        break;
                }
            } while (true);
        }
    }
}