using System;
using System.Text;
using Grocery.Utiility;
using System.Configuration;
using System.IO;
using Grocery.ThucThe;
using Grocery.DataAccessLayer.Interface;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Grocery.DataAccessLayer
{
    class NhanVienDAL : IDNhanVienDAL
    {
        //Xác định đường dẫn của tệp dữ liệu NHANVIEN.txt
        private string txtfile3 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\NHANVIEN.txt";
        //Lấy toàn bộ dữ liệu có trong file NHANVIEN.txt đưa vào một danh sách
        public List<NhanVien> GetData()
        {
            List<NhanVien> list = new List<NhanVien>();
            StreamReader fread3 = File.OpenText(txtfile3);
            string s = fread3.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new NhanVien(int.Parse(a[0]), a[1], a[2], a[3], a[4], a[5]));

                }
                s = fread3.ReadLine();

            }
            fread3.Close();
            return list;
        }
        //Lấy mã nhân viên cấp của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int manv
        {
            get
            {
                StreamReader fread3 = File.OpenText(txtfile3);
                string s = fread3.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = fread3.ReadLine();
                }
                fread3.Close();
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
        //Chèn một bản ghi nhân viên vào tệp
        public void Insert(NhanVien NV)
        {
            int mav = manv + 1;
            StreamWriter fwrite = File.AppendText(txtfile3);
            fwrite.WriteLine();
            fwrite.Write(mav + "\t" + NV.tennv + "\t" + NV.ngaysinh + "\t" + NV.gt + "\t" + NV.ngayvaolam + "\t" + NV.pass);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<NhanVien> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile3);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].manv + "\t" + list[i].tennv + "\t" + list[i].ngaysinh + "\t" + list[i].gt +"\t" + list[i].ngayvaolam + "\t" + list[i].pass);
            fwrite.Close();
        }
    }
}
