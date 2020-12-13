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
    class NhaCCDAL : IDNhaCCDAL
    {
        //Xác định đường dẫn của tệp dữ liệu NCC.txt
        private string txtfile2 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\NCC.txt";
        //Lấy toàn bộ dữ liệu có trong file NCC.txt đưa vào một danh sách
        public List<NCC> GetData()
        {
            List<NCC> list = new List<NCC>();
            StreamReader fread2 = File.OpenText(txtfile2);
            string s = fread2.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new NCC(int.Parse(a[0]), a[1], a[2], a[3]));

                }
                s = fread2.ReadLine();

            }
            fread2.Close();
            return list;
        }
        //Lấy mã nhà cung cấp của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int mancc
        {
            get
            {
                StreamReader fread2 = File.OpenText(txtfile2);
                string s = fread2.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = fread2.ReadLine();
                }
                fread2.Close();
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
        //Chèn một bản ghi nhà cung cấp vào tệp
        public void Insert(NCC nc)
        {
            int manc = mancc + 1;
            StreamWriter fwrite = File.AppendText(txtfile2);
            fwrite.WriteLine();
            fwrite.Write(manc + "\t" + nc.tenncc + "\t" + nc.diachi + "\t" + nc.sdt);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<NCC> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile2);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mancc + "\t" + list[i].tenncc + "\t" + list[i].diachi + "\t" + list[i].sdt);
            fwrite.Close();
        }
    }
}
