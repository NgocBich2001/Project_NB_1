using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Utiility
{
    public static class CongCu
    {
        public static string ChuanHoaXau(string xau)
        {
            string x = xau.Trim();
            while (x.IndexOf("  ") >= 0) //vị trí xuất hiện đầu tiên của một chuỗi xác định trong chuỗi.
                x = x.Remove(x.IndexOf("  "), 1);
            string[] a = x.Split(' ');//Split_Phân tích chuỗi ra thành các chuỗi con, trả về một mảng những chuỗi con được phân định bởi 1 khoảng trắng.
            x = "";
            for (int i = 0; i < a.Length; ++i)
                x = x + " " + char.ToUpper(a[i][0]) + a[i].Substring(1).ToLower();//Trả về bản sao của chuỗi ở kiểu chữ....
            return x.Trim();
        }

        public static string CatXau(string xau)
        {
            string x = xau.Trim();
            while (x.IndexOf("  ") >= 0) 
                x = x.Remove(x.IndexOf("  "), 1);
            return x;
        }  
        

    }
}
