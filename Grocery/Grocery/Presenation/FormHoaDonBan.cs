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
    public class FormHoaDonBan
    {
        public void Nhap()
        {
            do
            {
                HoaDonBan hoadb = new HoaDonBan();
                IFHoaDonBanBLL hdb = new HoaDonBanBLL();
                HoaDonBanBLL hdbbll = new HoaDonBanBLL();
                IFNhanVienBLL inv = new NhanVienBLL();
                NhanVienBLL nvbll = new NhanVienBLL();
                FormNhanVien fnv = new FormNhanVien();
                FormHangHoa fhh = new FormHangHoa();
                IFHangHoaBLL ihh = new HangHoaBLL();
                HangHoaBLL hhbll = new HangHoaBLL();
                HoaDonBan HDB;
                CTHoaDonBan cthdb = new CTHoaDonBan();
                IFCTHoaDonBanBLL icthdn = new CTHoaDonBanBLL();
                FormHoaDonNhap fhdn = new FormHoaDonNhap();
                IFCTHoaDonNhapBLL ictn = new CTHoaDonNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN HÓA ĐƠN BÁN", 1, 1, 14, 100);
                IO.Writexy("Mã nhân viên bán:", 5, 4);
                IO.Writexy("Ngày bán:", 40, 4);
                IO.Writexy("------------Nhập chi tiết hóa đơn bán----------------", 2, 5);
                IO.Writexy("Mã hàng:", 5, 6);
                IO.Writexy("Số lượng: ", 30, 6);
                IO.Writexy("Đơn vị tính:", 50, 6);
                IO.Writexy("Giá bán:", 70, 6);               
                IO.Writexy("Thành tiền:", 5, 7);
                IO.Writexy("-----------------Tổng thanh toán----------------------", 2, 9);
                IO.Writexy("Tổng hóa đơn:", 5, 10);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 11);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                
                fnv.Hien(1, 16, inv.XemDSNhanVien(), 5, 0);
                do
                {
                    hoadb.manvban = int.Parse(IO.ReadNumber(24, 4));
                    if(hoadb.manvban <0 )
                    {
                        IO.Clear(5, 12, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                    }
                    else
                    {
                        if (nvbll.KiemTra(hoadb.manvban) == false)
                        {
                            IO.Clear(5, 12, 80, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhân viên này!", 5, 12);

                        }
                        else
                            break;
                    }
                } while (hoadb.manvban < 0 || nvbll.KiemTra(hoadb.manvban) == false);

                IO.Clear(5, 12, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                do
                {
                    hoadb.ngayban = IO.ReadString(50, 4);
                    if(hoadb.ngayban==null)
                    {
                        IO.Clear(5, 12, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                    }    
                } while (hoadb.ngayban == null);
                IO.Clear(5, 12, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                hdb.ThemHoaDonBan(hoadb);
                while (true)
                {
                    HDB = hdbbll.ReturnKey(hoadb.manvban, hoadb.ngayban);
                    cthdb.mahdb = HDB.mahdb;
                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    fhh.Hien(1, 16, ihh.XemDSHangHoa(), 5, 0);
                    do
                    {
                        IO.Clear(13, 6, 5, ConsoleColor.Black);
                        cthdb.mahang = int.Parse(IO.ReadNumber(14, 6));
                        if (cthdb.mahang < 0)
                        {
                            IO.Clear(5, 12, 80, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                        }
                        else
                        {
                            if (hhbll.KiemTra(cthdb.mahang) == false)
                            {
                                IO.Clear(5, 12, 80, ConsoleColor.Black);
                                IO.Writexy("Không tồn tại mã hàng này!", 5, 12);

                            }
                            else
                                break;
                        }
                    } while (cthdb.mahang < 0 || hhbll.KiemTra(cthdb.mahang) == false);
                    IO.Clear(5, 12, 80, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                    do
                    {
                        IO.Clear(39, 6, 5, ConsoleColor.Black);
                        cthdb.soluong = int.Parse(IO.ReadNumber(40, 6));
                        if (cthdb.soluong < 0)
                        {
                            IO.Clear(5, 12, 80, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                        }
                    } while (cthdb.soluong < 0);
                    IO.Clear(5, 12, 80, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    fhdn.HienCT(1, 16, ictn.XemDSCTHoaDonNhap(), 5, 0);
                    do
                    {
                        IO.Clear(62, 6, 5, ConsoleColor.Black);
                        cthdb.donvi = IO.ReadString(63, 6);
                        if (cthdb.donvi == null)
                        {
                            IO.Clear(5, 12, 80, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 12);
                        }
                    } while (cthdb.donvi == null);
                    IO.Clear(5, 12, 80, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 12);
                    
                    HangHoa ghh = hhbll.ReturnGiaBan(cthdb.mahang);
                    IO.Writexy(ghh.giaban.ToString(), 79, 6);
                    cthdb.giaban = ghh.giaban;

                    IO.Writexy(cthdb.thanhtien.ToString(), 17, 7);
                    icthdn.ThemCTHoaDonBan(cthdb);

                    HangHoa hh = ihh.LayHangHoa(cthdb.mahang);
                    if (hhbll.KiemTra(cthdb.mahang) == true)
                        hhbll.TruSL(hh, cthdb.soluong);
                    else
                        cthdb.soluong = cthdb.soluong;

                    IO.Writexy("Nhấn B/b để nhập tiếp. Nhấn phím bất kỳ để dừng nhập!", 5, 8);
                    ConsoleKeyInfo b = Console.ReadKey();
                    if (b.KeyChar != 'b')
                        break;
                }
                IO.Writexy(hdbbll.TinhTong(cthdb.mahdb).ToString(), 19, 10);
                hoadb.tongtien = hdbbll.TinhTong(cthdb.mahdb);
                Console.SetCursorPosition(55, 12);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 16, hdb.XemDSHoaDonBan(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    hdb.XoaHoaDonBan(cthdb.mahdb);
                    hdb.ThemHoaDonBan(hoadb);
                    Hien(1, 16, hdb.XemDSHoaDonBan(), 5, 0);
                }
            } while (true);
        }
        
        public void Xoa()
        {
            int mahdb = 0;
            do
            {
                Console.Clear();
                IFHoaDonBanBLL hdb = new HoaDonBanBLL();
                HoaDonBanBLL HDBBLL = new HoaDonBanBLL();
                IFCTHoaDonBanBLL ctb = new CTHoaDonBanBLL();
                Console.Clear();
                IO.BoxTitle("                                  XÓA HÓA ĐƠN BÁN", 1, 1, 7, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần xóa:", 5, 4);
                Hien(1, 8, hdb.XemDSHoaDonBan(), 5, 0);
                do
                {
                    mahdb = int.Parse(IO.ReadNumber(35, 4));
                    if (mahdb < 0 || HDBBLL.KiemTra(mahdb) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã hóa đơn bán này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        hdb.XoaHoaDonBan(mahdb);
                        ctb.XoaCTHoaDonBan(mahdb);
                    }
                    Console.Clear();
                    Hien(1, 8, hdb.XemDSHoaDonBan(), 5, 1);
                } while (mahdb < 0 || HDBBLL.KiemTra(mahdb) == false);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
            } while (true);
        }
        public void Xem()
        {
            int mahdb = 0;
            do
            {
                IFHoaDonBanBLL hdb = new HoaDonBanBLL();
                HoaDonBanBLL HDBBLL = new HoaDonBanBLL();
                IFCTHoaDonBanBLL ctb = new CTHoaDonBanBLL();
                CTHoaDonBanBLL ctbbll = new CTHoaDonBanBLL();
                Console.Clear();
                IO.BoxTitle("                                TÌM KIẾM CHI TIẾT HÓA ĐƠN BÁN", 1, 1, 8, 100);
                IO.Writexy("Nhập mã hóa đơn cần xem chi tiết:", 5, 4);
                Hien(1, 10, HDBBLL.XemDSHoaDonBan(), 5, 0);

                do
                {
                    //Console.SetCursorPosition(34, 4);
                    mahdb = int.Parse(IO.ReadNumber(40, 4));
                    if (mahdb < 0 || ctbbll.KiemTra(mahdb) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Kiểm tra thất bại. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<CTHoaDonBan> list = ctbbll.TimCTHoaDonBan(new CTHoaDonBan(mahdb, 0, 0, null, 0, 0));
                        HienCT(1, 10, list, 5, 1);
                    }
                } while (mahdb < 0 || ctbbll.KiemTra(mahdb) == false);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
            } while (true);
        }
        public void XemHDB()
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
                HoaDonBanBLL HDBBLL = new HoaDonBanBLL();
                Console.Clear();
                IO.BoxTitle("                                TÌM KIẾM HÓA ĐƠN BÁN", 1, 1, 8, 100);
                IO.Writexy("Nhập mã hóa đơn bán cần tìm:", 5, 4);
                Hien(1, 10, hdb.XemDSHoaDonBan(), 5, 0);
                do
                {
                    mahdb = int.Parse(IO.ReadNumber(35, 4));
                    if (mahdb < 0 || HDBBLL.KiemTra(mahdb) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã hóa đơn bán này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<HoaDonBan> list = hdb.TimHoaDonBan(new HoaDonBan(mahdb, 0, null, 0));
                        Hien(1, 10, list, 5, 1);
                    }
                } while (mahdb < 0 || HDBBLL.KiemTra(mahdb) == false);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
            } while (true);
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
                IO.Clear(xx, yy, 1800, ConsoleColor.Black);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                                   DANH SÁCH HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌────────┬───────────┬────────────┬────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDB │ Mã NV bán │  Ngày bán  │ Thành tiền │", x, y + 2);
                IO.Writexy("├────────┼───────────┼────────────┼────────────┤", x, y + 3);
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
                    IO.Writexy(list[i].tongtien.ToString(), x + 35, y + d, 12);                   
                    IO.Writexy("│", x + 47, y + d);
                    if (i < final - 1)
                        IO.Writexy("├────────┼───────────┼────────────┼────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└────────┴───────────┴────────────┴────────────┘", x, y + d - 1);
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
        public void HienCT(int xx, int yy, List<CTHoaDonBan> list, int n, int type)
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
                IO.Writexy("                                   DANH SÁCH HÓA ĐƠN BÁN", x, y);
                IO.Writexy("┌────────┬───────────┬──────────┬──────────┬─────────────┬────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDB │ Mã hàng   │ Số lượng │ ĐV tính  │  Giá bán    │ Thành tiền │", x, y + 2);
                IO.Writexy("├────────┼───────────┼──────────┼──────────┼─────────────┼────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 18);
                    IO.Writexy(list[i].mahdb.ToString(), x + 1, y + d, 8);               
                    IO.Writexy("│", x + 9, y + d);
                    IO.Writexy(list[i].mahang.ToString(), x + 10, y + d, 11);
                    IO.Writexy("│", x + 21, y + d);
                    IO.Writexy(list[i].soluong.ToString(), x + 22, y + d, 10);
                    IO.Writexy("│", x + 32, y + d);
                    IO.Writexy(list[i].donvi.ToString(), x + 33, y + d, 10);
                    IO.Writexy("│", x + 43, y + d);
                    IO.Writexy(list[i].giaban.ToString(), x + 44, y + d, 13);
                    IO.Writexy("│", x + 57, y + d);                  
                    IO.Writexy(list[i].thanhtien.ToString(), x + 58, y + d, 12);
                    IO.Writexy("│", x + 70, y + d);
                    if (i < final - 1)
                        IO.Writexy("├────────┼───────────┼──────────┼──────────┼─────────────┼────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└────────┴───────────┴──────────┴──────────┴─────────────┴────────────┘", x, y + d - 1);
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

                IO.BoxTitle("     *** CÁC CHỨC NĂNG CỦA HÓA ĐƠN BÁN ***         ", 5, 1, 20, 65);
                IO.Writexy("*       1. Thêm hóa đơn bán.                        *", 12, 5);
                IO.Writexy("*                                                   *", 12, 6);
                IO.Writexy("*       2. Xem danh sách hóa đơn bán.               *", 12, 7);
                IO.Writexy("*                                                   *", 12, 8);
                IO.Writexy("*       3. Xóa hóa đơn bán.                         *", 12, 9);
                IO.Writexy("*                                                   *", 12, 10);
                IO.Writexy("*       4. Xem danh sách chi tiết hóa đơn bán.      *", 12, 11);
                IO.Writexy("*                                                   *", 12, 12);
                IO.Writexy("*       5. Tìm kiếm hóa đơn bán.                    *", 12, 13);
                IO.Writexy("*                                                   *", 12, 14);
                IO.Writexy("*       6. Quay lại.                                *", 12, 15);
                IO.Writexy("*                                                   *", 12, 16);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!           *", 12, 17);
                IO.Writexy("*****************************************************", 12, 19);

                FormHoaDonBan HDB = new FormHoaDonBan();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        HDB.Nhap();
                        break;

                    case '2':
                        XemHDB();
                        break;

                    case '3':
                        HDB.Xoa();
                        break;

                    case '4':
                        HDB.Xem();
                        break;

                    case '5':
                        HDB.TimMa();
                        break;

                    case '6':
                        FormMenuMain.HienThi();
                        break;
                }
            } while (true);
        }
    }
}