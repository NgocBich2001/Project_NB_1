/*using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;

namespace ComputerStore.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormNhanVien
    {
        public void Nhap()
        {
            do
            {
                IFNhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN NHÂN VIÊN", 1, 1, 10, 100);
                IO.Writexy("Mã nhân viên:", 5, 4);
                IO.Writexy("Tên nhân viên:", 75, 4);
                IO.Writexy("Ngày sinh:", 5, 6);
                IO.Writexy("Giới tính:", 75, 6);
                IO.Writexy("Ngày vào làm việc:", 6, 6);
                IO.Writexy("Pass:", 36, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, nhanvien.XemDSNhanVien(), 5, 0);
                NhanVien nv = new NhanVien();
                nv.manv= int.Parse(IO.ReadNumber(19, 4));
                nv.tennv = IO.ReadString(85, 4);
                nv.ngaysinh = DateTime.Parse(IO.ReadNumber(20, 4));
                nv.gt = IO.ReadString(89, 6);
                nv.ngayvaolam = DateTime.Parse(IO.ReadNumber(4,4));
                nv.pass = IO.ReadString(5,6);
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, nhanvien.XemDSNhanVien(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    nhanvien.ThemNhanVien(nv);
            } while (true);
        }
        public void Sua()
        {
            IFNhanVienBLL nhanvien = new NhanVienBLL();
            Console.Clear();
            IO.BoxTitle("                                   CẬP NHẬT THÔNG TIN NHÂN VIÊN", 1, 1, 10, 100);
            IO.Writexy("Mã nhân viên:", 3, 4);
            IO.Writexy("Tên nhân viên:", 24, 4);
            IO.Writexy("Ngày sinh:", 55, 4);
            IO.Writexy("Giới tính:", 3, 6);
            IO.Writexy("Ngày vào làm việc:", 63, 6);
            IO.Writexy("Pass:",);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, nhanvien.XemDSNhanVien(), 5, 0);

            int manv;
            string tennv;
            DateTime ngaysinh;
            string gt;
            DateTime ngayvaolam;
            string pass;
            //Lấy thông tin theo mã
            manv = int.Parse(IO.ReadNumber(10, 4));
            NhanVien nv = nhanvien.LayNhanVien(manv);
            IO.Writexy(nv.manv.ToString(), 38, 4);
            IO.Writexy(nv.tennv, 65, 4);
            IO.Writexy(nv.gt.ToString(), 18, 6);
            IO.Writexy(nv.ngayvaolam.ToString(), 77, 6);
            IO.Writexy(nv.pass.ToString(),,);
            //Nhập lại thông tin
            manv = int.Parse(IO.ReadNumber(38, 4));
            if (manv != nv.manv && manv > 0)
                nv.manv = manv;
            tennv = IO.ReadString(65, 4);
            if (tennv != nv.tennv && tennv != null)
                nv.tennv = tennv;
            ngaysinh = DateTime.Parse(IO.ReadNumber(18, 6));
            if (ngaysinh != nv.ngaysinh && ngaysinh != "")
                nv.ngaysinh = ngaysinh;
            gt = IO.ReadNumber(77, 6);
            if (gt != nv.gt && gt != "")
                nv.gt = gt;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, hanghoa.XemDSHangHoa(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                hanghoa.SuaHangHoa(hh);
                Hien(1, 13, hanghoa.XemDSHangHoa(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int mahh = 0;
            do
            {
                Console.Clear();
                IFHangHoaBLL hanghoa = new HangHoaBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA HÀNG HÓA", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hàng hóa cần xóa:", 5, 4);
                Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 0);
                mahh = int.Parse(IO.ReadNumber(31, 4));
                if (mahh == 0)
                    break;
                else
                    hanghoa.XoaHangHoa(mahh);
                Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 1);
            } while (true);
            HienChucNang();
        }
        public void Xem()
        {
            IFHangHoaBLL hanghoa = new HangHoaBLL();
            Console.Clear();
            Hien(1, 1, hanghoa.XemDSHangHoa(), 5, 1);
            HienChucNang();
        }
        public void TimTen()
        {
            string tenhh = "";
            do
            {
                Console.Clear();
                IFHangHoaBLL hanghoa = new HangHoaBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM HÀNG HÓA", 1, 1, 5, 100);
                IO.Writexy("Nhập tên hàng hóa cần tìm:", 3, 4);
                Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 0);
                tenhh = IO.ReadString(30, 4);
                List<HangHoa> list = hanghoa.TimHangHoa(new HangHoa(0, 0, tenhh, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (tenhh == "")
                    break;
            } while (true);
            HienChucNang();
        }
        public void TimMa()
        {
            int mahh = 0;
            do
            {
                Console.Clear();
                IFHangHoaBLL hanghoa = new HangHoaBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM HÀNG HÓA", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hàng hóa cần tìm:", 3, 4);
                Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 0);
                mahh = int.Parse(IO.ReadNumber(29, 4));
                List<HangHoa> list = hanghoa.TimHangHoa(new HangHoa(mahh, 0, null, 0, 0));
                Hien(1, 8, list, 5, 1);
                if (mahh == 0)
                    break;
            } while (true);
            HienChucNang();
        }
        public void Hien(int xx, int yy, List<HangHoa> list, int n, int type)
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
                IO.Writexy("                                         DANH SÁCH HÀNG HÓA", x, y);
                IO.Writexy("┌─────────────┬──────────────┬─────────────────────────┬───────────────┬──────────────┐", x, y + 1);
                IO.Writexy("│ Mã hàng hóa │ Mã loại hàng │      Tên hàng hóa       │ Số lượng nhập │ Số lượng có  │", x, y + 2);
                IO.Writexy("├─────────────┼──────────────┼─────────────────────────┼───────────────┼──────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].mahh.ToString(), x + 1, y + d, 14);
                    IO.Writexy("│", x + 14, y + d);
                    IO.Writexy(list[i].maloai.ToString(), x + 15, y + d, 15);
                    IO.Writexy("│", x + 29, y + d);
                    IO.Writexy(list[i].tenhang, x + 30, y + d, 26);
                    IO.Writexy("│", x + 55, y + d);
                    IO.Writexy(list[i].slnhapve.ToString(), x + 56, y + d, 16);
                    IO.Writexy("│", x + 71, y + d);
                    IO.Writexy(list[i].slhienco.ToString(), x + 72, y + d, 15);
                    IO.Writexy("│", x + 86, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────┼─────────────┼─────────────────────────┼───────────┼───────────────┼──────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────┴─────────────┴─────────────────────────┴───────────┴───────────────┴──────────────┘", x, y + d - 1);
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
                " F1.Nhập danh sách hàng hóa ",
                " F2.Sửa thông tin hàng hóa ",
                " F3.Xóa hàng hóa ",
                " F4.Hiển thị danh sách hàng hóa ",
                " F5.Tìm kiếm hàng hóa ",
                " F6.Quay lại "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuHH mnhh = new MenuHH(mn);
            mnhh.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuHH : Menu
        {
            public MenuHH(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormHangHoa hanghoa = new FormHangHoa();
                switch (location)
                {
                    case 0:
                        hanghoa.Nhap();
                        break;
                    case 1:
                        hanghoa.Sua();
                        break;
                    case 2:
                        hanghoa.Xoa();
                        break;
                    case 3:
                        hanghoa.Xem();
                        break;
                    case 4:
                        hanghoa.HienTimKiem();
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
                " F1.Tìm kiếm hàng hóa theo mã ",
                " F2.Tìm kiếm hàng hóa theo tên ",
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
                FormHangHoa hanghoa = new FormHangHoa();
                switch (location)
                {
                    case 0:
                        hanghoa.TimMa();
                        break;
                    case 1:
                        hanghoa.TimTen();
                        break;
                    case 2:
                        hanghoa.HienChucNang();
                        break;
                }
            }
        }
    }
}*/