using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;

namespace Grocery.Business.Interface
{
    public interface IFHoaDonBanBLL
    {
        List<HoaDonBan> XemDSHoaDonBan();
        void ThemHoaDonBan(HoaDonBan HDB);
        void XoaHoaDonBan(int mahdb);
        void SuaHoaDonBan(HoaDonBan HDB);
        List<HoaDonBan> TimHoaDonBan(HoaDonBan HDB);
    }
}
