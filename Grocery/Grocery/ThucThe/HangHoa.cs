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
            SLNhapVe = 0;
            SLHienCo = 0;
            TenHang = "";
        }
        public HangHoa(int mahh, int maloai, string tenhang, int slnhap, int slhienco)
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
    }
}
