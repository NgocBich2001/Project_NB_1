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
    public class CTHoaDonBanBLL : IFCTHoaDonBanBLL
    {
        private IDCTHoaDonBanDAL CTHDBDA = new CTHoaDonBanDAL();
        //Thực thi các yêu cầu
        public List<CTHoaDonBan> XemDSCTHoaDonBan()
        {
            return CTHDBDA.GetData();
        }

        public void ThemCTHoaDonBan(CTHoaDonBan CTHDB)
        {
            if (CTHDB.donvi != "")
            {
                CTHDB.donvi = Grocery.Utiility.CongCu.ChuanHoaXau(CTHDB.donvi);
                CTHDBDA.Insert(CTHDB);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public CTHoaDonBan ReturnSL(int mahh)
        {
            CTHoaDonBan cthdb = null;
            foreach (CTHoaDonBan ctb in CTHDBDA.GetData())
            {
                if (ctb.mahang == mahh)
                {
                    cthdb = new CTHoaDonBan(ctb);
                    break;
                }
            }
            return cthdb;
        }
        public bool KiemTra(int mahdb)
        {
            bool kt = false;
            foreach (CTHoaDonBan cthdb in CTHDBDA.GetData())
                if (cthdb.mahdb == mahdb)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public void XoaCTHoaDonBan(int mahdb)
        {
            if (KiemTra(mahdb) == true)
                CTHDBDA.Delete(mahdb);
            else
                throw new Exception("Không tồn tại mã này.");
        }

        public List<CTHoaDonBan> TimCTHoaDonBan(CTHoaDonBan CTHDB)
        {
            List<CTHoaDonBan> list = CTHDBDA.GetData();
            List<CTHoaDonBan> KQ = new List<CTHoaDonBan>();
            //Với giá trị ngầm định ban đầu
            if (CTHDB.mahdb == 0)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (CTHDB.mahdb != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdb == CTHDB.mahdb)
                    {
                        KQ.Add(new CTHoaDonBan(list[i]));
                    }
            }
            else
                KQ = null;
            return KQ;
        }
    }

}
