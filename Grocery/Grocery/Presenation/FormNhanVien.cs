using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;
using Grocery.Presenation;

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
                IO.Writexy("Tên nhân viên:", 5, 4);
                IO.Writexy("Ngày sinh:", 20, 6);
                IO.Writexy("Giới tính:", 30, 6);
                IO.Writexy("Ngày vào làm việc:",40, 8);
                IO.Writexy("Pass:", 55, 10);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, nhanvien.XemDSNhanVien(), 5, 0);
                NhanVien nv = new NhanVien();
                nv.tennv = IO.ReadString(15, 4);
                nv.ngaysinh = IO.ReadNumber(20, 6);
                nv.gt = IO.ReadNumber(69, 6);
                nv.ngayvaolam = IO.ReadNumber(20, 6);
                nv.pass = IO.ReadNumber(20, 6);
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
            IO.Writexy("Tên nhân viên :", 55, 4);
            IO.Writexy("Ngày sinh:", 3, 6);
            IO.Writexy("Giới tính:", 63, 6);
            IO.Writexy("Ngày vào làm việc: ",3, 8);
            IO.Writexy("Pass: ",3, 10);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, nhanvien.XemDSNhanVien(), 5, 0);

            int manv;
            string tennv;
            string ngaysinh;
            string gioitinh;
            string ngaylv;
            string pass;

            manv = int.Parse(IO.ReadNumber(10, 4));
            NhanVien nv = nhanvien.LayNhanVien(manv);
            IO.Writexy(nv.tennv, 65, 4);
            IO.Writexy(nv.ngaysinh.ToString(), 18, 6);
            IO.Writexy(nv.gt, 48, 6);
            IO.Writexy(nv.ngayvaolam.ToString(), 77, 8);
            IO.Writexy(nv.pass, 65, 10);
            tennv = IO.ReadString(65, 4);
            if (tennv != nv.tennv && tennv != null)
                nv.tennv = tennv;
            ngaysinh = IO.ReadNumber(18, 6);
            if (ngaysinh != nv.ngaysinh && ngaysinh != null)
                nv.ngaysinh = ngaysinh;
            gioitinh = IO.ReadNumber(48, 6);
            if (gioitinh != nv.gt && gioitinh != null)
                nv.gt= gioitinh;
            ngaylv = IO.ReadNumber(77, 8);
            if (ngaylv != nv.ngayvaolam && ngaylv != null)
                nv.ngayvaolam = ngaylv;
            pass = IO.ReadNumber(65, 10);
            if (pass != nv.pass && pass != null)
                nv.pass = pass;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 13, nhanvien.XemDSNhanVien(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                nhanvien.SuaNhanVien(nv);
                Hien(1, 13, nhanvien.XemDSNhanVien(), 5, 1);
            }
            HienChucNang();
        }
        public void Xoa()
        {
            int manv = 0;
            do
            {
                Console.Clear();
                IFNhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA NHÂN VIÊN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhân viên cần xóa:", 5, 4);
                Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 0);
                manv = int.Parse(IO.ReadNumber(31, 4));
                if (manv == 0)
                    break;
                else
                    nhanvien.XoaNhanVien(manv);
                Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 1);
            } while (true);
            HienChucNang();
        }
        public void Xem()
        {
            IFNhanVienBLL nhanvien = new NhanVienBLL();
            Console.Clear();
            Hien(1, 1, nhanvien.XemDSNhanVien(), 5, 1);
            HienChucNang();
        }
        public void TimTen()
        {
            string tennv = "";
            do
            {
                Console.Clear();
                IFNhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM NHÂN VIÊN", 1, 1, 5, 100);
                IO.Writexy("Nhập tên nhân viên cần tìm:", 3, 4);
                Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 0);
                tennv = IO.ReadString(30, 4);
                List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(0, tennv, null, null, null, null));
                Hien(1, 8, list, 5, 1);
                if (tennv == "")
                    break;
            } while (true);
            HienChucNang();
        }
        public void TimMa()
        {
            int manv = 0;
            do
            {
                Console.Clear();
                IFNhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                                      TÌM KIẾM NHÂN VIÊN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhân viên cần tìm:", 3, 4);
                Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 0);
                manv = int.Parse(IO.ReadNumber(29, 4));
                List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(manv, null, null, null, null, null));
                Hien(1, 8, list, 5, 1);
                if (manv == 0)
                    break;
            } while (true);
            HienChucNang();
        }
        public void Hien(int xx, int yy, List<NhanVien> list, int n, int type)
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
                IO.Writexy("                      DANH SÁCH NHÂN VIÊN", x, y);
                IO.Writexy("┌──────────────┬─────────────────┬───────────────┬──────────────┬───────────────────┬─────────────────┐", x, y + 1);
                IO.Writexy("│ Mã nhân viên │  Tên nhân viên  │ Ngày sinh     │ Giới tính    │    Ngày vào làm   │   Pass          │ ", x, y + 2);
                IO.Writexy("├──────────────┼─────────────────┼───────────────┼──────────────┼───────────────────┼─────────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].manv.ToString(), x + 1, y + d, 14);
                    IO.Writexy("│", x + 14, y + d);
                    IO.Writexy(list[i].tennv.ToString(), x + 15, y + d, 17);
                    IO.Writexy("│", x + 31, y + d);
                    IO.Writexy(list[i].ngaysinh.ToString(), x + 32, y + d, 16);
                    IO.Writexy("│", x + 47, y + d);
                    IO.Writexy(list[i].gt.ToString(), x + 48, y + d, 15);
                    IO.Writexy("│", x + 47, y + d);
                    IO.Writexy(list[i].ngayvaolam.ToString(), x + 63, y + d, 15);
                    IO.Writexy("│", x + 62, y + d);
                    IO.Writexy(list[i].pass.ToString(), x + 78, y + d, 15);
                    IO.Writexy("│", x + 77, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────────┼─────────────────┼───────────────┼──────────────┼───────────────────┼─────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────────┴─────────────────┴───────────────┴──────────────┴───────────────────┴─────────────────┘", x, y + d - 1);
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
                " F1:Nhập danh sách nhân viên. ",
                " F2:Sửa nhân viên. ",
                " F3:Xóa nhân viên. ",
                " F4:Hiển thị danh sách nhân viên. ",
                " F5:Tìm kiếm nhân viên. ",
                " F6:Quay lại. "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuNV mnnv = new MenuNV(mn);
            mnnv.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuNV : Menu
        {
            public MenuNV(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormNhanVien nhanvien = new FormNhanVien();
                switch (location)
                {
                    case 0:
                        nhanvien.Nhap();
                        break;
                    case 1:
                        nhanvien.Sua();
                        break;
                    case 2:
                        nhanvien.Xoa();
                        break;
                    case 3:
                        nhanvien.Xem();
                        break;
                    case 4:
                        nhanvien.HienTim();
                        break;
                    case 5:
                        FormMenuMain.HienThi();
                        break;
                }
            }
        }
        public void HienTim()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            string[] mn =
            {
                " F1:Tìm kiếm nhân viên theo mã. ",
                " F2:Tìm kiếm nhân viên theo tên. ",
                " F3:Quay lại. "
            };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            MenuTim mnnv = new MenuTim(mn);
            mnnv.HienTheoPhimTat(15, 6, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        public class MenuTim : Menu
        {
            public MenuTim(string[] mn) : base(mn)
            {
            }
            public override void ThucHien(int location)
            {
                FormNhanVien nhanvien = new FormNhanVien();
                switch (location)
                {
                    case 0:
                        nhanvien.TimMa();
                        break;
                    case 1:
                        nhanvien.TimTen();
                        break;
                    case 2:
                        nhanvien.HienChucNang();
                        break;
                }
            }
        }
    }
}