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
    public class NhanVienBLL : IFNhanVienBLL
    {
        private IDNhanVienDAL NVDA = new NhanVienDAL();
        //Thực thi các yêu cầu
        public List<NhanVien> XemDSNhanVien()
        {
            return NVDA.GetData();
        }
        public void ThemNhanVien(NhanVien NV)
        {
            if (NV.tennv != "" && NV.gt!= "" && NV.pass != "")
            {
                NV.tennv = Grocery.Utiility.CongCu.ChuanHoaXau(NV.tennv);
                NV.gt = Grocery.Utiility.CongCu.ChuanHoaXau(NV.gt);
                NV.pass = Grocery.Utiility.CongCu.ChuanHoaXau(NV.pass);
                NVDA.Insert(NV);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public void XoaNhanVien(int manv)
        {
            int i;
            List<NhanVien> list = NVDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == manv)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                NVDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaNhanVien(NhanVien nv)
        {
            int i;
            List<NhanVien> list = NVDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].manv == nv.manv)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(nv, i);
                NVDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public List<NhanVien> TimNhanVien(NhanVien NV)
        {
            List<NhanVien> list = NVDA.GetData();
            List<NhanVien> KQ = new List<NhanVien>();
            //Với giá trị ngầm định ban đầu
            if (NV.manv == 0 && NV.tennv == null && NV.gt == null && NV.pass==null)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (NV.manv != 0 && NV.tennv == null && NV.pass == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].manv == NV.manv)
                    {
                        KQ.Add(new NhanVien(list[i]));
                    }
            }
            else KQ = null;
            return KQ;
        }
    }

}
