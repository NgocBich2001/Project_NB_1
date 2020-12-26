using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;
using System.Collections.Generic;
using Grocery.Presenation;

namespace Grocery.Presenation
{
    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt ra trong Interface của Business
    public class FormHangHoa
    {
        public void Nhap()//Tạo giao diện Nhap.
        {
            do
            {
                IFHangHoaBLL hanghoa = new HangHoaBLL();
                HangHoa hh = new HangHoa();
                Console.Clear();
                IO.BoxTitle("                                    NHẬP THÔNG TIN HÀNG HÓA", 1, 1, 10, 100);
                IO.Writexy("Tên hàng:", 5, 4);
                IO.Writexy("Số lượng nhập:", 5, 6);
                IO.Writexy("Số lượng còn:", 55, 6);
                IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                Hien(1, 13, hanghoa.XemDSHangHoa(), 5, 0);
                
                do
                {
                    hh.tenhang = IO.ReadString(15, 4);
                    if (hh.tenhang == null)
                    {
                        IO.Clear(5, 8, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 8);
                    }
                } while (hh.tenhang == null);
                IO.Clear(5, 8, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                do
                {
                    hh.slnhapve = int.Parse(IO.ReadNumber(20, 6));
                    if (hh.slnhapve <= 0)
                    {
                        IO.Clear(5, 8, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 8);
                    }
                } while (hh.slnhapve <= 0);
                IO.Clear(5, 8, 80, ConsoleColor.Black);
                IO.Writexy("Enter để nhập, Esc để thoát, X để xem chi tiết...", 5, 8);
                do
                {
                    hh.slhienco = int.Parse(IO.ReadNumber(69, 6));
                    if (hh.slhienco < 0)
                    {
                        IO.Clear(5, 8, 80, ConsoleColor.Black);
                        IO.Writexy("Nhập sai. Xin vui lòng nhập lại!", 5, 8);
                    }
                } while (hh.slhienco < 0);
                Console.SetCursorPosition(54, 8);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape)
                    HienChucNang();//Quay về màn hình chính.
                else if (kt.Key == ConsoleKey.X)
                    Hien(1, 13, hanghoa.XemDSHangHoa(), 5, 1);//Hiện danh sách.
                else if (kt.Key == ConsoleKey.Enter)
                    hanghoa.ThemHangHoa(hh);// Sau khi nhập xong chuyển đối tượng hh sang hanghoa của tầng business.
            } while (true);
        }
        public void Sua()
        {
            IFHangHoaBLL hanghoa = new HangHoaBLL();
            HangHoaBLL hhBLL = new HangHoaBLL();
            Console.Clear();
            IO.BoxTitle("                                   SỬA THÔNG TIN HÀNG HÓA", 1, 1, 10, 100);
            IO.Writexy("Mã HH:", 3, 4);
            IO.Writexy("Tên hàng:", 55, 4);
            IO.Writexy("Số lượng nhập:", 3, 6);
            IO.Writexy("Số lượng còn:", 63, 6);
            IO.Writexy("--------------------------------------------------------------------------------------------------", 2, 7);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            Hien(1, 13, hanghoa.XemDSHangHoa(), 5, 0);

            int mahh;
            string tenhang;
            int sln;
            int slc;
            do
            {
                mahh = int.Parse(IO.ReadNumber(10, 4));
                if (mahh < 0 || hhBLL.KiemTra(mahh) == false)
                {
                    IO.Clear(5, 8, 80, ConsoleColor.Black);
                    IO.Writexy("Không tồn tại mã hàng này. Vui lòng kiểm tra lại!",5,8);
                }    
            } while (mahh < 0 || hhBLL.KiemTra(mahh) == false);
            IO.Clear(5, 8, 80, ConsoleColor.Black);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            HangHoa hh = hanghoa.LayHangHoa(mahh);
            IO.Writexy(hh.tenhang, 65, 4);
            IO.Writexy(hh.slnhapve.ToString(), 18, 6);
            IO.Writexy(hh.slhienco.ToString(), 77, 6);
            IO.Clear(5, 8, 80, ConsoleColor.Black);
            IO.Writexy("Enter để cập nhật, Esc để thoát, X để xem chi tiết...", 5, 8);
            

            tenhang = IO.ReadString(65, 4);
            if (tenhang != hh.tenhang && tenhang != null)
                hh.tenhang = tenhang;
            sln = int.Parse(IO.ReadNumber(18, 6));
            if (sln != hh.slnhapve && sln > 0)
                hh.slnhapve = sln;
            slc = int.Parse(IO.ReadNumber(77, 6));
            if (slc != hh.slhienco && slc >= 0)
                hh.slhienco = slc;

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
            HangHoaBLL hhBLL = new HangHoaBLL();
            int mahh = 0;
            do
            {
                Console.Clear();
                IFHangHoaBLL hanghoa = new HangHoaBLL();
                Console.Clear();
                IO.BoxTitle("                                        XÓA HÀNG HÓA", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hàng hóa cần xóa:", 5, 4);
                Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 0);
                do
                {
                    mahh = int.Parse(IO.ReadNumber(31, 4));
                    if (mahh < 0 || hhBLL.KiemTra(mahh) == false)
                    {
                        IO.Clear(31, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã hàng này. Vui lòng kiểm tra lại!", 5, 8);
                    }
                    else
                        hanghoa.XoaHangHoa(mahh);
                    Console.Clear();
                    Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 1);
                } while (mahh < 0 || hhBLL.KiemTra(mahh) == false);
            } while (true);
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
                HangHoaBLL hhBLL = new HangHoaBLL();
                Console.Clear();
                IO.BoxTitle("                               TÌM KIẾM HÀNG HÓA THEO TÊN", 1, 1, 5, 100);
                IO.Writexy("Nhập tên hàng hóa cần tìm:", 5, 4);
                Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 0);
                do
                {
                    tenhh = IO.ReadString(33, 4);
                    if (tenhh ==null || hhBLL.KiemTraTen(tenhh) == false)
                    {
                        IO.Clear(33, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại tên hàng này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<HangHoa> list = hanghoa.TimHangHoa(new HangHoa(0, tenhh, 0, 0));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (tenhh == null || hhBLL.KiemTraTen(tenhh) == false);
                
            } while (true);
        }
        public void TimMa()
        {
            int mahh = 0;
            do
            {
                Console.Clear();
                IFHangHoaBLL hanghoa = new HangHoaBLL();
                HangHoaBLL hhBLL = new HangHoaBLL();
                Console.Clear();
                IO.BoxTitle("                               TÌM KIẾM HÀNG HÓA THEO MÃ", 1, 1, 5, 100);
                IO.Writexy("Nhập mã hàng hóa cần tìm:", 3, 4);
                Hien(1, 8, hanghoa.XemDSHangHoa(), 5, 0);
                do
                {
                    mahh = int.Parse(IO.ReadNumber(29, 4));
                    if (mahh < 0 || hhBLL.KiemTra(mahh) == false)
                    {
                        IO.Clear(29, 4, 60, ConsoleColor.Black);
                        IO.Writexy("Không tồn tại mã hàng này. Vui lòng kiểm tra lại!", 5, 6);
                    }
                    else
                    {
                        List<HangHoa> list = hanghoa.TimHangHoa(new HangHoa(mahh, null, 0, 0));
                        Hien(1, 8, list, 5, 1);
                    }
                } while (mahh < 0 || hhBLL.KiemTra(mahh) == false);
            } while (true);
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
                IO.Clear(xx, yy, 1800, ConsoleColor.Black);
                head = (curpage - 1) * n;
                final = curpage * n < list.Count ? curpage * n : list.Count;
                x = xx;
                y = yy;
                d = 0;
                IO.Writexy("                      DANH SÁCH HÀNG HÓA", x, y);
                IO.Writexy("┌─────────────┬────────────────┬───────────────┬──────────────┐", x, y + 1);
                IO.Writexy("│ Mã hàng hóa │  Tên hàng hóa  │ Số lượng nhập │ Số lượng còn │", x, y + 2);
                IO.Writexy("├─────────────┼────────────────┼───────────────┼──────────────┤", x, y + 3);
                y += 4;
                for (int i = head; i < final; i++)
                {
                    IO.Writexy("│", x, y + d, 14);
                    IO.Writexy(list[i].mahh.ToString(), x + 1, y + d, 14);
                    IO.Writexy("│", x + 14, y + d);
                    IO.Writexy(list[i].tenhang.ToString(), x + 15, y + d, 17);
                    IO.Writexy("│", x + 31, y + d);
                    IO.Writexy(list[i].slnhapve.ToString(), x + 32, y + d, 16);
                    IO.Writexy("│", x + 47, y + d);
                    IO.Writexy(list[i].slhienco.ToString(), x + 48, y + d, 15);
                    IO.Writexy("│", x + 62, y + d);
                    if (i < final - 1)
                        IO.Writexy("├─────────────┼────────────────┼───────────────┼──────────────┤", x, y + d + 1);
                    y += 1;
                    d += 1;
                }
                IO.Writexy("└─────────────┴────────────────┴───────────────┴──────────────┘", x, y + d - 1);
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

                IO.BoxTitle("     *** CÁC CHỨC NĂNG CỦA HÀNG HÓA ***         ", 5, 1, 20, 56);
                IO.Writexy("*       1. Thêm hàng hóa.                  *", 12, 5);
                IO.Writexy("*                                          *", 12, 6);
                IO.Writexy("*       2. Sửa hàng hóa.                   *", 12, 7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*       3. Xóa hàng hóa.                   *", 12, 9);
                IO.Writexy("*                                          *", 12, 10);
                IO.Writexy("*       4. Xem danh sách hàng hóa.         *", 12, 11);
                IO.Writexy("*                                          *", 12, 12);
                IO.Writexy("*       5. Tìm kiếm hàng hóa.              *", 12, 13);
                IO.Writexy("*                                          *", 12, 14);
                IO.Writexy("*       6. Quay lại.                       *", 12, 15);
                IO.Writexy("*                                          *", 12, 16);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *", 12, 17);
                IO.Writexy("********************************************", 12, 19);

                FormHangHoa hanghoa = new FormHangHoa();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        hanghoa.Nhap();
                        break;

                    case '2':
                        hanghoa.Sua();
                        break;

                    case '3':
                        hanghoa.Xoa();
                        break;
                    case '4':
                        hanghoa.Xem();
                        break;
                    case '5':
                        hanghoa.HienTim();
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

                IO.BoxTitle("           *** TÌM KIẾM HÀNG HÓA ***         ", 5, 1, 12, 56);
                IO.Writexy("*       1. Tìm kiếm hàng hóa theo mã.      *", 12, 5);
                IO.Writexy("*       2. Tìm kiếm hàng hóa theo tên.     *", 12, 6);
                IO.Writexy("*       3. Quay lại.                       *", 12, 7);
                IO.Writexy("*                                          *", 12, 8);
                IO.Writexy("*    Hãy chọn một chức năng để thực hiện!  *", 12, 9);
                IO.Writexy("********************************************", 12, 10);

                FormHangHoa hanghoa = new FormHangHoa();
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.KeyChar)

                {
                    case '1':
                        hanghoa.TimMa();
                        break;

                    case '2':
                        hanghoa.TimTen();
                        break;

                    case '3':
                        HienChucNang();
                        break;
                }
            } while (true);
        }

    }
}