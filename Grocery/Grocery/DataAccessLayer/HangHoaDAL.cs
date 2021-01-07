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
                    list.Add(new HangHoa(int.Parse(a[0]), a[1], int.Parse(a[2]), int.Parse(a[3]), a[4], a[5], int.Parse(a[6]), int.Parse(a[7]), double.Parse(a[8]), double.Parse(a[9])));

                }
                s = fread1.ReadLine();

            }
            fread1.Close();
            return list;
        }
        
        //Chèn một bản ghi nhân viên vào tệp
        public void Insert(HangHoa HH)
        {
            StreamWriter fwrite = File.AppendText(txtfile1);
            fwrite.WriteLine(HH.mahh + "\t" + HH.tenhang + "\t" + HH.mancc + "\t" + HH.đot + "\t" + HH.NSX + "\t" + HH.HSD + "\t" + HH.slnhapve + "\t" + HH.slhienco + "\t" + HH.gianhap + "\t" + HH.giaban);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(HangHoa HH)
        {
            List<HangHoa> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].mahh == HH.mahh)
                {
                    list[i] = HH;
                    break;
                }
            StreamWriter fwrite = File.CreateText(txtfile1);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahh + "\t" + list[i].tenhang + "\t" + list[i].mancc + "\t" + list[i].đot + "\t" + list[i].NSX + "\t" + list[i].HSD + "\t" + list[i].slnhapve + "\t" + list[i].slhienco + "\t" + list[i].gianhap + "\t" + list[i].giaban);
            fwrite.Close();
        }
        public void Delete(int mahh)
        {
            List<HangHoa> list = GetData();
            StreamWriter file = File.CreateText(txtfile1);
            foreach (HangHoa hh in list)
                if (hh.mahh != mahh)
                    file.WriteLine(hh.mahh + "\t" + hh.tenhang + "\t" + hh.mancc + "\t" + hh.đot + "\t" + hh.NSX + "\t" + hh.HSD + "\t" + hh.slnhapve + "\t" + hh.slhienco + "\t" + hh.gianhap + "\t" + hh.giaban);
            file.Close();
        }
        public void UpdateTru(HangHoa hh, int sl)
        {
            List<HangHoa> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].mahh == hh.mahh)
                {
                    list[i] = hh;
                    list[i].slhienco -= sl;
                    break;
                }
            StreamWriter sw = File.CreateText(txtfile1);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].mahh + "\t" + list[i].tenhang + "\t" + list[i].mancc + "\t" + list[i].đot + "\t" + list[i].NSX + "\t" + list[i].HSD + "\t" + list[i].slnhapve + "\t" + list[i].slhienco + "\t" + list[i].gianhap + "\t" + list[i].giaban);
            sw.Close();
        }
        public void UpdateCong(HangHoa hh, int sl)
        {
            List<HangHoa> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].mahh == hh.mahh)
                {
                    list[i] = hh;
                    list[i].slhienco += sl;
                    break;
                }
            StreamWriter sw = File.CreateText(txtfile1);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].mahh + "\t" + list[i].tenhang + "\t" + list[i].mancc + "\t" + list[i].đot + "\t" + list[i].NSX + "\t" + list[i].HSD + "\t" + list[i].slnhapve + "\t" + list[i].slhienco + "\t" + list[i].gianhap + "\t" + list[i].giaban);
            sw.Close();
        }
    }
}
