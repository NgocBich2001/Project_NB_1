using System;
using System.Text;
using Grocery.Utiility;
using System.Configuration;
using System.IO;
using Grocery.ThucThe;
using Grocery.DataAccessLayer.Interface;

namespace Grocery.DataAccessLayer
{
    class HoaDonNhapDAL : IDHoaDonNhapDAL
    {
        //Xác định đường dẫn của tệp dữ liệu HOADONNHAP.txt
        private string txtfile5 = @"E:\GITHUB\Project_NB_1\Grocery\Grocery\Data\HOADONNHAP.txt";
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
                    list.Add(new HoaDonNhap(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), a[4], int.Parse(a[5]), int.Parse(a[6]), double.Parse(a[7]), double.Parse(a[8])));

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
            fwrite.WriteLine();
            fwrite.Write(manhap + "\t" + hdn.mancc + "\t" + hdn.nvgiao + "\t" + hdn.manvnhan + "\t" + hdn.ngaynhan + "\t" + hdn.mahang + "\t" + hdn.soluong + "\t" + hdn.gianhap + "\t" + hdn.thanhtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp
        public void Update(List<HoaDonNhap> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile5);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahdn + "\t" + list[i].mancc + "\t" + list[i].nvgiao + "\t" + list[i].manvnhan + "\t" + list[i].ngaynhan + "\t" + list[i].mahang + "\t" + list[i].soluong + "\t" + list[i].gianhap + "\t" + list[i].thanhtien); ;
            fwrite.Close();
        }
    }
}
