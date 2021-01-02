using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Grocery.ThucThe
{
    public class CTHoaDonNhap
    {
        private int MaHDN;
        private int MaHang;
        private string TenHang;
        private int SoLuong;
        private string DonVi;
        private double DonGiaNhap;
        private double ThanhTien;
        public CTHoaDonNhap()
        {
            MaHDN = 0;
            MaHang = 0;
            TenHang = "";
            SoLuong = 0;
            DonVi = "";
            DonGiaNhap = 0;
            ThanhTien = 0;
        }
        public CTHoaDonNhap(int mahdn, int mahang,string tenhang, int sl, string donvi, double gianhap, double thanhtien)
        {
            this.MaHDN = mahdn;
            this.MaHang = mahang;
            this.TenHang = tenhang;
            this.SoLuong = sl;
            this.DonVi = donvi;
            this.DonGiaNhap = gianhap;
            this.ThanhTien = thanhtien;
        }


        public CTHoaDonNhap(CTHoaDonNhap cthdn)
        {
            this.MaHDN = cthdn.mahdn;
            this.MaHang = cthdn.mahang;
            this.TenHang = cthdn.tenhang;
            this.SoLuong = cthdn.soluong;
            this.DonVi = cthdn.donvi;
            this.DonGiaNhap = cthdn.gianhap;
            this.ThanhTien = cthdn.thanhtien;
        }

        public int mahdn
        {
            get
            {
                return MaHDN;
            }
            set
            {
                if (value > 0)
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
                if (value > 0)
                    MaHang = value;
            }
        }
        public string tenhang
        {
            get
            {
                return TenHang;
            }
            set
            {
                if (value != "")
                    TenHang = value;
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
                return DonVi;
            }
            set
            {
                if (value != "")
                    DonVi = value;
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
                if (value > 0)
                    DonGiaNhap = value;
            }
        }
        public double thanhtien
        {
            get
            {
                return soluong * gianhap;
            }
            set
            {
                    ThanhTien = value;
            }
        }
    }
}
