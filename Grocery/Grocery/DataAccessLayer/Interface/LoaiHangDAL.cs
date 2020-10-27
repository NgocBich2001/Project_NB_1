using Grocery.ThucThe;
using Grocery.Utiility;
using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DataAccessLayer;

namespace Grocery.DataAccessLayer
{
    public interface IFLoaiHangDAL
    {
        List<LoaiHang> GetData();
        void Insert(LoaiHang lh);
        void Update(List<LoaiHang> list);
    }
}
    