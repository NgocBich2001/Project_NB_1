using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    public class HangHoa
    {
        private int MaHH;
        private string TenHang;
        private int MaNCC;
        private int Đot;
        private string NgaySX;
        private string NgayHH;
        private int SLNhapVe;
        private int SLHienCo;
        private double GiaNhap;
        private double GiaBan;
        
        public HangHoa()
        {
            MaHH = 0;
            TenHang = "";
            MaNCC = 0;
            Đot = 0;
            NgaySX = "";
            NgayHH = "";
            SLNhapVe = 0;
            SLHienCo = 0;
            GiaNhap = 0;
            GiaBan = 0;
        }
        public HangHoa(int mahh, string tenhang, int mancc, int đot, string NSX, string HSD, int slnhap, int slhienco, double gianhap, double giaban)
        {
            this.MaHH = mahh;
            this.TenHang = tenhang;
            this.MaNCC = mancc;
            this.Đot = đot;
            this.NgaySX = NSX;
            this.NgayHH = HSD;
            this.SLNhapVe = slnhap;
            this.SLHienCo = slhienco;
            this.GiaNhap = gianhap;
            this.GiaBan = giaban;
        }
        public HangHoa(HangHoa hh)
        {
            this.MaHH = hh.mahh;
            this.TenHang = hh.tenhang;
            this.MaNCC = hh.mancc;
            this.Đot = hh.đot;
            this.NgaySX = hh.NSX;
            this.NgayHH = hh.HSD;
            this.SLNhapVe = hh.slnhapve;
            this.SLHienCo = hh.slhienco;
            this.GiaNhap = hh.gianhap;
            this.GiaBan = hh.giaban;
        }
        public int mahh
        {
            get
            {
                return MaHH;
            }
            set
            {
                if (value > 0)
                    MaHH = value;
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
        public int mancc
        {
            get
            {
                return MaNCC;
            }
            set
            {
                if (value > 0)
                    MaNCC = value;
            }
        }
        public int đot
        {
            get
            {
                return Đot;
            }
            set
            {
                if (value > 0)
                    Đot = value;
            }
        }
        public string NSX
        {
            get
            {
                return NgaySX;
            }
            set
            {
                if (value != "")
                    NgaySX = value;
            }
        }
        public string HSD
        {
            get
            {
                return NgayHH;
            }
            set
            {
                if (value != "")
                    NgayHH = value;
            }
        }
        public int slnhapve
        {
            get
            {
                return SLNhapVe;
            }
            set
            {
                if (value > 0)
                    SLNhapVe = value;
            }
        }
        public int slhienco
        {
            get
            {
                return SLHienCo;
            }
            set
            {
                if (value  > 0)
                    SLHienCo = value;
            }    
        }
        public double gianhap
        {
            get
            {
                return GiaNhap;
            }
            set
            {
                if (value > 0)
                    GiaNhap = value;
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
    }
}
