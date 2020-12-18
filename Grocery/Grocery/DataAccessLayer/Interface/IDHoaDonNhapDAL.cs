using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDHoaDonNhapDAL
    {
        List<HoaDonNhap> GetData();
        void Insert(HoaDonNhap hdn);
        void Update(HoaDonNhap hdn);
        void Delete(int mahdn);
    }
}
