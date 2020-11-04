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
            if (HDN.nvgiao!="" && HDN.ghichu != "")
            {
                HDN.nvgiao = Grocery.Utiility.CongCu.ChuanHoaXau(HDN.nvgiao);
                HDN.ghichu = Grocery.Utiility.CongCu.ChuanHoaXau(HDN.ghichu);
                HDNDA.Insert(HDN);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public void XoaHoaDonNhap(int mahdn)
        {
            int i;
            List<HoaDonNhap> list = HDNDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == mahdn)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HDNDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaHoaDonNhap(HoaDonNhap HDN)
        {
            int i;
            List<HoaDonNhap> list = HDNDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahdn == HDN.mahdn)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(HDN, i);
                HDNDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public List<HoaDonNhap> TimHoaDonNhap(HoaDonNhap HDN)
        {
            List<HoaDonNhap> list = HDNDA.GetData();
            List<HoaDonNhap> KQ = new List<HoaDonNhap>();
            //Với giá trị ngầm định ban đầu
            if (HDN.mahdn == 0 && HDN.mancc == 0 && HDN.nvgiao=="" && HDN.manvnhan==0 && HDN.mahang==0 && HDN.soluong==0 && HDN.gianhap==0 && HDN.ghichu=="")
            {
                KQ = list;
            }
            //Tìm theo mã
            if (HDN.mahdn != 0 && HDN.mancc == 0 && HDN.nvgiao == "" && HDN.manvnhan == 0 && HDN.mahang == 0 && HDN.soluong == 0 && HDN.gianhap == 0 && HDN.ghichu == "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdn == HDN.mahdn)
                    {
                        KQ.Add(new HoaDonNhap(list[i]));
                    }
            }
            else KQ = null;
            return KQ;
        }
    }

}
