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
        private string SDT;
        public NCC()
        {
            MaNCC = 0;
            TenNCC = "";
            DiaChi = "";
            SDT = "";
        }
        public NCC(int mancc, string tenncc, string diachi,string sdt)
        {
            this.MaNCC = mancc;
            this.TenNCC = tenncc;
            this.DiaChi = diachi;
            this.SDT = sdt;
        }
        public NCC(NCC nc)
        {
            this.MaNCC = nc.mancc;
            this.TenNCC = nc.tenncc;
            this.DiaChi = nc.diachi;
            this.SDT = nc.sdt;
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
        public string sdt
        {
            get
            {
                return SDT;
            }
            set
            {
                if (value != "")
                    SDT = value;
            }    
        }
    }
}
