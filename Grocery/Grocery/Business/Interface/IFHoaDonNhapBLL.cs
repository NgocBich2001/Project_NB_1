using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;

namespace Grocery.Business.Interface
{
    public interface IFHoaDonNhapBLL
    {
        List<HoaDonNhap> XemDSHoaDonNhap();
        void ThemHoaDonNhap(HoaDonNhap HDN);
        void XoaHoaDonNhap(int mahdn);
        void SuaHoaDonNhap(HoaDonNhap HDN);
        List<HoaDonNhap> TimHoaDonNhap(HoaDonNhap HDN);
    }
}
