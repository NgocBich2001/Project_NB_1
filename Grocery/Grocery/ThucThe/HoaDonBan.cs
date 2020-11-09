using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    public class HoaDonBan
    {
        private int MaHDB;
        private int MaNVBan;
        private DateTime NgayBan;
        private int MaHang;
        private int SoLuong;
        private double GiaBan;
        private string DonViTinh;
        private double ThanhTien;
        public HoaDonBan()
        {
            MaHDB = 0;
            MaNVBan = 0;
            NgayBan = DateTime.Now;
            MaHang = 0;
            SoLuong = 0;
            GiaBan = 0;
            DonViTinh = "";
            ThanhTien = 0;
        }
        public HoaDonBan(int mahdb, int manvban, DateTime ngayban,int mh, int soluong, double giaban, string donvi, double thanhtien)
        {
            this.MaHDB = mahdb;
            this.MaNVBan = manvban;
            this.NgayBan = ngayban;
            this.MaHang = mh;
            this.SoLuong = soluong;
            this.GiaBan = giaban;
            this.DonViTinh = donvi;
            this.ThanhTien = thanhtien;
        }
        //Hàm sao chép
        public HoaDonBan(HoaDonBan hdb)
        {
            this.MaHDB = hdb.mahdb;
            this.MaNVBan = hdb.manvban;
            this.NgayBan = hdb.ngayban;
            this.MaHang = hdb.mahang;
            this.SoLuong = hdb.soluong;
            this.GiaBan = hdb.giaban;
            this.DonViTinh = hdb.donvi;
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
                if (value  > 0)
                    MaHDB = value;
            }    
        }
        public int manvban
        {
            get
            {
                return MaNVBan;
            }
            set
            {
                if (value > 0)
                    MaNVBan = value;
            }
        }
        public DateTime ngayban
        {
            get
            {
                return NgayBan;
            }
            set
            {
                NgayBan = value;
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
        public double thanhtien
        {
            get
            {
                return soluong * giaban;
            }
            set
            {
                if (value > 0)
                    ThanhTien = value;
            }
        }
    }
}
