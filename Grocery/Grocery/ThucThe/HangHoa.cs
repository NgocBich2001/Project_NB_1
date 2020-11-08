using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    public class HangHoa
    {
        private int MaHH;
        private int MaLoai;
        private string TenHang;
        private int SLNhapVe;
        private int SLHienCo;
        
        public HangHoa()
        {
            MaHH = 0;
            MaLoai = 0;
            TenHang = "";
            SLNhapVe = 0;
            SLHienCo = 0;
           
        }
        public HangHoa(int mahh, int maloai, string tenhang, int slnhap, int slhienco)
        {
            this.MaHH = mahh;
            this.MaLoai = maloai;
            this.TenHang = tenhang;
            this.SLNhapVe = slnhap;
            this.SLHienCo = slhienco;
           
        }
        public HangHoa(HangHoa hh)
        {
            this.MaHH = hh.mahh;
            this.MaLoai = hh.maloai;
            this.TenHang = hh.tenhang;
            this.SLNhapVe = hh.slnhapve;
            this.SLHienCo = hh.slhienco;

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
        public int maloai
        {
            get
            {
                return MaLoai;
            }
            set
            {
                if (value > 0)
                    MaLoai = value;
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
        
    }
}
