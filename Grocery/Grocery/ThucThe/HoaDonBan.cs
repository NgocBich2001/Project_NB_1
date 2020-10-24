using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    class HoaDonBan
    {
        private int MaHDB;
        private int MaNVBan;
        private DateTime NgayBan;
        private double TongTien;
        public HoaDonBan()
        {
            MaHDB = 0;
            MaNVBan = 0;
            NgayBan = DateTime.Now;
            TongTien = 0;
        }
        public HoaDonBan(int mahdb, int manvban, DateTime ngayban, double tongtien)
        {
            this.MaHDB = mahdb;
            this.MaNVBan = manvban;
            this.NgayBan = ngayban;
            this.TongTien = tongtien;
        }
        public int mahdb
        {
            get
            {
                return MaHDB;
            }    
            set
            {
                if (value  > 0)
                    MaHDB = value;
            }    
        }
        public int manvban
        {
            get
            {
                return MaNVBan;
            }
            set
            {
                if (value > 0)
                    MaNVBan = value;
            }
        }
        public DateTime ngayban
        {
            get
            {
                return NgayBan;
            }
            set
            {
                NgayBan = value;
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
                if (value > 0)
                    TongTien = value;
            }
        }
    }
}
