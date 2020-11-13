using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;

namespace Grocery.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormHoaDonBan
    {
        public void Nhap()
        {
            do
            {
                IFHoaDonBanBLL hdb = new HoaDonBanBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 12, 100);
                IO.Writexy("Mã nhân viên bán:", 5, 4);
                IO.Writexy("Ngày bán:", 40, 4);
                IO.Writexy("Mã hàng:", 5, 6);
                IO.Writexy("Số lượng: ", 30, 6);
                IO.Writexy("Giá bán:", 50, 6);
                IO.Writexy("Đơn vị tính:", 70, 6);
                IO.Writexy("Thành tiền:", 5, 8);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 10);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 11);
                Hien(1, 14, hdb.XemDSHoaDonBan(), 5, 0);
                HoaDonBan hoadb = new HoaDonBan();
                hoadb.manvban = int.Parse(IO.ReadNumber(24, 4));
                hoadb.ngayban = IO.ReadString(50, 4);
                hoadb.mahang = int.Parse(IO.ReadNumber(14, 6));
                hoadb.soluong = int.Parse(IO.ReadNumber(40, 6));
                hoadb.giaban = double.Parse(IO.ReadNumber(59, 6));
                hoadb.donvi = IO.ReadString(83, 6);
                hoadb.thanhtien = double.Parse(IO.ReadNumber(17, 8));
                Console.SetCursorPosition(55, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, hdb.XemDSHoaDonBan(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    hdb.ThemHoaDonBan(hoadb);
            } while (true);
        }
        public void Sua()
        {
            IFHoaDonBanBLL hdb = new HoaDonBanBLL();
            Console.Clear();
            IO.BoxTitle("                                   CẬP NHẬT THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 15, 100);
            IO.Writexy("Mã hóa đơn bán:", 5, 4);
            IO.Writexy("Mã nhân viên bán:", 5, 6);
            IO.Writexy("Ngày bán:", 40, 6);
            IO.Writexy("Mã hàng:", 5, 8);
            IO.Writexy("Số lượng: ", 30, 8);
            IO.Writexy("Giá bán:", 50, 8);
            IO.Writexy("Đơn vị tính:", 70, 8);
            IO.Writexy("Thành tiền:", 5, 10);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 12);
            IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 13);
            Hien(1, 16, hdb.XemDSHoaDonBan(), 5, 0);

            int mahdb;
            int manv;
            string ngayban;
            int mahang;
            int soluong;
            double giaban;
            string donvi;
            double thanhtien;


            mahdb = int.Parse(IO.ReadNumber(22, 4));
            HoaDonBan hdban = hdb.LayHoaDonBan(mahdb);
            IO.Writexy(hdban.manvban.ToString(), 24, 6);
            IO.Writexy(hdban.ngayban, 50, 6);
            IO.Writexy(hdban.mahang.ToString(), 14, 8);
            IO.Writexy(hdban.soluong.ToString(), 40, 8);
            IO.Writexy(hdban.giaban.ToString(), 59, 8);
            IO.Writexy(hdban.donvi, 83, 8);
            IO.Writexy(hdban.thanhtien.ToString(), 17, 10);

            manv = int.Parse(IO.ReadNumber(24, 6));
            if (manv != hdban.manvban && manv > 0)
                hdban.manvban = manv;
            ngayban = IO.ReadString(50, 6);
            if (ngayban != hdban.ngayban && ngayban != null)
                hdban.ngayban = ngayban;
            mahang = int.Parse(IO.ReadNumber(14, 8));
            if (mahang != hdban.mahang && mahang > 0)
                hdban.mahang = mahang;
            soluong = int.Parse(IO.ReadNumber(40, 8));
            if (soluong != hdban.soluong && soluong > 0)
                hdban.soluong = soluong;
            giaban = double.Parse(IO.ReadNumber(59, 8));
            if (giaban != hdban.giaban && giaban > 0)
                hdban.giaban = giaban;
            donvi = IO.ReadString(83, 8);
            if (donvi != hdban.donvi && donvi != null)
                hdban.donvi = donvi;
            thanhtien = double.Parse(IO.ReadNumber(17, 10));
            if (thanhtien != hdban.thanhtien && thanhtien > 0)
                hdban.thanhtien = thanhtien;
            

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, hdb.XemDSHoaDonBan(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hdb.SuaHoaDonBan(hdban);
                Hien(1, 13, hdb.XemDSHoaDonBan(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int mahdb = 0;
            do
            {
                Console.Clear();
                IFHoaDonBanBLL hdb = new HoaDonBanBLL();
                Console.Clear();
                IO.BoxTitle("                                  XÓA HÓA ĐƠN BAN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần xóa:", 5, 4);
                Hien(1, 8, hdb.XemDSHoaDonBan(), 5, 0);
                mahdb = int.Parse(IO.ReadNumber(35, 4));
                if (mahdb == 0)
                    break;
                else
                    hdb.XoaHoaDonBan(mahdb);
                Hien(1, 8, hdb.XemDSHoaDonBan(), 5, 1);
            } while (true);
            HienChucNang();
        }
        public void Xem()
        {
            IFHoaDonBanBLL hdb = new HoaDonBanBLL();
            Console.Clear();
            Hien(1, 1, hdb.XemDSHoaDonBan(), 5, 1);
            HienChucNang();
        }

        public void TimMa()
        {
            int mahdb = 0;
            do
            {
                Console.Clear();
                IFHoaDonBanBLL hdb = new HoaDonBanBLL();
                Console.Clear();
                IO.BoxTitle("                                TÌM KIẾM HÓA ĐƠN BÁN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần tìm:", 5, 4);
                Hien(1, 8, hdb.XemDSHoaDonBan(), 5, 0);
                mahdb = int.Parse(IO.ReadNumber(35, 4));
                List<HoaDonBan> list = hdb.TimHoaDonBan(new HoaDonBan(mahdb, 0, null, 0, 0, 0, null, 0));
                Hien(1, 8, list, 5, 1);
                if (mahdb == 0)
                    break;
            } while (true);
            HienChucNang();
        }
        public void Hien(int xx, int yy, List<HoaDonBan> list, int n, int type)
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
                IO.Writexy("                                   DANH SÁCH HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌────────┬───────────┬────────────┬───────────┬──────────┬──────────┬─────────────┬────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDB │ Mã NV bán │ Ngày bán   │ Mã hàng   │ Số lượng │ Giá bán  │ Đơn vị tính │ Thành tiền │", x, y + 2);
                IO.Writexy("├────────┼───────────┼────────────┼───────────┼──────────┼──────────┼─────────────┼────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 18);
                    IO.Writexy(list[i].mahdb.ToString(), x + 1, y + d, 8);
                    IO.Writexy("│", x + 9, y + d);
                    IO.Writexy(list[i].manvban.ToString(), x + 10, y + d,11);
                    IO.Writexy("│", x + 21, y + d);
                    IO.Writexy(list[i].ngayban.ToString(), x + 22, y + d, 12);
                    IO.Writexy("│", x + 34, y + d);
                    IO.Writexy(list[i].mahang.ToString(), x + 35, y + d, 11);
                    IO.Writexy("│", x + 46, y + d);
                    IO.Writexy(list[i].soluong.ToString(), x + 47, y + d, 10);
                    IO.Writexy("│", x + 57, y + d);
                    IO.Writexy(list[i].giaban.ToString(), x + 58, y + d, 10);
                    IO.Writexy("│", x + 68, y + d);
                    IO.Writexy(list[i].donvi.ToString(), x + 69, y + d, 13);
                    IO.Writexy("│", x + 82, y + d);
                    IO.Writexy(list[i].thanhtien.ToString(), x + 83, y + d, 12);                   
                    IO.Writexy("│", x + 95, y + d);
                    if (i < final - 1)
                        IO.Writexy("├────────┼───────────┼────────────┼───────────┼──────────┼──────────┼─────────────┼────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└────────┴───────────┴────────────┴───────────┴──────────┴──────────┴─────────────┴────────────┘", x, y + d - 1);
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
        public class MenuHoaDonBan : Menu
        {
            public MenuHoaDonBan(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormHoaDonBan hdb = new FormHoaDonBan();
                switch (location)
                {
                    case 0:
                        hdb.Nhap();
                        break;
                    case 1:
                        hdb.Sua();
                        break;
                    case 2:
                        hdb.Xoa();
                        break;
                    case 3:
                        hdb.Xem();
                        break;
                    case 4:
                        hdb.TimMa();
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
                " F1:Nhập danh sách hóa đơn bán. ",
                " F2:Sửa hóa đơn bán. ",
                " F3:Xóa hóa đơn bán. ",
                " F4:Hiển thị danh sách hóa đơn bán. ",
                " F5:Tìm kiếm hóa đơn bán. ",
                " F6:Quay lại. "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuHoaDonBan hdb = new MenuHoaDonBan(mn);
            hdb.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }

        //public void HienTim()
        //{
        //    Console.WindowHeight = Console.LargestWindowHeight;
        //    string[] mn =
        //    {
        //        " F1:Tìm kiếm hóa đơn bán theo mã. ",
        //        " F2:Quay lại. "
        //    };
        //    Console.BackgroundColor = ConsoleColor.Black;
        //    Console.Clear();
        //    MenuTim hdn = new MenuTim(mn);
        //    hdn.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
        //    Console.ReadKey();
        //}
        //public class MenuTim : Menu
        //{
        //    public MenuTim(string[] mn) : base(mn)
        //    {
        //    }
        //    public override void ThucHien(int location)
        //    {
        //        FormHoaDonNhap hdn = new FormHoaDonNhap();
        //        switch (location)
        //        {
        //            case 0:
        //                hdn.TimMa();
        //                break;

        //            case 1:
        //                hdn.HienChucNang();
        //                break;
        //        }
        //    }
        //}
    }
}