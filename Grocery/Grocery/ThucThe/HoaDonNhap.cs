using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
//using Grocery.Business.Interface;
using Grocery.Business;

namespace Grocery.ThucThe
{
    public class HoaDonNhap
    {
        private int MaHDN;
        private int MaNCC;
        private string NVGiao;
        private int MaNVNhan;
        private string NgayNhan;
        private double TongTien;
        
        public HoaDonNhap()
        {
            MaHDN = 0;
            MaNCC = 0;
            NVGiao = "";
            MaNVNhan = 0;
            NgayNhan = "";
            TongTien = 0;
        }    
        public HoaDonNhap(int mahdn, int mancc, string nvgiao, int manvnhan, string ngaynhan, double tongtien)
        {
            this.MaHDN = mahdn;
            this.MaNCC = mancc;
            this.NVGiao = nvgiao;
            this.MaNVNhan = manvnhan;
            this.NgayNhan = ngaynhan;
            this.TongTien = tongtien;
        }
        
        
        public HoaDonNhap(HoaDonNhap hdn)
        {
            this.MaHDN = hdn.mahdn;
            this.MaNCC = hdn.mancc;
            this.NVGiao = hdn.nvgiao;
            this.MaNVNhan = hdn.manvnhan;
            this.NgayNhan = hdn.ngaynhan;
            this.TongTien = hdn.tongtien;
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
        public string nvgiao
        {
            get
            {
                return NVGiao;
            }
            set
            {
                if (value != "")
                    NVGiao = value;
            }
        }
        public int manvnhan
        {
            get
            {
                return MaNVNhan;
            }
            set
            {
                if (value  > 0)
                    MaNVNhan = value;
            }
        }
        public string ngaynhan
        {
            get
            {
                return NgayNhan;
            }
            set
            {
                if (value != "")
                NgayNhan = value;
            }
        }
        
        public double  tongtien
        {
            get
            {
                return TongTien;
            }
            set
            {
                if (value > 0)
                    TongTien = value;
            }
        }
    }
}
