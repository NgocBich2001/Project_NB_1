using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    public class NCC
    {
        private int MaNCC;
        private string TenNCC;
        private string DiaChi;
        private int SDT;
        public NCC()
        {
            MaNCC = 0;
            TenNCC = "";
            DiaChi = "";
            SDT = 0;
        }
        public NCC(int mancc, string tenncc, string diachi, int sdt)
        {
            this.MaNCC = mancc;
            this.TenNCC = tenncc;
            this.DiaChi = diachi;
            this.SDT = sdt;
        }
        public NCC(NCC nc)
        {
            this.MaNCC = nc.MaNCC;
            this.TenNCC = nc.TenNCC;
            this.DiaChi = nc.DiaChi;
            this.SDT = nc.SDT;
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
        public string tenncc
        {
            get
            {
                return TenNCC;
            }
            set
            {
                if (value != "")
                    TenNCC = value;
            }
        }
        public string diachi
        {
            get
            {
                return DiaChi;
            }
            set
            {
                if (value != "")
                    DiaChi = value;
            }    
        }    
        public int sdt
        {
            get
            {
                return SDT;
            }
            set
            {
                if (value > 0)
                    SDT = value;
            }    
        }
    }
}
