﻿using System;
using System.Text;
using Grocery.Utiility;
using System.Configuration;
using System.IO;
using Grocery.ThucThe;
using Grocery.DataAccessLayer.Interface;

namespace Grocery.DataAccessLayer
{
    class HoaDonBanDAL : IDHoaDonBanDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HOADONBAN.txt
        private string txtfile6 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\HOADONBAN.txt";
        //Lấy toàn bộ dữ liệu có trong file HOADONBAN.txt đưa vào một danh sách
        public List<HoaDonBan> GetData()
        {
            List<HoaDonBan> list = new List<HoaDonBan>();
            StreamReader fread6 = File.OpenText(txtfile6);
            string s = fread6.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new HoaDonBan(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), int.Parse(a[4]), double .Parse(a[5]), a[6], double.Parse(a[7])));

                }
                s = fread6.ReadLine();

            }
            fread6.Close();
            return list;
        }
        //Lấy mã hóa đơn bán của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int mahdb
        {
            get
            {
                StreamReader fread6 = File.OpenText(txtfile6);
                string s = fread6.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = fread6.ReadLine();
                }
                fread6.Close();
                if (tmp == "")
                    return 0;
                else
                {
                    tmp = Grocery.Utiility.CongCu.ChuanHoaXau(tmp);
                    string[] a = tmp.Split("\t");
                    return int.Parse(a[0]);
                }
            }
        }
        //Chèn một bản ghi hóa đơn bán vào tệp
        public void Insert(HoaDonBan hdb)
        {
            int mahdban = mahdb + 1;
            StreamWriter fwrite = File.AppendText(txtfile6);
            fwrite.WriteLine();
            fwrite.Write(mahdban + "\t" + hdb.manvban + "\t" + hdb.ngayban + "\t" + hdb.mahang + "\t" + hdb.soluong + "\t" + hdb.giaban + "\t" + hdb.donvi + "\t" + hdb.thanhtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HoaDonBan> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile6);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahdb + "\t" + list[i].manvban + "\t" + list[i].ngayban + "\t" + list[i].mahang + "\t" + list[i].soluong + "\t" + list[i].giaban + "\t" + list[i].donvi + "\t" + list[i].thanhtien);
            fwrite.Close();
        }
    }
}
