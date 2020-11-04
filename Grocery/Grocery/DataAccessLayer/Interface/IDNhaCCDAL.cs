using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDNhaCCDAL
    {
        List<NCC> GetData();
        void Insert(NCC nc);
        void Update(List<NCC> list);
    }
}
