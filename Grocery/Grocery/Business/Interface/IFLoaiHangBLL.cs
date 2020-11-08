using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;

namespace Grocery.Business.Interface
{
    public interface IFLoaiHangBLL
    {
        List<LoaiHang> XemDSLoaiHang();
        void ThemLoaiHang(LoaiHang LH);
        void XoaLoaiHang(int malh);
        void SuaLoaiHang(LoaiHang LH);
        LoaiHang LayLoaiHang(int malh);
        List<LoaiHang> TimLoaiHang(LoaiHang LH);
    }
}
