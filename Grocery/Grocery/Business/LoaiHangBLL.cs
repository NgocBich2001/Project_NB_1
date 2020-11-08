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
    public class LoaiHangBLL : IFLoaiHangBLL
    {
        private IDLoaiHangDAL MLDA = new LoaiHangDAL();
        //Thực thi các yêu cầu
        public List<LoaiHang> XemDSLoaiHang()
        {
            return MLDA.GetData();
        }
        public void ThemLoaiHang(LoaiHang LH)
        {
            if (LH.tenloai != "" && LH.dacdiem != "")
            {
                LH.tenloai = Grocery.Utiility.CongCu.ChuanHoaXau(LH.tenloai);
                LH.dacdiem = Grocery.Utiility.CongCu.ChuanHoaXau(LH.dacdiem);
                MLDA.Insert(LH);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public LoaiHang LayLoaiHang(int malh)
        {
            int i;
            List<LoaiHang> list = MLDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maloai == malh) break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Khong ton tai ma nay");

        }
        public void XoaLoaiHang( int malh)
        {
            int i;
            List<LoaiHang> list = MLDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maloai == malh)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                MLDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaLoaiHang(LoaiHang LH)
        {
            int i;
            List<LoaiHang> list = MLDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maloai == LH.maloai)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(LH, i);
                MLDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public List<LoaiHang> TimLoaiHang(LoaiHang LH)
        {
            List<LoaiHang> list = MLDA.GetData();
            List<LoaiHang> KQ = new List<LoaiHang>();
            //Với giá trị ngầm định ban đầu
            if (LH.maloai==0 && LH.tenloai==null && LH.dacdiem==null)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (LH.maloai != 0 && LH.tenloai == null && LH.dacdiem == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maloai == LH.maloai)
                    {
                        KQ.Add(new LoaiHang(list[i]));
                    }
            }
            else KQ = null;
            return KQ;
        }
    }

}
