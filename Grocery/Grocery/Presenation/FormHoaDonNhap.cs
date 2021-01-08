using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                HoaDonNhapBLL hdnbll = new HoaDonNhapBLL();
                IFCTHoaDonNhapBLL ctn = new CTHoaDonNhapBLL();
                HoaDonNhap hoadn = new HoaDonNhap();
                HoaDonNhap HDN;
                HoaDonNhapBLL nbll = new HoaDonNhapBLL();
                CTHoaDonNhap cthdn = new CTHoaDonNhap();
                CTHoaDonNhapBLL ctnb = new CTHoaDonNhapBLL();
                HangHoaBLL hhbll = new HangHoaBLL();
                IFHangHoaBLL ihhbll = new HangHoaBLL();
                FormNhaCC fcc = new FormNhaCC();
                IFNhaCCBLL icc = new NhaCCBLL();
                NhaCCBLL ccbll = new NhaCCBLL();
                IFNhanVienBLL invbll = new NhanVienBLL();
                NhanVienBLL nvbll = new NhanVienBLL();
                FormNhanVien fnv = new FormNhanVien();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN HÓA ĐƠN NHẬP", 1, 1, 17, 100);
                IO.Writexy("Mã nhà cung cấp:", 5, 4);
                IO.Writexy("Nhân viên giao:", 5, 5);
                IO.Writexy("Mã nhân viên nhận:", 40, 5);
                IO.Writexy("Ngày nhận: ",5,6);
                IO.Writexy("--------------------------------------------------", 2, 7);
                IO.Writexy("Mã hàng:",5,8);
                IO.Writexy("Tên hàng:", 30, 8);
                IO.Writexy("Đợt nhập:", 5, 9);
                IO.Writexy("NSX:", 20, 9);
                IO.Writexy("HSD:", 40, 9);
                IO.Writexy("Số lượng:",25,10);
                IO.Writexy("Đơn vị:", 40, 10);
                IO.Writexy("Đơn giá nhập:",5,11);
                IO.Writexy("Thành tiền:", 40, 11);
                IO.Writexy("---------Tổng thanh toán-----------------------------", 2, 13);
                IO.Writexy("Tổng tiền:",5,14);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 15);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                
                fcc.Hien(1, 18,icc.XemDSNhaCC() , 5, 0);                              
                do
                {
                    hoadn.mancc = int.Parse(IO.ReadNumber(22, 4));
                    if(hoadn.mancc<0)
                    {
                        IO.Clear(5, 16, 99, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!",5,16);
                    }
                    else
                    {
                        if (ccbll.KiemTra(hoadn.mancc) == false)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhà cung cấp này!", 5, 16);

                        }
                        else
                            break;
                    }
                } while (hoadn.mancc < 0 || ccbll.KiemTra(hoadn.mancc) == false);
                
                IO.Clear(5, 16, 99, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                do
                {
                    hoadn.nvgiao = IO.ReadString(21, 5);
                    if (hoadn.nvgiao == null)
                    {
                        IO.Clear(5, 16, 99, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                    }
                } while (hoadn.nvgiao == null);

                IO.Clear(5, 16, 99, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                IO.Clear(1, 18, 99, ConsoleColor.Black);
                fnv.Hien(1, 18, invbll.XemDSNhanVien(), 5, 0);
                do
                {
                    hoadn.manvnhan = int.Parse(IO.ReadNumber(59, 5));
                    if (hoadn.manvnhan < 0)
                    {
                        IO.Clear(5, 16, 99, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                    }
                    else
                    {
                        if (nvbll.KiemTra(hoadn.manvnhan) == false)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Không tồn tại mã nhân viên này!", 5, 16);

                        }
                        else
                            break;
                    }
                } while (hoadn.manvnhan < 0 || nvbll.KiemTra(hoadn.manvnhan) == false);

                IO.Clear(5, 16, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                do
                {
                    hoadn.ngaynhan = IO.ReadString(15, 6);
                    if (hoadn.ngaynhan == null)
                    {
                        IO.Clear(5, 16, 99, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                    }
                } while (hoadn.ngaynhan == null);

                
                IO.Clear(5, 16, 99, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                hdn.ThemHoaDonNhap(hoadn);
                while (true)
                {
                    HDN = nbll.ReturnKey(hoadn.mancc, hoadn.nvgiao, hoadn.manvnhan, hoadn.ngaynhan);
                    cthdn.mahdn = HDN.mahdn;
                    do
                    {
                        IO.Clear(13, 8, 5, ConsoleColor.Black);
                        cthdn.mahang = int.Parse(IO.ReadNumber(14, 8));
                        if (cthdn.mahang < 0)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                        else
                        {
                            if (ctnb.KiemTraMaHang(cthdn.mahdn, cthdn.mahang) == true)
                            {
                                IO.Clear(5, 16, 99, ConsoleColor.Black);
                                IO.Writexy("Mã này đã tồn tại!", 5, 16);
                            }
                            else
                                break;
                        }
                    } while (cthdn.mahang < 0 || ctnb.KiemTraMaHang(cthdn.mahdn, cthdn.mahang) == true);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    do
                    {
                        IO.Clear(12, 9, 5, ConsoleColor.Black);
                        cthdn.tenhang = IO.ReadString(39, 8);
                        if (cthdn.tenhang ==null)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                        else
                        {
                            if (ctnb.KiemTraTen(cthdn.mahdn, cthdn.tenhang) == true)
                            {
                                IO.Clear(5, 16, 99, ConsoleColor.Black);
                                IO.Writexy("Mặt hàng này đã tồn tại!", 5, 16);
                            }
                            else
                                break;
                        }
                    } while (cthdn.tenhang==null || ctnb.KiemTraTen(cthdn.mahdn, cthdn.tenhang) == true);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    do
                    {
                        IO.Clear(13, 9, 5, ConsoleColor.Black);
                        cthdn.đot = int.Parse(IO.ReadNumber(14, 9));
                        if (cthdn.đot < 0 || ctnb.KiemTraDot(cthdn.tenhang, cthdn.đot) == true)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                    } while (cthdn.đot < 0 || ctnb.KiemTraDot(cthdn.tenhang, cthdn.đot) == true);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    do
                    {
                        IO.Clear(24, 9, 5, ConsoleColor.Black);
                        cthdn.NSX = IO.ReadString(25, 9);
                        if (cthdn.NSX == null)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                    } while (cthdn.NSX == null);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    do
                    {
                        IO.Clear(44, 9, 5, ConsoleColor.Black);
                        cthdn.HSD = IO.ReadString(45, 9);
                        if (cthdn.HSD == null)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                    } while (cthdn.HSD == null);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    do
                    {
                        IO.Clear(34, 10, 5, ConsoleColor.Black);
                        cthdn.soluong = int.Parse(IO.ReadNumber(35, 10));
                        if (cthdn.soluong < 0)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                    } while (cthdn.soluong < 0);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    do
                    {
                        IO.Clear(46, 10, 5, ConsoleColor.Black);
                        cthdn.donvi = IO.ReadString(47, 10);
                        if (cthdn.donvi == null)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                    } while (cthdn.donvi == null);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    do
                    {
                        IO.Clear(18, 11, 9, ConsoleColor.Black);
                        cthdn.gianhap = double.Parse(IO.ReadNumber(19, 11));
                        if (cthdn.gianhap < 0)
                        {
                            IO.Clear(5, 16, 99, ConsoleColor.Black);
                            IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 16);
                        }
                    } while (cthdn.gianhap < 0);

                    IO.Clear(5, 16, 99, ConsoleColor.Black);
                    IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 16);
                    IO.Writexy(cthdn.thanhtien.ToString(), 51, 11);
                    ctn.ThemCTHoaDonNhap(cthdn);

                    HangHoa hh = ihhbll.LayHangHoa(cthdn.mahang);
                    if (hhbll.KiemTra(cthdn.mahang) == true)
                        hhbll.CongSL(hh, cthdn.soluong);
                    else
                        cthdn.soluong = cthdn.soluong;

                    IO.Writexy("Nhấn B/b để nhập tiếp. Nhấn phím bất kỳ để dừng nhập!", 5, 12);
                    ConsoleKeyInfo b = Console.ReadKey();
                    if (b.KeyChar != 'b')
                        break;
                }
               
                IO.Writexy(hdnbll.TinhTong(cthdn.mahdn).ToString(), 17, 14);
                hoadn.tongtien = hdnbll.TinhTong(cthdn.mahdn);
                Console.SetCursorPosition(55, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 18, hdn.XemDSHoaDonNhap(), 5, 1);
                else if (kt.Key == ConsoleKey.Enter)
                {
                    hdn.XoaHoaDonNhap(cthdn.mahdn);
                    hdn.ThemHoaDonNhap(hoadn);
                    Hien(1, 18, hdn.XemDSHoaDonNhap(), 5, 0);
                }
            } while (true);
        }
       
        public void Xoa()
        {
            int mahdn = 0;
            do
            {
                Console.Clear();
                IFHoaDonNhapBLL hdn = new HoaDonNhapBLL();
                HoaDonNhapBLL HDNBLL = new HoaDonNhapBLL();
                IFCTHoaDonNhapBLL ctn = new CTHoaDonNhapBLL();
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
                    {
                        hdn.XoaHoaDonNhap(mahdn);
                        ctn.XoaCTHoaDonNhap(mahdn);
                    }
                    Console.Clear();
                    Hien(1, 8, hdn.XemDSHoaDonNhap(), 5, 1);
                } while (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
            } while (true);
        }
        public void Xem()
        {
            int mahdn = 0;
            do
            {
                HoaDonNhapBLL HDNBLL = new HoaDonNhapBLL();
                CTHoaDonNhapBLL ctnbll = new CTHoaDonNhapBLL();
                Console.Clear();
                IO.BoxTitle("                                TÌM KIẾM CHI TIẾT HÓA ĐƠN NHẬP", 1, 1, 7, 100);
                IO.Writexy("Nhập mã hóa đơn cần xem chi tiết:", 5, 4);
                Hien(1, 8, HDNBLL.XemDSHoaDonNhap(), 5, 0);
                
                do
                {
                    //Console.SetCursorPosition(34, 4);
                    mahdn = int.Parse(IO.ReadNumber(39, 4));
                    if (mahdn < 0 || ctnbll.KiemTra(mahdn) == false)
                    {
                        IO.Clear(35, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Kiểm tra thất bại. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<CTHoaDonNhap> list = ctnbll.TimCTHoaDonNhap(new CTHoaDonNhap(mahdn, 0, null, 0, null, null, 0, null, 0, 0));
                        HienCT(1, 8, list, 5, 1);
                    }
                } while (mahdn < 0 || ctnbll.KiemTra(mahdn) == false);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
            } while (true);
        }
        public void XemHDN()
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
                        List<HoaDonNhap> list = hdn.TimHoaDonNhap(new HoaDonNhap(mahdn, 0, null, 0, null, 0));
                        Hien(1, 8, list, 5, 1);
                    }    
                } while (mahdn < 0 || HDNBLL.KiemTra(mahdn) == false);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();
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
                IO.Writexy("┌────────┬─────────┬────────────────┬────────────┬────────────┬─────────────┐", x, y + 1);
                IO.Writexy("│ Mã HDN │ Mã NCC  │ Nhân viên giao │ Mã NV nhận │ Ngày nhận  │  Thành tiền │", x, y + 2);
                IO.Writexy("├────────┼─────────┼────────────────┼────────────┼────────────┼─────────────┤", x, y + 3);
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
                    IO.Writexy("│", x + 62, y + d);
                    IO.Writexy(list[i].tongtien.ToString(), x + 63, y + d, 13);
                    IO.Writexy("│", x + 76, y + d);
                    if (i < final - 1)
                        IO.Writexy("├────────┼─────────┼────────────────┼────────────┼────────────┼─────────────┼", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└────────┴─────────┴────────────────┴────────────┴────────────┴─────────────┘", x, y + d - 1);
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
        public void HienCT(int xx, int yy, List<CTHoaDonNhap> list, int n, int type)
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
                IO.Writexy("                           DANH SÁCH CHI TIẾT HÓA ĐƠN NHẬP", x, y);
                IO.Writexy("┌──────┬────┬────────────────┬────┬───────────┬───────────┬──────┬──────┬──────────┬─────────────┐", x, y + 1);
                IO.Writexy("│Mã HDN│ MH │    Tên hàng    │Đợt │    NSX    │    HSD    │  SL  │  ĐV  │ Giá nhập │ Thành tiền  │", x, y + 2);
                IO.Writexy("├──────┼────┼────────────────┼────┼───────────┼───────────┼──────┼──────┼──────────┼─────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 18);
                    IO.Writexy(list[i].mahdn.ToString(), x + 1, y + d, 6);
                    IO.Writexy("│", x + 7, y + d);
                    IO.Writexy(list[i].mahang.ToString(), x + 8, y + d, 4);
                    IO.Writexy("│", x + 12, y + d);
                    IO.Writexy(list[i].tenhang.ToString(), x + 13, y + d, 16);
                    IO.Writexy("│", x + 29, y + d);
                    IO.Writexy(list[i].đot.ToString(), x + 30, y + d, 4);
                    IO.Writexy("│", x + 34, y + d);
                    IO.Writexy(list[i].NSX.ToString(), x + 35, y + d, 11);
                    IO.Writexy("│", x + 46, y + d);
                    IO.Writexy(list[i].HSD.ToString(), x + 47, y + d, 11);
                    IO.Writexy("│", x + 58, y + d);
                    IO.Writexy(list[i].soluong.ToString(), x + 59, y + d, 6);
                    IO.Writexy("│", x + 65, y + d);
                    IO.Writexy(list[i].donvi.ToString(), x + 66, y + d, 6);
                    IO.Writexy("│", x + 72, y + d);
                    IO.Writexy(list[i].gianhap.ToString(), x + 73, y + d, 10);
                    IO.Writexy("│", x + 83, y + d);
                    IO.Writexy(list[i].thanhtien.ToString(), x + 84, y + d, 13);
                    IO.Writexy("│", x + 97, y + d);
                    if (i < final - 1)
                        IO.Writexy("├──────┼────┼────────────────┼────┼───────────┼───────────┼──────┼──────┼──────────┼─────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└──────┴────┴────────────────┴────┴───────────┴───────────┴──────┴──────┴──────────┴─────────────┘", x, y + d - 1);
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

                IO.BoxTitle("  *** CÁC CHỨC NĂNG CỦA HÓA ĐƠN NHẬP ***         ", 5, 1, 20, 65);
                IO.Writexy("*       1. Thêm hóa đơn nhập.                     *", 12, 5);
                IO.Writexy("*                                                 *", 12, 6);
                IO.Writexy("*       2. Xem danh sách hóa đơn nhập.            *", 12, 7);
                IO.Writexy("*                                                 *", 12, 8);
                IO.Writexy("*       3. Xóa hóa đơn nhập.                      *", 12, 9);
                IO.Writexy("*                                                 *", 12, 10);
                IO.Writexy("*       4. Xem danh sách chi tiết hóa đơn nhập.   *", 12, 11);
                IO.Writexy("*                                                 *", 12, 12);
                IO.Writexy("*       5. Tìm kiếm hóa đơn nhập.                 *", 12, 13);
                IO.Writexy("*                                                 *", 12, 14);
                IO.Writexy("*       6. Quay lại.                              *", 12, 15);
                IO.Writexy("*                                                 *", 12, 16);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!         *", 12, 17);
                IO.Writexy("***************************************************", 12, 19);

                FormHoaDonNhap HDN = new FormHoaDonNhap();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        HDN.Nhap();
                        break;

                    case '2':
                        XemHDN();
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