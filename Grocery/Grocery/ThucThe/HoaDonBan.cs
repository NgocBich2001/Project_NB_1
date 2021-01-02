using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.ThucThe
{
    public class HoaDonBan
    {
        private int MaHDB;
        private int MaNVBan;
        private string NgayBan;
        private double TongTien;
        public HoaDonBan()
        {
            MaHDB = 0;
            MaNVBan = 0;
            NgayBan = "";
            TongTien = 0;
        }
        public HoaDonBan(int mahdb, int manvban, string ngayban, double tongtien)
        {
            this.MaHDB = mahdb;
            this.MaNVBan = manvban;
            this.NgayBan = ngayban;
            this.TongTien = tongtien;
        }
        //Hàm sao chép
        public HoaDonBan(HoaDonBan hdb)
        {
            this.MaHDB = hdb.mahdb;
            this.MaNVBan = hdb.manvban;
            this.NgayBan = hdb.ngayban;
            this.TongTien = hdb.tongtien;
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
        public string ngayban
        {
            get
            {
                return NgayBan;
            }
            set
            {
                if (value != "")
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
