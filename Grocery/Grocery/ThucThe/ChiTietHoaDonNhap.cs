using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class ChiTietHoaDonNhap
    {
        private int MaCTHDN;
        private int MaHDN;
        private int MaHang;
        private int SoLuong;
        private double DonGiaNhap;
        private DateTime NSX;
        private DateTime HSD;
        private double VAT;
        private double ThanhTien;
        public ChiTietHoaDonNhap()
        {
            MaCTHDN = 0;
            MaHDN = 0;
            MaHang = 0;
            SoLuong = 0;
            DonGiaNhap = 0;
            NSX = DateTime.Now;
            HSD = DateTime.Now;
            VAT = 0;
            ThanhTien = 0;
        }
        public ChiTietHoaDonNhap(int macthdn, int mahdn, int mahang, int soluong, double gianhap, DateTime nsx, DateTime hsd, double vat, double thanhtien)
        {
            this.MaCTHDN = macthdn;
            this.MaHDN = mahdn;
            this.MaHang = mahang;
            this.SoLuong = soluong;
            this.DonGiaNhap = gianhap;
            this.NSX = nsx;
            this.HSD = hsd;
            this.VAT = vat;
            this.ThanhTien = thanhtien;
        }
        public int macthdn
        {
            get
            {
                return MaCTHDN;
            }
            set
            {
                if (MaCTHDN > 0)
                    MaCTHDN = value;
            }    
        }
        public int mahdn
        {
            get
            {
                return MaHDN;
            }
            set
            {
                if (MaHDN > 0)
                    MaHDN = value;
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
        public double gianhap
        {
            get
            {
                return DonGiaNhap;
            }
            set
            {
                if (DonGiaNhap > 0)
                    DonGiaNhap = value;
            }
        }
        public DateTime nsx
        {
            get
            {
                return NSX;
            }
            set
            {
            }
        }
        public DateTime hsd
        {
            get
            {
                return HSD;
            }
            set
            {
                HSD = value;
            }
        }
        public double vat
        {
            get
            {
                return VAT;
            }
            set
            {
                if (VAT >= 0)
                    VAT = value;
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
