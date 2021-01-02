using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDCTHoaDonBanDAL
    {
        List<CTHoaDonBan> GetData();
        void Insert(CTHoaDonBan cthdb);
        //void Update(CTHoaDonNhap cthdn);
        void Delete(int mahdb);
    }
}