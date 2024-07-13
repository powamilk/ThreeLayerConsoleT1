using System;
using System.Collections.Generic;

namespace ThreeLayerConsoleT1.DAL.Entities
{
    public partial class TroGiang
    {
        public TroGiang()
        {
            BuoiTroGiangs = new HashSet<BuoiTroGiang>();
        }

        public int MaTg { get; set; }
        public string? TenTg { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }

        public virtual ICollection<BuoiTroGiang> BuoiTroGiangs { get; set; }
    }
}
