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
    //Thực thi các yêu cầu nghiệp vụ 
    public class HangHoaBLL : IFHangHoaBLL
    {
        private IDHangHoaDAL HHDA = new HangHoaDAL();
        //Thực thi các yêu cầu
        public List<HangHoa> XemDSHangHoa()
        {
            return HHDA.GetData();
        }
        public void ThemHangHoa(HangHoa HH)
        {
            if (HH.tenhang != "")
            {
                HH.tenhang = Grocery.Utiility.CongCu.ChuanHoaXau(HH.tenhang);
                HHDA.Insert(HH);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public bool KiemTra(int mahh)
        {
            bool kt = false;
            foreach (HangHoa hh in HHDA.GetData())
                if (hh.mahh == mahh)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KiemTraTen(string tenhh)
        {
            bool kt = false;
            foreach (HangHoa hh in HHDA.GetData())
                if (hh.tenhang == tenhh)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public void XoaHangHoa(int mahh)
        {
            int i;
            List<HangHoa> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == mahh)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                HHDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaHangHoa(HangHoa HH)
        {
            int i;
            List<HangHoa> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == HH.mahh)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(HH);
                HHDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public HangHoa LayHangHoa(int mahh)
        {
            int i;
            List<HangHoa> list = HHDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mahh == mahh) 
                    break;
            if (i < list.Count)
            {
                return list[i];
            }
            else
                throw new Exception("Không tồn tại mã này!");

        }
        public List<HangHoa> TimHangHoa(HangHoa HH)
        {
            List<HangHoa> list = HHDA.GetData();
            List<HangHoa> KQ = new List<HangHoa>();
            //Với giá trị ngầm định ban đầu
            if (HH.mahh == 0 && HH.tenhang == null)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (HH.mahh != 0 && HH.tenhang == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mahh == HH.mahh)
                    {
                        KQ.Add(new HangHoa(list[i]));
                    }
            }
            else if (HH.mahh ==0 && HH.tenhang != null)
            {
                for (int i=0; i<list.Count;i++)
                {
                    if (list[i].tenhang == HH.tenhang)
                    {
                        KQ.Add(new HangHoa(list[i]));
                    }    
                }    
            }    
            else KQ = null;
            return KQ;
        }
    }

}
