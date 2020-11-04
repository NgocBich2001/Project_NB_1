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
    public class NhaCCBLL : IFNhaCCBLL
    {
        private IDNhaCCDAL NCCDA = new NhaCCDAL();
        //Thực thi các yêu cầu
        public List<NCC> XemDSNhaCC()
        {
            return NCCDA.GetData();
        }
        public void ThemNhaCC(NCC nc)
        {
            if (nc.tenncc != "" && nc.diachi != "")
            {
                nc.tenncc = Grocery.Utiility.CongCu.ChuanHoaXau(nc.tenncc);
                nc.diachi = Grocery.Utiility.CongCu.ChuanHoaXau(nc.diachi);
                NCCDA.Insert(nc);
            }
            else
                throw new Exception("Du lieu sai!");
        }
        public void XoaNhaCC(int mancc)
        {
            int i;
            List<NCC> list = NCCDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mancc == mancc)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                NCCDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public void SuaNhaCC(NCC nc)
        {
            int i;
            List<NCC> list = NCCDA.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].mancc == nc.mancc)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(nc, i);
                NCCDA.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này!");
        }
        public List<NCC> TimNhaCC(NCC nc)
        {
            List<NCC> list = NCCDA.GetData();
            List<NCC> KQ = new List<NCC>();
            //Với giá trị ngầm định ban đầu
            if (nc.mancc == 0 && nc.tenncc == null && nc.diachi == null && nc.sdt==0)
            {
                KQ = list;
            }
            //Tìm theo mã
            if (nc.mancc != 0 && nc.tenncc == null && nc.diachi == null && nc.sdt==0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].mancc == nc.mancc)
                    {
                        KQ.Add(new NCC(list[i]));
                    }
            }
            else KQ = null;
            return KQ;
        }
    }

}
