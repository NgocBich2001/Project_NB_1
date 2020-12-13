using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;
using System.Collections.Generic;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDNhaCCDAL
    {
        List<NCC> GetData();
        void Insert(NCC nc);
        void Update(List<NCC> list);
    }
}
