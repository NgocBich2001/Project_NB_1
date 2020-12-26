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
    public class FormNhanVien
    {
        public void Nhap()
        {
            do
            {
                IFNhanVienBLL nhanvien = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN NHÂN VIÊN", 1, 1, 15, 100);
                IO.Writexy("Tên nhân viên:", 5,4);
                IO.Writexy("Ngày sinh:", 5, 6);
                IO.Writexy("Giới tính:", 35, 6);
                IO.Writexy("Ngày vào làm việc:",5, 8);
                IO.Writexy("Pass:", 5, 10);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 11);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12); //
                Hien(1, 18, nhanvien.XemDSNhanVien(), 5, 0);
                NhanVien nv = new NhanVien();
                do
                {
                    nv.tennv = IO.ReadString(21, 4);
                    if(nv.tennv == null)
                    {
                        IO.Clear(5, 12, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                    }    
                } while (nv.tennv == null);
                IO.Clear(5, 12, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                do
                {
                    nv.ngaysinh = IO.ReadString(15, 6);
                    if (nv.ngaysinh == null)
                    {
                        IO.Clear(5, 12, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                    }    
                } while (nv.ngaysinh == null);
                IO.Clear(5, 12, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                do
                {
                    nv.gt = IO.ReadString(46, 6);
                    if(nv.gt==null)
                    {
                        IO.Clear(5, 12, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                    }    
                } while (nv.gt == null);
                IO.Clear(5, 12, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                do
                {
                    nv.ngayvaolam = IO.ReadString(24, 8);
                    if(nv.ngayvaolam == null)
                    {
                        IO.Clear(5, 12, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                    }
                } while (nv.ngayvaolam == null);
                IO.Clear(5, 12, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                do
                {
                    nv.pass = IO.ReadString(11, 10);
                    if (nv.pass == null)
                    {
                        IO.Clear(5, 12, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                    }
                } while (nv.pass == null);
                Console.SetCursorPosition(54, 12);   //
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, nhanvien.XemDSNhanVien(), 3, 1);
                else if (kt.Key == ConsoleKey.Enter)
                    nhanvien.ThemNhanVien(nv);
            } while (true);
        }
        public void Sua()
        {
            IFNhanVienBLL nhanvien = new NhanVienBLL();
            NhanVienBLL NVBLL = new NhanVienBLL();
            Console.Clear();
            IO.BoxTitle("                                   SỬA THÔNG TIN NHÂN VIÊN", 1, 1, 15, 100);
            IO.Writexy("Mã nhân viên:", 5, 4);
            IO.Writexy("Tên nhân viên :", 40, 4);
            IO.Writexy("Ngày sinh:", 5, 6);
            IO.Writexy("Giới tính:", 35, 6);
            IO.Writexy("Ngày vào làm việc: ",5, 8);
            IO.Writexy("Pass: ",5, 10);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 11);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 12);
            Hien(1, 18, nhanvien.XemDSNhanVien(), 5, 0);

            int manv;
            string tennv;
            string ngaysinh;
            string gioitinh;
            string ngaylv;
            string pass;
            do
            {
                manv = int.Parse(IO.ReadNumber(20, 4));
                if (manv < 0 || NVBLL.KiemTra(manv) == false)
                {
                    IO.Clear(5, 12, 60, ConsoleColor.Black);
                    IO.Writexy("Không tồn tại mã hàng này. Vui lòng kiểm tra lại!", 5, 12);
                }
            } while (manv < 0 || NVBLL.KiemTra(manv) == false);
            NhanVien nv = nhanvien.LayNhanVien(manv);
            IO.Writexy(nv.tennv, 55, 4);
            IO.Writexy(nv.ngaysinh, 18, 6);
            IO.Writexy(nv.gt, 48, 6);
            IO.Writexy(nv.ngayvaolam, 24, 8);
            IO.Writexy(nv.pass, 11, 10);
            tennv = IO.ReadString(55, 4);
            if (tennv != nv.tennv && tennv != null)
                nv.tennv = tennv;
            ngaysinh = IO.ReadString(18, 6);
            if (ngaysinh != nv.ngaysinh && ngaysinh != null)
                nv.ngaysinh = ngaysinh;
            gioitinh = IO.ReadString(48, 6);
            if (gioitinh != nv.gt && gioitinh != null)
                nv.gt= gioitinh;
            ngaylv = IO.ReadString(24, 8);
            if (ngaylv != nv.ngayvaolam && ngaylv != null)
                nv.ngayvaolam = ngaylv;
            pass = IO.ReadString(11, 10);
            if (pass != nv.pass && pass != null)
                nv.pass = pass;

            Console.SetCursorPosition(58, 8);
            ConsoleKeyInfo kt = Console.ReadKey();
            if (kt.Key == ConsoleKey.Escape)
                HienChucNang();
            else if (kt.Key == ConsoleKey.X)
                Hien(1, 18, nhanvien.XemDSNhanVien(), 5, 1);
            else if (kt.Key == ConsoleKey.Enter)
            {
                nhanvien.SuaNhanVien(nv);
                Hien(1, 18, nhanvien.XemDSNhanVien(), 5, 1);
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
                NhanVienBLL NVBLL = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA NHÂN VIÊN", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhân viên cần xóa:", 5, 4);
                Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 0);
                do
                {
                    manv = int.Parse(IO.ReadNumber(31, 4));
                    if (manv < 0 || NVBLL.KiemTra(manv) == false)
                    {
                        IO.Clear(31, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã nhân viên này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                        nhanvien.XoaNhanVien(manv);
                    Console.Clear();
                    Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 1);
                } while (manv < 0 || NVBLL.KiemTra(manv) == false);
            } while (true);
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
                NhanVienBLL NVBLL = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                              TÌM KIẾM NHÂN VIÊN THEO TÊN", 1, 1, 5, 100);
                IO.Writexy("Nhập tên nhân viên cần tìm:", 3, 4);
                Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 0);
                do
                {
                    tennv = IO.ReadString(30, 4);
                    if (tennv == null || NVBLL.KiemTraTen(tennv) == false)
                    {
                        IO.Clear(30, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại tên nhân viên này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(0, tennv, null, null, null, null));
                        Hien(1, 8, list, 5, 1);
                    }    
                } while (tennv == null || NVBLL.KiemTraTen(tennv) == false);
            } while (true);
        }
        public void TimMa()
        {
            int manv = 0;
            do
            {
                Console.Clear();
                IFNhanVienBLL nhanvien = new NhanVienBLL();
                NhanVienBLL NVBLL = new NhanVienBLL();
                Console.Clear();
                IO.BoxTitle("                             TÌM KIẾM NHÂN VIÊN THEO MÃ", 1, 1, 5, 100);
                IO.Writexy("Nhập mã nhân viên cần tìm:", 3, 4);
                Hien(1, 8, nhanvien.XemDSNhanVien(), 5, 0);
                do
                {
                    manv = int.Parse(IO.ReadNumber(29, 4));
                    if (manv < 0 || NVBLL.KiemTra(manv) == false)
                    {
                        IO.Clear(29, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã nhân viên này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<NhanVien> list = nhanvien.TimNhanVien(new NhanVien(manv, null, null, null, null, null));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (manv < 0 || NVBLL.KiemTra(manv) == false);
            } while (true);
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
                IO.Clear(xx, yy, 1800, ConsoleColor.Black);
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
                    IO.Writexy("│", x, y + d, 15);
                    IO.Writexy(list[i].manv.ToString(), x + 1, y + d, 15);
                    IO.Writexy("│", x + 15, y + d);
                    IO.Writexy(list[i].tennv.ToString(), x + 16, y + d, 18);
                    IO.Writexy("│", x + 33, y + d);
                    IO.Writexy(list[i].ngaysinh.ToString(), x + 34, y + d, 16);
                    IO.Writexy("│", x + 49, y + d);
                    IO.Writexy(list[i].gt.ToString(), x + 50, y + d, 15);
                    IO.Writexy("│", x + 64, y + d);
                    IO.Writexy(list[i].ngayvaolam.ToString(), x + 65, y + d, 20);
                    IO.Writexy("│", x + 84, y + d);
                    IO.Writexy(list[i].pass.ToString(), x + 85, y + d, 18);
                    IO.Writexy("│", x + 102, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────────────┼─────────────────┼───────────────┼──────────────┼───────────────────┼─────────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────────────┴─────────────────┴───────────────┴──────────────┴───────────────────┴─────────────────┘", x, y + d - 1);
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

                IO.BoxTitle("   *** CÁC CHỨC NĂNG CỦA NHÂN VIÊN ***         ", 5, 1, 20, 56);
                IO.Writexy("*       1. Thêm nhân viên.                 *", 12, 5);
                IO.Writexy("*                                          *", 12, 6);
                IO.Writexy("*       2. Sửa nhân viên.                  *", 12, 7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*       3. Xóa nhân viên.                  *", 12, 9);
                IO.Writexy("*                                          *", 12, 10);
                IO.Writexy("*       4. Xem danh sách nhân viên.        *", 12, 11);
                IO.Writexy("*                                          *", 12, 12);
                IO.Writexy("*       5. Tìm kiếm nhân viên.             *", 12, 13);
                IO.Writexy("*                                          *", 12, 14);
                IO.Writexy("*       6. Quay lại.                       *", 12, 15);
                IO.Writexy("*                                          *", 12, 16);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *", 12, 17);
                IO.Writexy("********************************************", 12, 19);

                FormNhanVien NV = new FormNhanVien();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        NV.Nhap();
                        break;

                    case '2':
                        NV.Sua();
                        break;

                    case '3':
                        NV.Xoa();
                        break;

                    case '4':
                        NV.Xem();
                        break;

                    case '5':
                        NV.HienTim();
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

                IO.BoxTitle("       *** TÌM KIẾM NHÂN VIÊN ***         ", 5, 1, 12, 56);
                IO.Writexy("*     1. Tìm kiếm nhân viên theo mã.       *", 12, 5);
                IO.Writexy("*     2. Tìm kiếm nhân viên theo tên.      *", 12, 6);
                IO.Writexy("*     3. Quay lại.                         *", 12, 7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *", 12, 9);
                IO.Writexy("********************************************", 12, 10);

                FormNhanVien NV = new FormNhanVien();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        NV.TimMa();
                        break;

                    case '2':
                        NV.TimTen();
                        break;

                    case '3':
                        HienChucNang();
                        break;
                }
            } while (true);
        }
    }
}