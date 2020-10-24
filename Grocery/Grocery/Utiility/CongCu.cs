﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Utiility
{
    public static  class CongCu
    {
        public static string ChuanHoaXau(string xau)
        {
            string x = xau.Trim();
            while (x.IndexOf("  ") >= 0) 
                x = x.Remove(x.IndexOf("  "), 1);
            string[] a = x.Split(' ');
            x = "";
            for (int i = 0; i < a.Length; ++i)
                x = x + " " + char.ToUpper(a[i][0]) + a[i].Substring(1).ToLower();
            return x.Trim();
        }
        public static string CatXau(string xau)
        {
            string x = xau.Trim();
            while (x.IndexOf("  ") >= 0) 
                x = x.Remove(x.IndexOf("  "), 1);
            return x;
        }   
        public static string ChuanHoaXau(string xau, int max)
        {
            string x = CatXau(xau);
            while (x.Length < max)
                x = x + " ";
            return x;
        }
    }
}