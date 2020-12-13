using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.Business.Interface
{
    public interface IFHoaDonBanBLL
    {
        List<HoaDonBan> XemDSHoaDonBan();
        void ThemHoaDonBan(HoaDonBan HDB);
        void XoaHoaDonBan(int mahdb);
        void SuaHoaDonBan(HoaDonBan HDB);
        HoaDonBan LayHoaDonBan(int mahdb);
        List<HoaDonBan> TimHoaDonBan(HoaDonBan HDB);
    }
}
