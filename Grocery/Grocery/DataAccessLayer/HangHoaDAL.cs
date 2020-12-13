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
    class HangHoaDAL : IDHangHoaDAL
    {
        //Xác định đường dẫn của tệp dữ liệu NHANVIEN.txt
        private string txtfile1 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\HANGHOA.txt";
        //Lấy toàn bộ dữ liệu có trong file NHANVIEN.txt đưa vào một danh sách
        public List<HangHoa> GetData()
        {
            List<HangHoa> list = new List<HangHoa>();
            StreamReader fread1 = File.OpenText(txtfile1);
            string s = fread1.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new HangHoa(int.Parse(a[0]), a[1], int.Parse(a[2]), int.Parse(a[3])));

                }
                s = fread1.ReadLine();

            }
            fread1.Close();
            return list;
        }
        //Lấy mã nhân viên cấp của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int mahh
        {
            get
            {
                StreamReader fread1 = File.OpenText(txtfile1);
                string s = fread1.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = fread1.ReadLine();
                }
                fread1.Close();
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
        public void Insert(HangHoa HH)
        {
            int mah = mahh + 1;
            StreamWriter fwrite = File.AppendText(txtfile1);
            fwrite.WriteLine();
            fwrite.Write(mah + "\t" + HH.tenhang + "\t" + HH.slnhapve + "\t" + HH.slhienco);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HangHoa> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile1);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahh + "\t" + list[i].tenhang + "\t" + list[i].slnhapve + "\t" + list[i].slhienco);
            fwrite.Close();
        }
    }
}
