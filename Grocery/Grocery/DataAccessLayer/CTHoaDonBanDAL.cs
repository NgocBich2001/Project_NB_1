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
    class CTHoaDonBanDAL : IDCTHoaDonBanDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HOADONNHAP.txt
        private string txtfile5 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\CHITIETHOADONBAN.txt";

        //Lấy toàn bộ dữ liệu có trong file HOADONNHAP.txt đưa vào một danh sách
        public List<CTHoaDonBan> GetData()
        {
            List<CTHoaDonBan> list = new List<CTHoaDonBan>();
            StreamReader fread5 = File.OpenText(txtfile5);
            string s = fread5.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new CTHoaDonBan(int.Parse(a[0]), int.Parse(a[1]),int.Parse(a[2]), a[3], double.Parse(a[4]), double.Parse(a[5])));

                }
                s = fread5.ReadLine();

            }
            fread5.Close();
            return list;
        }

        public void Insert(CTHoaDonBan cthdb)
        {
            StreamWriter fwrite = File.AppendText(txtfile5);
            fwrite.WriteLine(cthdb.mahdb + "\t" + cthdb.mahang + "\t" + cthdb.soluong + "\t" + cthdb.donvi + "\t" + cthdb.giaban + "\t" + cthdb.thanhtien);
            fwrite.Close();
        }
        
        public void Delete(int mahdb)
        {
            List<CTHoaDonBan> list = GetData();
            StreamWriter file = File.CreateText(txtfile5);
            foreach (CTHoaDonBan cthdb in list)
                if (cthdb.mahdb != mahdb)
                    file.WriteLine(cthdb.mahdb + "\t" + cthdb.mahang + "\t" + cthdb.soluong + "\t" + cthdb.donvi + "\t" + cthdb.giaban + "\t" + cthdb.thanhtien);
            file.Close();
        }


    }
}
