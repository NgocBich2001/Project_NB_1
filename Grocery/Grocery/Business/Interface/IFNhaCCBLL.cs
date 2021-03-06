﻿using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.Business.Interface
{
    public interface IFNhaCCBLL
    {
        List<NCC> XemDSNhaCC();
        void ThemNhaCC(NCC nc);
        void XoaNhaCC(int manc);
        void SuaNhaCC(NCC nc);
        NCC LayNCC (int mancc);
        List<NCC> TimNhaCC(NCC nc);
    }
}
