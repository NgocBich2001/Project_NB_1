using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class HoaDonNhap
    {
        private int MaHDN;
        private int MaNCC;
        private string NVGiao;
        private int MaNVNhan;
        private DateTime NgayNhan;
        private double TongTien;
        private string TrangThai;
        private double DaTT;
        private double ConNo;
        private string GhiChu;
        public HoaDonNhap()
        {
            MaHDN = 0;
            MaNCC = 0;
            NVGiao = "";
            MaNVNhan = 0;
            NgayNhan = DateTime.Now;
            TongTien = 0;
            TrangThai = "";
            DaTT = 0;
            ConNo = 0;
            GhiChu = "";
        }    
        public HoaDonNhap(int mahdn, int mancc, string nvgiao, int manvnhan, DateTime ngaynhan, double tongtien, string trangthai, double datt, double conno, string ghichu)
        {
            this.MaHDN = mahdn;
            this.MaNCC = mancc;
            this.NVGiao = nvgiao;
            this.MaNVNhan = manvnhan;
            this.NgayNhan = ngaynhan;
            this.TongTien = tongtien;
            this.TrangThai = trangthai;
            this.DaTT = datt;
            this.ConNo = conno;
            this.GhiChu = ghichu;
        }
        public int mahdn
        {
            get
            {
                return MaHDN;
            }
            set
            {
                if (MaHDN > 0)
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
                if (MaNCC > 0)
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
                if (NVGiao != "")
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
                if (MaNVNhan > 0)
                    MaNVNhan = value;
            }
        }
        public DateTime ngaynhan
        {
            get
            {
                return NgayNhan;
            }
            set
            {
                NgayNhan = value;
            }
        }
        public double tongtien
        {
            get
            {
                return TongTien;
            }
            set
            {
                if (TongTien > 0)
                    TongTien = value;
            }
        }
        public string trangthai
        {
            get
            {
                return TrangThai;
            }
            set
            {
                if (TrangThai != "")
                    TrangThai = value;
            }
        }
        public double datt
        {
            get
            {
                return DaTT;
            }
            set
            {
                if (DaTT > 0)
                    DaTT = value;
            }
        }
        public double conno
        {
            get
            {
                return ConNo;
            }
            set
            {
                if (ConNo >= 0)
                    ConNo = value;
            }
        }
        public string ghichu
        {
            get
            {
                return GhiChu;
            }
            set
            {
                    GhiChu = value;
            }
        }
    }
}
