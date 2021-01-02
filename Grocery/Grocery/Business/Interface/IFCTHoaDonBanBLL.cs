using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.Business.Interface
{
    public interface IFCTHoaDonBanBLL
    {
        List<CTHoaDonBan> XemDSCTHoaDonBan();
        void ThemCTHoaDonBan(CTHoaDonBan CTHDB);
        void XoaCTHoaDonBan(int mahdb);
    }
}