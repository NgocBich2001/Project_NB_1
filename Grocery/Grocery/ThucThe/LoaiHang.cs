using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class LoaiHang
    {
        private int Maloai;
        private string TenLoai;
        private string DacDiem;
        public LoaiHang()
        {
            Maloai = 0;
            TenLoai = "";
            DacDiem = "";
        }
        public LoaiHang( int maloai, string tenloai, string dacdiem)
        {
            this.Maloai = maloai;
            this.TenLoai = tenloai;
            this.DacDiem = dacdiem;
        }
        public int maloai
        {
            get
            {
                return Maloai;
            }
            set
            {
                if (value > 0)
                    Maloai = value;
            }
        }
        public string tenloai
        {
            get
            {
                return TenLoai;
            }
            set
            {
                if (value != "")
                    TenLoai = value;
            }
        }
        public string dacdiem
        {
            get
            {
                return DacDiem;
            }
            set
            {
                if (value != "")
                    DacDiem = value;
            }
        }
    }
}
