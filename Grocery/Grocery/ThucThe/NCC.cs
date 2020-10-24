using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class NCC
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
        public int mancc
        {
            get
            {
                return MaNCC;
            }
            set
            {
                if (MaNCC > 0)
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
                if (TenNCC != "")
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
                if (DiaChi != "")
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
                if (SDT > 0)
                    SDT = value;
            }    
        }
    }
}
