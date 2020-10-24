using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class LoaiHang
    {
        public static int STT = 0;
        private int Maloai;
        private string TenLoai;
        private string DacDiem;
        public LoaiHang()
        {
            STT++;
            Maloai = STT;
        }
        public LoaiHang(string tenloai, string dacdiem)
        {
            STT++;
            Maloai = STT;
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
                if (Maloai > 0)
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
                if (TenLoai != "")
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
                if (DacDiem != "")
                    DacDiem = value;
            }
        }
    }
}
