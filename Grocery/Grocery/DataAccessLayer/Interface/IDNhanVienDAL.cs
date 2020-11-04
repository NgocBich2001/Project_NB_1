using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDNhanVienDAL
    {
        List<NhanVien> GetData();
        void Insert(NhanVien nv);
        void Update(List<NhanVien> list);
    }
}
