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
    public class HoaDonNhapBLL : IFHoaDonNhapBLL
    {
        private IDHoaDonNhapDAL HDNDA = new HoaDonNhapDAL();
        //Thực thi các yêu cầu
        public List<HoaDonNhap> XemDSHoaDonNhap()
        {
            return HDNDA.GetData();
        }
        public void ThemHoaDonNhap(HoaDonNhap HDN)
        {
            if (HDN.nvgiao!="")
            {
                HDN.nvgiao = Grocery.Utiility.CongCu.ChuanHoaXau(HDN.nvgiao);
                HDNDA.Insert(HDN);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public bool KiemTra(int mahdn)
        {
            bool kt = false;
            foreach (HoaDonNhap hdn in HDNDA.GetData())
                if (hdn.mahdn == mahdn)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public HoaDonNhap ReturnKey(int mancc, string nvgiao, int manvnhan, string ngaynhap)
        {
            HoaDonNhap HDN = null;
            foreach (HoaDonNhap hdn in HDNDA.GetData())
            {
                if (hdn.mancc==mancc && hdn.nvgiao==nvgiao && hdn.manvnhan==manvnhan && hdn.ngaynhan==ngaynhap)
                {
                    HDN = new HoaDonNhap(hdn);
                    break;
                }    
            }
            return HDN;
        }    
        public double TinhTong(int macthdn)
        {
            HoaDonNhapDAL hdnDAL = new HoaDonNhapDAL();
            return hdnDAL.TongTien(macthdn);
        }
        public void XoaHoaDonNhap(int mahdn)
        {
            if (KiemTra(mahdn) == true)
                HDNDA.Delete(mahdn);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaHoaDonNhap(HoaDonNhap HDN)
        {

            if (KiemTra(HDN.mahdn) == true)
                HDNDA.Update(HDN);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public HoaDonNhap LayHoaDonNhap(int mahdn)
        {
            int i;
            List<HoaDonNhap> list = HDNDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == mahdn) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public List<HoaDonNhap> TimHoaDonNhap(HoaDonNhap HDN)
        {
            List<HoaDonNhap> list = HDNDA.GetData();
            List<HoaDonNhap> KQ = new List<HoaDonNhap>();
            //Với giá trị ngầm định ban đầu
            if (HDN.mahdn == 0)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (HDN.mahdn != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdn == HDN.mahdn)
                    {
                        KQ.Add(new HoaDonNhap(list[i]));
                    }
            }
            else 
                KQ = null;
            return KQ;
        }
    }

}
