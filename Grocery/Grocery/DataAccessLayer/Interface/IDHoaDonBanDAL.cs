﻿using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDHoaDonBanDAL
    {
        List<HoaDonBan> GetData();
        void Insert(HoaDonBan hdb);
        void Update(List<HoaDonBan> list);
    }
}
