using System;
using System.Collections.Generic;
using System.Text;
using Grocery.ThucThe;
using Grocery.Utiility;
using Grocery.DataAccessLayer;
using Grocery.Business.Interface;

namespace Grocery.Business
{
    
    public class LoaiHangBLL : IFLoaiHangBLL
    {
        private IFLoaiHangDAL LH = new LoaiHangDAL();
        //Thực thi các yêu cầu
        public List<LoaiHang> LayDSLoaiHang()
        {
            return LH.GetData();
        }
    }
    
}
