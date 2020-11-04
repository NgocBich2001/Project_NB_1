using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;

namespace Grocery.Business.Interface
{
    public interface IFHangHoaBLL
    {
        List<HangHoa> XemDSHangHoa();
        void ThemHangHoa(HangHoa HH);
        void XoaHangHoa(int mahh);
        void SuaHangHoa(HangHoa HH);
        List<HangHoa> TimHangHoa(HangHoa HH);
    }
}
