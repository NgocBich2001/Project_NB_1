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
    class HoaDonNhapDAL : IDHoaDonNhapDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HOADONNHAP.txt
        
        private string txtfile5 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\HOADONNHAP.txt";
        private string txtfile = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\CHITIETHOADONNHAP.txt";
        //Lấy toàn bộ dữ liệu có trong file HOADONNHAP.txt đưa vào một danh sách
        public List<HoaDonNhap> GetData()
        {
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            StreamReader fread5 = File.OpenText(txtfile5);
            string s = fread5.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new HoaDonNhap(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), a[4], double.Parse(a[5])));

                }
                s = fread5.ReadLine();

            }
            fread5.Close();
            return list;
        }
        //Lấy mã hóa đơn nhập của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int mahdn
        {
            get
            {
                StreamReader fread5 = File.OpenText(txtfile5);
                string s = fread5.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = fread5.ReadLine();
                }
                fread5.Close();
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
        //Chèn một bản ghi hóa đơn nhập vào tệp
        public void Insert(HoaDonNhap hdn)
        {
            int manhap = mahdn + 1;
            StreamWriter fwrite = File.AppendText(txtfile5);
            fwrite.WriteLine(manhap + "\t" + hdn.mancc + "\t" + hdn.nvgiao + "\t" + hdn.manvnhan + "\t" + hdn.ngaynhan + "\t" + hdn.tongtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(HoaDonNhap hdn)
        {
            List<HoaDonNhap> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].mahdn == hdn.mahdn)
                {
                    list[i] = hdn;
                    break;
                }
            StreamWriter fwrite = File.CreateText(txtfile5);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahdn + "\t" + list[i].mancc + "\t" + list[i].nvgiao + "\t" + list[i].manvnhan + "\t" + list[i].ngaynhan + "\t" + list[i].tongtien); 
            fwrite.Close();
        }
        public void Delete(int mahdn)
        {
            List<HoaDonNhap> list = GetData();
            StreamWriter file = File.CreateText(txtfile5);
            foreach (HoaDonNhap hdn in list)
                if (hdn.mahdn != mahdn)
                    file.WriteLine(hdn.mahdn + "\t" + hdn.mancc + "\t" + hdn.nvgiao + "\t" + hdn.manvnhan + "\t" + hdn.ngaynhan + "\t" + hdn.tongtien);
            file.Close();
        }
        public double TongTien(int mahdn)
        {
            StreamReader sr = new StreamReader(txtfile5);
            
            string s;
            double TongTien = 0;

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                if (tmp[0] == mahdn.ToString())
                {
                    StreamReader sr1 = new StreamReader(txtfile);
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null)
                    {
                        string[] tmp1 = s1.Split('\t');
                        if (tmp1[0] == tmp[0])
                        {
                            double tt = double.Parse(tmp1[9]);
                            TongTien += tt;
                        }
                    }
                    sr1.Close();
                }
            }
            sr.Close();
            return TongTien;
        }
    }
}
