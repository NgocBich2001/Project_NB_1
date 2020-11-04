﻿using System;
using System.Text;
using Grocery.Utiility;
using Grocery.ThucThe;
using Grocery.DataAccessLayer;

namespace Grocery.DataAccessLayer.Interface
{
    public interface IDHangHoaDAL
    {
        List<HangHoa> GetData();
        void Insert(HangHoa hh);
        void Update(List<HangHoa> list);
    }
}