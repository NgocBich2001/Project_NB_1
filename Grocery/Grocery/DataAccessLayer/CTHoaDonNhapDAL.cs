using System;
using System.Text;
using Grocery.Utiility;
using System.Configuration;
using System.IO;
using Grocery.ThucThe;
using Grocery.DataAccessLayer.Interface;
using System.Collections.Generic;

namespace Grocery.DataAccessLayer
{
    class CTHoaDonNhapDAL : IDCTHoaDonNhapDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HOADONNHAP.txt
        private string txtfile5 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\CHITIETHOADONNHAP.txt";
        //private string txtfile = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\HOADONNHAP.txt";
      
        //Lấy toàn bộ dữ liệu có trong file HOADONNHAP.txt đưa vào một danh sách
        public List<CTHoaDonNhap> GetData()
        {
            List<CTHoaDonNhap> list = new List<CTHoaDonNhap>();
            StreamReader fread5 = File.OpenText(txtfile5);
            string s = fread5.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new CTHoaDonNhap(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), a[4], a[5], int.Parse(a[6]), a[7], double.Parse(a[8]), double.Parse(a[9])));

                }
                s = fread5.ReadLine();

            }
            fread5.Close();
            return list;
        }
        
        ////Chèn một bản ghi hóa đơn nhập vào tệp
        public void Insert(CTHoaDonNhap cthdn)
        {
            StreamWriter fwrite = File.AppendText(txtfile5);
            fwrite.WriteLine(cthdn.mahdn+ "\t" + cthdn.mahang + "\t" + cthdn.tenhang + "\t" + cthdn.đot + "\t" + cthdn.NSX + "\t" + cthdn.HSD + "\t" + cthdn.soluong + "\t" + cthdn.donvi + "\t" + cthdn.gianhap + "\t" + cthdn.thanhtien);
            fwrite.Close();
        }
       
        public void Delete(int mahdn)
        {
            List<CTHoaDonNhap> list = GetData();
            StreamWriter file = File.CreateText(txtfile5);
            foreach (CTHoaDonNhap cthdn in list)
                if (cthdn.mahdn != mahdn)
                    file.WriteLine(cthdn.mahdn + "\t" + cthdn.mahang + "\t" + cthdn.tenhang + "\t" + cthdn.đot + "\t" + cthdn.NSX + "\t" + cthdn.HSD + "\t" + cthdn.soluong + "\t" + cthdn.donvi + "\t" + cthdn.gianhap + "\t" + cthdn.thanhtien);
            file.Close();
        }


    }
}
