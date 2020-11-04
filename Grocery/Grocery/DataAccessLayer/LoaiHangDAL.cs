using System;
using System.Text;
using Grocery.Utiility;
using System.Configuration;
using System.IO;
using Grocery.ThucThe;
using Grocery.DataAccessLayer.Interface;

namespace Grocery.DataAccessLayer
{
    class LoaiHangDAL : IDLoaiHangDAL
    {
        //Xác định đường dẫn của tệp dữ liệu LOAIHANG.txt
        private string txtfile = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\LOAIHANG.txt";
        //Lấy toàn bộ dữ liệu có trong file LOAIHANG.txt đưa vào một danh sách
        public List<LoaiHang> GetData()
        {
            List<LoaiHang> list = new List<LoaiHang>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s!="")
                {
                    s = Grocery.Utiility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new LoaiHang(int.Parse(a[0]), a[1], a[2]));

                }
                s = fread.ReadLine();
                
            }
            fread.Close();
            return list;
        }
        //Lấy mã học sinh của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int maloai
        {
            get
            {
                StreamReader fread = File.OpenText(txtfile);
                string s = fread.ReadLine();
                string tmp = "";
                while (s!=null)
                {
                    if (s != "")
                        tmp = s;
                    s = fread.ReadLine();
                }
                fread.Close();
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
        //Chèn một bản ghi học sinh vào tệp
        public void Insert(LoaiHang LH)
        {
            int mal = maloai + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mal + "\t" + LH.tenloai + "\t" + LH.dacdiem);
            fwrite.Close();
        }   
        //Cập nhật lại danh sách vào tệp
        public void Update(List<LoaiHang> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].maloai + "\t" + list[i].tenloai + "\t" + list[i].dacdiem);
            fwrite.Close();
        }
    }    
}
