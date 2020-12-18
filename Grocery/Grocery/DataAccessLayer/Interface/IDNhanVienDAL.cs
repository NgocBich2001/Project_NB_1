using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDNhanVienDAL
    {
        List<NhanVien> GetData();
        void Insert(NhanVien nv);
        void Update(NhanVien nv);
        void Delete(int manv);
    }
}
