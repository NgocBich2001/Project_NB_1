using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    public class CTHoaDonBan
    {
        private int MaHDB;
        private int MaHang;
        private int SoLuong;
        private string DonViTinh;
        private double GiaBan;
        private double ThanhTien;
        public CTHoaDonBan()
        {
            MaHDB = 0;
            MaHang = 0;
            SoLuong = 0;
            DonViTinh = "";
            GiaBan = 0;         
            ThanhTien = 0;
        }
        public CTHoaDonBan(int mahdb, int mh, int soluong, string donvi, double giaban, double thanhtien)
        {
            this.MaHDB = mahdb;
            this.MaHang = mh;
            this.SoLuong = soluong;
            this.DonViTinh = donvi;
            this.GiaBan = giaban;
            this.ThanhTien = thanhtien;
        }
        //Hàm sao chép
        public CTHoaDonBan(CTHoaDonBan hdb)
        {
            this.MaHDB = hdb.mahdb;
            this.MaHang = hdb.mahang;
            this.SoLuong = hdb.soluong;
            this.DonViTinh = hdb.donvi;
            this.GiaBan = hdb.giaban;    
            this.ThanhTien = hdb.thanhtien;
        }
        public int mahdb
        {
            get
            {
                return MaHDB;
            }
            set
            {
                if (value > 0)
                    MaHDB = value;
            }
        }
        
        public int mahang
        {
            get
            {
                return MaHang;
            }
            set
            {
                if (value > 0)
                    MaHang = value;
            }
        }
        public int soluong
        {
            get
            {
                return SoLuong;
            }
            set
            {
                if (value > 0)
                    SoLuong = value;
            }
        }
        public string donvi
        {
            get
            {
                return DonViTinh;
            }
            set
            {
                if (value != "")
                    DonViTinh = value;
            }
        }
        public double giaban
        {
            get
            {
                return GiaBan;
            }
            set
            {
                if (value > 0)
                    GiaBan = value;
            }
        }
      
        public double thanhtien
        {
            get
            {
                return soluong * giaban;
            }
            set
            {
                    ThanhTien = value;
            }
        }
    }
}
