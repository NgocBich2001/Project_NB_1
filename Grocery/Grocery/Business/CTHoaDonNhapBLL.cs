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
    public class CTHoaDonNhapBLL : IFCTHoaDonNhapBLL
    {
        private IDCTHoaDonNhapDAL CTHDNDA = new CTHoaDonNhapDAL();
        //Thực thi các yêu cầu
        public List<CTHoaDonNhap> XemDSCTHoaDonNhap()
        {
            return CTHDNDA.GetData();
        }
        
        public void ThemCTHoaDonNhap(CTHoaDonNhap CTHDN)
        {
            if (CTHDN.donvi != "")
            {
                CTHDN.donvi = Grocery.Utiility.CongCu.ChuanHoaXau(CTHDN.donvi);
                CTHDNDA.Insert(CTHDN);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public CTHoaDonNhap ReturnSL (int mahh)
        {
            CTHoaDonNhap cthdn = null;
            foreach(CTHoaDonNhap ctn in CTHDNDA.GetData())
            {
                if(ctn.mahang==mahh)
                {
                    cthdn = new CTHoaDonNhap(ctn);
                    break;
                }    
            }
            return cthdn;
        }
        public CTHoaDonNhap ReturnDotNhap(string tenhang, int đot)
        {
            CTHoaDonNhap cthdn = null;
            foreach (CTHoaDonNhap ctn in CTHDNDA.GetData())
            {
                if (ctn.tenhang==tenhang && ctn.đot==đot)
                {
                    cthdn = new CTHoaDonNhap(ctn);
                    break;
                }
            }
            return cthdn;
        }
        public bool KiemTra(int mahdn)
        {
            bool kt = false;
            foreach (CTHoaDonNhap cthdn in CTHDNDA.GetData())
                if (cthdn.mahdn == mahdn)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KiemTraMaHang(int mahdn, int mahang)
        {
            bool kt = false;
            foreach (CTHoaDonNhap cthdn in CTHDNDA.GetData())
                if (cthdn.mahdn == mahdn && cthdn.mahang==mahang)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KiemTraTen(int mahdn, string tenhang)
        {
            bool kt = false;
            foreach (CTHoaDonNhap cthdn in CTHDNDA.GetData())
                if (cthdn.mahdn == mahdn && cthdn.tenhang==tenhang)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KiemTraDot(string tenhang, int dot)
        {
            bool kt = false;
            foreach (CTHoaDonNhap cthdn in CTHDNDA.GetData())
                if (cthdn.tenhang == tenhang && cthdn.đot == dot)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public void XoaCTHoaDonNhap(int mahdn)
        {
            if (KiemTra(mahdn) == true)
                CTHDNDA.Delete(mahdn);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<CTHoaDonNhap> TimCTHoaDonNhap(CTHoaDonNhap CTHDN)
        {
            List<CTHoaDonNhap> list = CTHDNDA.GetData();
            List<CTHoaDonNhap> KQ = new List<CTHoaDonNhap>();
            //Với giá trị ngầm định ban đầu
            if (CTHDN.mahdn == 0)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (CTHDN.mahdn != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahdn == CTHDN.mahdn)
                    {
                        KQ.Add(new CTHoaDonNhap(list[i]));
                    }
            }
            else
                KQ = null;
            return KQ;
        }
    }

}
