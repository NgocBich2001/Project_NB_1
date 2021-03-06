﻿using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.Business.Interface
{
    public interface IFHoaDonNhapBLL
    {
        List<HoaDonNhap> XemDSHoaDonNhap();
        void ThemHoaDonNhap(HoaDonNhap HDN);
        void XoaHoaDonNhap(int mahdn);
        void SuaHoaDonNhap(HoaDonNhap HDN);
        HoaDonNhap LayHoaDonNhap(int mahdn);
        List<HoaDonNhap> TimHoaDonNhap(HoaDonNhap HDN);
    }
}
