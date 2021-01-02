using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using Grocery.DataAccessLayer.Interface;
using Grocery.Business.Interface;
using System.Collections.Generic;

namespace Grocery.Business
{
    //Thực thi các yêu cầu nghiệm vụ 
    public class HoaDonBanBLL : IFHoaDonBanBLL
    {
        private IDHoaDonBanDAL HDBDA = new HoaDonBanDAL();
        //Thực thi các yêu cầu
        public List<HoaDonBan> XemDSHoaDonBan()
        {
            return HDBDA.GetData();
        }
        public void ThemHoaDonBan(HoaDonBan HDB)
        {
            if (HDB.ngayban != "")
            {
                HDB.ngayban = Grocery.Utiility.CongCu.ChuanHoaXau(HDB.ngayban);
                HDBDA.Insert(HDB);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public bool KiemTra(int mahdb)
        {
            bool kt = false;
            foreach (HoaDonBan hdb in HDBDA.GetData())
                if (hdb.mahdb == mahdb)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public HoaDonBan ReturnKey(int manvb, string ngayban)
        {
            HoaDonBan HDB = null;
            foreach (HoaDonBan hdb in HDBDA.GetData())
            {
                if (hdb.manvban == manvb && hdb.ngayban==ngayban)
                {
                    HDB = new HoaDonBan(hdb);
                    break;
                }
            }
            return HDB;
        }
        public double TinhTong(int macthdb)
        {
            HoaDonBanDAL hdbDAL = new HoaDonBanDAL();
            return hdbDAL.TongTien(macthdb);
        }
        public void XoaHoaDonBan(int mahdb)
        {
            if (KiemTra(mahdb) == true)
                HDBDA.Delete(mahdb);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaHoaDonBan(HoaDonBan HDB)
        {

            if (KiemTra(HDB.mahdb) == true)
                HDBDA.Update(HDB);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public HoaDonBan LayHoaDonBan(int mahdb)
        {
            int i;
            List<HoaDonBan> list = HDBDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == mahdb) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public List<HoaDonBan> TimHoaDonBan(HoaDonBan HDB)
        {
            List<HoaDonBan> list = HDBDA.GetData();
            List<HoaDonBan> KQ = new List<HoaDonBan>();
            //Với giá trị ngầm định ban đầu
            if (HDB.mahdb == 0)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (HDB.mahdb != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdb == HDB.mahdb)
                    {
                        KQ.Add(new HoaDonBan(list[i]));
                    }
            }
            else
                KQ = null;
            return KQ;
        }
    }

}
