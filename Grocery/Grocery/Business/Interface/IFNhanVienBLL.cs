using System;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;

namespace Grocery.Business.Interface
{
    public interface IFNhanVienBLL
    {
        List<NhanVien> XemDSNhanVien();
        void ThemNhanVien(NhanVien NV);
        void XoaNhanVien(int manv);
        void SuaNhanVien(NhanVien nv);
        NhanVien LayNhanVien(int manv);
        List<NhanVien> TimNhanVien(NhanVien NV);
    }
}
