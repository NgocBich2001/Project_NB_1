using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.Business;
using Grocery.Business.Interface;
using System.Collections.Generic;
using System.IO;

namespace Grocery.Presenation
{ 
    class FormThongKe
    {
        private string txtfileb = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\HOADONBAN.txt";
        private string txtfilen = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\HOADONNHAP.txt";
        public void TK_NgayBan()
        {
            string ngay = "";
            string s;
            double tongthu = 0;

            Console.Clear();
            IO.BoxTitle("                                    THỐNG KÊ KHOẢN THU THEO NGÀY", 1, 1, 10, 112);
            IO.Writexy("Nhập ngày cần thống kê:", 5, 4);
            IO.Writexy("--------------------------------------------------------------------------------------", 3, 7);
            IO.Writexy("Nhập ngày thống kê định dạng 'yyyy/mm/dd'!", 5, 8);

            do
            {
                Console.SetCursorPosition(29, 4);
                ngay = Console.ReadLine();
                if (ngay == "")
                {
                    IO.Clear(5,5, 60, ConsoleColor.Black);
                    IO.Writexy("Vui lòng nhập lại ngày bạn cần thống kê!", 5, 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(29, 4, 60, ConsoleColor.Black);
                }
            } while (ngay == "");

            StreamReader fb = new StreamReader(txtfileb);
            while ((s = fb.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                if (tmp[2] == ngay)
                { 
                    double tongban = double.Parse(tmp[3]);
                    tongthu += tongban;
                }
            }
            IO.Writexy("Khoản thu là:", 5, 6);
            IO.Writexy(tongthu.ToString(), 18, 6);
            fb.Close();

            IO.Clear(5, 5, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát!", 5, 5);
            Console.SetCursorPosition(29, 4);
        }
        public void TK_ThangBan()
        {
            string thang = "";
            string s;
            double tongthu = 0;

            Console.Clear();
            IO.BoxTitle("                                     THỐNG KÊ KHOẢN THU THEO NGÀY", 1, 1, 10, 112);
            IO.Writexy("Nhập tháng cần thống kê:", 5, 4);
            IO.Writexy("--------------------------------------------------------------------------------------", 3, 7);
            IO.Writexy("Nhập tháng thống kê định dạng 'yyyy/mm'!", 5, 8);

            do
            {
                Console.SetCursorPosition(29, 4);
                thang = Console.ReadLine();
                if (thang == "")
                {
                    IO.Clear(5, 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại tháng bạn cần thống kê!", 5, 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(29, 4, 60, ConsoleColor.Black);
                }
            } while (thang == "");

            StreamReader fb = new StreamReader(txtfileb);
            while ((s = fb.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                String[] d = tmp[2].Split('/');
                if ((d[0] + "/" + d[1]) == thang)
                {
                    double tongban = double.Parse(tmp[3]);
                    tongthu += tongban;
                }
            }
            IO.Writexy("Khoản thu là:", 5, 6);
            IO.Writexy(tongthu.ToString(), 18, 6);
            fb.Close();

            IO.Clear(5, 5, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát!", 5, 5);
            Console.SetCursorPosition(29, 4);
        }
        public void TK_NamBan()
        {
            string nam = "";
            string s;
            double tongthu = 0;

            Console.Clear();
            IO.BoxTitle("                                   THỐNG KÊ KHOẢN THU THEO NGÀY", 1, 1, 10, 112);
            IO.Writexy("Nhập năm cần thống kê:", 5, 4);
            IO.Writexy("--------------------------------------------------------------------------------------", 3, 7);
            IO.Writexy("Nhập năm thống kê định dạng 'yyyy'!", 5, 8);

            do
            {
                Console.SetCursorPosition(29, 4);
                nam = Console.ReadLine();
                if (nam == "" || Convert.ToInt16(nam) <= 0)
                {
                    IO.Clear(5, 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại năm bạn cần thống kê!", 5, 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(29, 4, 60, ConsoleColor.Black);
                }
            } while (nam == "" || Convert.ToInt16(nam) <= 0);

            StreamReader fb = new StreamReader(txtfileb);
            while ((s = fb.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                String[] d = tmp[2].Split('/');
                if (d[0] == nam)
                {
                    double tongban = double.Parse(tmp[3]);
                    tongthu += tongban;
                }
            }
            IO.Writexy("Khoản thu là:", 5, 6);
            IO.Writexy(tongthu.ToString(), 18, 6);
            fb.Close();

            IO.Clear(5, 5, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát!", 5, 5);
            Console.SetCursorPosition(29, 4);
        }
        public void TK_NgayNhap()
        {
            string ngay = "";
            string s;
            double tongchi = 0;

            Console.Clear();
            IO.BoxTitle("                                        THỐNG KÊ KHOẢN CHI THEO NGÀY", 1, 1, 10, 112);
            IO.Writexy("Nhập ngày cần thống kê:", 5, 4);
            IO.Writexy("--------------------------------------------------------------------------------------", 3, 7);
            IO.Writexy("Nhập ngày thống kê định dạng 'yyyy/mm/dd'!", 5, 8);

            do
            {
                Console.SetCursorPosition(29, 4);
                ngay = Console.ReadLine();
                if (ngay == "")
                {
                    IO.Clear(5, 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại ngày bạn cần thống kê!", 5, 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(29, 4, 60, ConsoleColor.Black);
                }
            } while (ngay == "");

            StreamReader fn = new StreamReader(txtfilen);
            while ((s = fn.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                if (tmp[4] == ngay)
                {                   
                    double tongnhap = double.Parse(tmp[5]);                  
                    tongchi += tongnhap;
                }
            }
            IO.Writexy("Khoản chi là:", 5, 6);
            IO.Writexy(tongchi.ToString(), 18, 6);
            fn.Close();

            IO.Clear(5, 5, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát!", 5, 5);
            Console.SetCursorPosition(29, 4);
        }
        public void TK_ThangNhap()
        {
            string thang = "";
            string s;
            double tongchi = 0;

            Console.Clear();
            IO.BoxTitle("                                     THỐNG KÊ KHOẢN CHI THEO NGÀY", 1, 1, 10, 112);
            IO.Writexy("Nhập tháng cần thống kê:", 5, 4);
            IO.Writexy("--------------------------------------------------------------------------------------", 3, 7);
            IO.Writexy("Nhập tháng thống kê định dạng 'yyyy/mm'!", 5, 8);

            do
            {
                Console.SetCursorPosition(29, 4);
                thang = Console.ReadLine();
                if (thang == "")
                {
                    IO.Clear(5, 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại tháng bạn cần thống kê!", 5, 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(29, 4, 60, ConsoleColor.Black);
                }
            } while (thang == "");

            StreamReader fn = new StreamReader(txtfilen);
            while ((s = fn.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                String[] d = tmp[4].Split('/');
                if ((d[0] + "/" + d[1]) == thang)
                {
                    double tongnhap = double.Parse(tmp[5]);
                    tongchi += tongnhap;
                }
            }
            IO.Writexy("Khoản thu là:", 5, 6);
            IO.Writexy(tongchi.ToString(), 18, 6);
            fn.Close();

            IO.Clear(5, 5, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát!", 5, 5);
            Console.SetCursorPosition(29, 4);
        }
        public void TK_NamNhap()
        {
            string nam = "";
            string s;
            double tongchi = 0;

            Console.Clear();
            IO.BoxTitle("                                    THỐNG KÊ KHOẢN CHI THEO NĂM", 1, 1, 10, 112);
            IO.Writexy("Nhập năm cần thống kê:", 5, 4);
            IO.Writexy("--------------------------------------------------------------------------------------", 3, 7);
            IO.Writexy("Nhập năm thống kê định dạng 'yyyy'!", 5, 8);

            do
            {
                Console.SetCursorPosition(29, 4);
                nam = Console.ReadLine();
                if (nam == "" || Convert.ToInt16(nam) <= 0)
                {
                    IO.Clear(5, 5, 60, ConsoleColor.Black);
                    IO.Writexy("Nhập lại năm bạn cần thống kê!", 5, 5, ConsoleColor.Black, ConsoleColor.White);
                    IO.Clear(29, 4, 60, ConsoleColor.Black);
                }
            } while (nam == "" || Convert.ToInt16(nam) <= 0);

            StreamReader fn = new StreamReader(txtfilen);
            while ((s = fn.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                String[] d = tmp[4].Split('/');
                if (d[0] == nam)
                {
                    double tongnhap = double.Parse(tmp[5]);
                    tongchi += tongnhap;
                }
            }
            IO.Writexy("Khoản chi là:", 5, 6);
            IO.Writexy(tongchi.ToString(), 18, 6);
            fn.Close();

            IO.Clear(5, 5, 60, ConsoleColor.Black);
            IO.Writexy("Nhấn Enter để thoát!", 5, 5);
            Console.SetCursorPosition(29, 4);
        }    
    }
}
