using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Grocery.Utiility
{
    public class IO
    {
        public static string ReadPassword(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            string s = null;
            ConsoleKeyInfo kt;
            do
            {
                kt = Console.ReadKey(true);
                if (kt.Key != ConsoleKey.Enter && kt.Key != ConsoleKey.Escape && kt.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    s = s + kt.KeyChar.ToString();
                }
                else if (kt.Key == ConsoleKey.Backspace)
                {
                    Clear(x, y, s.Length, ConsoleColor.Black);
                    if (s.Length <= 1) s = "";
                    else s = s.Substring(0, s.Length - 1);
                    if (s == "") { Writexy(" ", x, y); Console.SetCursorPosition(x, y); }
                    else
                    {
                        int i = 0;
                        while (i < s.Length) { Writexy("*", x + i, y); i = i + 1; }

                    }
                }
            }
        }
    }
}
