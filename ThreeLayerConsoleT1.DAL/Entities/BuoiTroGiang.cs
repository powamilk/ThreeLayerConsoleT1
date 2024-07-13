using System;
using System.Collections.Generic;

namespace ThreeLayerConsoleT1.DAL.Entities
{
    public partial class BuoiTroGiang
    {
        public int MaBtg { get; set; }
        public int? MaMh { get; set; }
        public int? MaTg { get; set; }
        public int? SoThuTu { get; set; }

        public virtual MonHoc? MaMhNavigation { get; set; }
        public virtual TroGiang? MaTgNavigation { get; set; }
    }
}
