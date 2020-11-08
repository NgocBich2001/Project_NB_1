using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using Grocery.DataAccessLayer.Interface;
using Grocery.Business.Interface;

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
            if (HDB.donvi != "")
            {
                HDB.donvi = Grocery.Utiility.CongCu.ChuanHoaXau(HDB.donvi);
                HDBDA.Insert(HDB);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public void XoaHoaDonBan(int mahdb)
        {
            int i;
            List<HoaDonBan> list = HDBDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == mahdb)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HDBDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaHoaDonBan(HoaDonBan HDB)
        {
            int i;
            List<HoaDonBan> list = HDBDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdb == HDB.mahdb)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(HDB, i);
                HDBDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
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
            if (HDB.mahdb == 0 && HDB.manvban == 0 && HDB.mahang == 0 && HDB.soluong==0 && HDB.giaban==0 && HDB.donvi =="" )
            {
                KQ = list;
            }
            //Tìm theo mã
            if (HDB.mahdb != 0 && HDB.manvban == 0 && HDB.mahang == 0 && HDB.soluong == 0 && HDB.giaban == 0 && HDB.donvi == "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdb == HDB.mahdb)
                    {
                        KQ.Add(new HoaDonBan(list[i]));
                    }
            }
            else KQ = null;
            return KQ;
        }
    }

}
