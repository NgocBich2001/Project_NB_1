using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class NhanVien
    {
        private int MaNV;
        private string TenNV;
        private DateTime NgaySinh;
        private string GioiTinh;
        private DateTime NgayVaoLV;
        private string Pass;
        private string LoaiNV;
        public NhanVien()
        {
            MaNV = 0;
            TenNV = "";
            NgaySinh = DateTime.Now;
            GioiTinh = "";
            NgayVaoLV = DateTime.Now;
            Pass = "";
            LoaiNV = "";
        }    
        public NhanVien(int manv, string tennv, DateTime ngaysinh, string gt, DateTime ngayvaolv, string pass, string loainv)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gt;
            this.NgayVaoLV = ngayvaolv;
            this.Pass = pass;
            this.LoaiNV = loainv;
        }
        public int manv
        {
            get
            {
                return MaNV;
            }
            set
            {
                if (value  > 0)
                    MaNV = value;
            }    
        }    
        public string tennv
        {
            get
            {
                return TenNV;
            }    
            set
            {
                if (value  != "")
                    TenNV = value;
            }
        }    
        public DateTime ngaysinh
        {
            get
            {
                return NgaySinh;
            }
            set
            {
                NgaySinh = value;
            }    
        }    
        public string gt
        {
            get
            {
                return GioiTinh;
            }
            set
            {
                if (value.ToLower() == "Nam" || value.ToLower() == "Nữ")
                    GioiTinh = value;
            }
        }    
        public DateTime ngayvaolam
        {
            get
            {
                return NgayVaoLV;
            }
            set
            {
                NgayVaoLV = value;
            }
        }    
        public string pass
        {
            get
            {
                return Pass;
            }    
            set
            {
                if (value  != "")
                    Pass = value;
            }
        }
        
    }
}
