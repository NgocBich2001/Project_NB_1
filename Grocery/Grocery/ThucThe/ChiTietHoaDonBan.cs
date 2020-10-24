using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class ChiTietHoaDonBan
    {
        private int MaCTHDB;
        private int MaHDB;
        private int MaHang;
        private int SoLuong;
        private double GiaBan;
        private string DonViTinh;
        private double ThanhTien;
        public ChiTietHoaDonBan()
        {
            MaCTHDB = 0;
            MaHDB = 0;
            MaHang = 0;
            SoLuong = 0;
            GiaBan = 0;
            DonViTinh = "";
            ThanhTien = 0;
        }
        public ChiTietHoaDonBan(int macthdb, int mahdb, int mahang, int soluong, double giaban, string donvitinh, double thanhtien)
        {
            this.MaCTHDB = macthdb;
            this.MaHDB = mahdb;
            this.MaHang = mahang;
            this.SoLuong = soluong;
            this.GiaBan = giaban;
            this.DonViTinh = donvitinh;
            this.ThanhTien = thanhtien;
        }    
        public int macthdb
        {
            get
            {
                return MaCTHDB;
            }
            set
            {
                if (MaCTHDB > 0)
                    MaCTHDB = value;
            }    
        }
        public int mahdb
        {
            get
            {
                return MaHDB;
            }
            set
            {
                if (MaHDB > 0)
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
                if (MaHang > 0)
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
                if (SoLuong > 0)
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
                if (GiaBan > 0)
                    GiaBan = value;
            }
        }
        public string donvitinh
        {
            get
            {
                return DonViTinh;
            }
            set
            {
                if (DonViTinh != "")
                    DonViTinh = value;
            }
        }
        public double thanhtien
        {
            get
            {
                return ThanhTien;
            }
            set
            {
                if (ThanhTien > 0)
                    ThanhTien = value;
            }
        }
    }
}
