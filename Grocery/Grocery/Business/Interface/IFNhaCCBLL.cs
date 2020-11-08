using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;

namespace Grocery.Business.Interface
{
    public interface IFNhaCCBLL
    {
        List<NCC> XemDSNhaCC();
        void ThemNhaCC(NCC nc);
        void XoaNhaCC(int manc);
        void SuaNhaCC(NCC nc);
        NhanVien LayNCC (int mancc);
        List<NCC> TimNhaCC(NCC nc);
    }
}
