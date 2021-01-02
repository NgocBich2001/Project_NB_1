using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDCTHoaDonNhapDAL
    {
        List<CTHoaDonNhap> GetData();
        void Insert(CTHoaDonNhap cthdn);
        //void Update(CTHoaDonNhap cthdn);
        void Delete(int mahdn);
    }
}
