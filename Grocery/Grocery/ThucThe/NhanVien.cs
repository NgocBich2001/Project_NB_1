﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    public class NhanVien
    {
        private int MaNV;
        private string TenNV;
        private string NgaySinh;
        private string GioiTinh;
        private string NgayVaoLV;
        private string Pass;
        public NhanVien()
        {
            MaNV = 0;
            TenNV = "";
            NgaySinh = "";
            GioiTinh = "";
            NgayVaoLV = "";
            Pass = "";
        }    
        public NhanVien(int manv, string tennv, string ngaysinh, string gt, string ngayvaolv, string pass)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gt;
            this.NgayVaoLV = ngayvaolv;
            this.Pass = pass;
        }
        public NhanVien(NhanVien nv)
        {
            this.MaNV = nv.MaNV;
            this.TenNV = nv.TenNV;
            this.NgaySinh = nv.NgaySinh;
            this.GioiTinh = nv.GioiTinh;
            this.NgayVaoLV = nv.NgayVaoLV;
            this.Pass = nv.Pass;
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
        public string ngaysinh
        {
            get
            {
                return NgaySinh;
            }
            set
            {
                if (value != "")
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
                //if (value.ToLower() == "Nam" || value.ToLower() == "Nữ")
                    GioiTinh = value;
            }
        }    
        public string ngayvaolam
        {
            get
            {
                return NgayVaoLV;
            }
            set
            {
                if (value != "")
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
