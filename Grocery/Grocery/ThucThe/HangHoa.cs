using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class HangHoa
    {
        private int MaHH;
        private int MaLoai;
        private int SLNhapVe;
        private int SLHienCo;
        private string TenHang;
        public HangHoa()
        {
            MaHH = 0;
            MaLoai = 0;
            SLNhapVe = 0;
            SLHienCo = 0;
            TenHang = "";
        }
        public HangHoa(int mahh, int maloai, int slnhap, int slhienco, string tenhang)
        {
            this.MaHH = mahh;
            this.MaLoai = maloai;
            this.SLNhapVe = slnhap;
            this.SLHienCo = slhienco;
            this.TenHang = tenhang;
        }    
        public int mahh
        {
            get
            {
                return MaHH;
            }
            set
            {
                if (MaHH > 0)
                    MaHH = value;
            }
        }
        public int maloai
        {
            get
            {
                return MaLoai;
            }
            set
            {
                if (MaLoai > 0)
                    MaLoai = value;
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
                if (SLNhapVe > 0)
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
                if (SLHienCo > 0)
                    SLHienCo = value;
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
                if (TenHang != "")
                    TenHang = value;
            }
        }
    }
}
