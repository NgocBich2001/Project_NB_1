using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Grocery.Utiility
{
    public abstract class Menu
    {
        public abstract void ThucHien(int vitri);
        private string[] mn;
        public Menu(string [] mn)
        {
            this.mn = mn;
        }    
        public int MaxMuc()
        {
            int max = mn[0].Length;
            for (int i = 1; i < mn.Length; ++i)
                if (max < mn[i].Length)
                    max = mn[i].Length;
            return max;
        }    
        public void ChuanHoaMenu()
        {
            int max = MaxMuc();
            for (int i = 0; i < mn.Length; ++i)
                mn[i] = Grocery.Utiility.CongCu.ChuanHoaXau(mn[i], max);
        }    
        public void Writexy(int x, int y, int vitri, ConsoleColor maunen, ConsoleColor mauchu)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = maunen;
            Console.ForegroundColor = mauchu;
            Console.Write(mn[vitri]);
        }
        public void Writexy(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public void HienTheoPhimTat(int x, int y, ConsoleColor maunen, ConsoleColor mauchu)
        {
            ChuanHoaMenu();
            IO.BoxTitle("      CAC CHUC NANG CHINH", x, y, mn.Length * 2 + 5, MaxMuc() + 46);
            x = x + 5;
            y = y + 3;
            for (int i = 0; i < mn.Length; ++i)
                Writexy(x, y + i * 2, i, maunen, mauchu);
             IO.Writexy("Hay chon mot chuc nang de thuc hien!", x, y + mn.Length * 2);
            ConsoleKeyInfo kt = Console.ReadKey();
            string[] key = new string[mn.Length];
            for (int i = 0; i < mn.Length; ++i)
                key[i] = mn[i].Substring(0, mn[i].IndexOf(":"));
            for (int i = 0; i < key.Length; ++i)
                if (kt.Key.ToString() == key[i])
                    ThucHien(i);
        }
    }
}
