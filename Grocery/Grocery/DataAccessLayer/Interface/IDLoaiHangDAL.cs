using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDLoaiHangDAL
    {
        List<LoaiHang> GetData();
        void Insert(LoaiHang lh);
        void Update(List<LoaiHang> list);
    }
}
