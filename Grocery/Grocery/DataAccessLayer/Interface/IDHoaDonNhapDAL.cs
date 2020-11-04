using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDHoaDonNhapDAL
    {
        List<HoaDonNhap> GetData();
        void Insert(HoaDonNhap hdn);
        void Update(List<HoaDonNhap> list);
    }
}
