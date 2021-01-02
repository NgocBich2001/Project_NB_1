using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.Business.Interface
{
    public interface IFCTHoaDonNhapBLL
    {
        List<CTHoaDonNhap> XemDSCTHoaDonNhap();
        void ThemCTHoaDonNhap(CTHoaDonNhap CTHDN);
        void XoaCTHoaDonNhap(int mahdn);
    }
}
