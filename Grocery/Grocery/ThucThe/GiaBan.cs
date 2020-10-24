using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class GIABAN
    {
        private int MaGiaBan;
        private int MaHang;
        private double GiaBan;
        private string DonViTinh;
        private DateTime NgayAD;
        private DateTime NgayThoiAD;
        public GIABAN()
        {
            MaGiaBan = 0;
            MaHang = 0;
            GiaBan = 0;
            DonViTinh = "";
            NgayAD = DateTime.Now;
            NgayThoiAD = DateTime.Now;
        }    
        public GIABAN(int magiaban, int mahang, double giaban, string donvitinh, DateTime ngayad, DateTime ngaythoiad)
        {
            this.MaGiaBan = magiaban;
            this.MaHang = mahang;
            this.GiaBan = giaban;
            this.DonViTinh = donvitinh;
            this.NgayAD = ngayad;
            this.NgayThoiAD = ngaythoiad;
        }
        public int magiaban
        {
            get
            {
                return MaGiaBan;
            }
            set
            {
                if (MaGiaBan > 0)
                    MaGiaBan = value;
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
        public DateTime ngayad
        {
            get
            {
                return NgayAD;
            }
            set
            {
                NgayAD = value;
            }
        }
        public DateTime ngaythoiad
        {
            get
            {
                return NgayThoiAD;
            }
            set
            {
                NgayThoiAD = value;
            }
        }
    }
}
