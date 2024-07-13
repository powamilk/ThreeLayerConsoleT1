using System;
using System.Collections.Generic;

namespace ThreeLayerConsoleT1.DAL.Entities
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            BuoiTroGiangs = new HashSet<BuoiTroGiang>();
        }

        public int MaMh { get; set; }
        public int? MaGv { get; set; }
        public string? TenMh { get; set; }
        public int? SoTinChi { get; set; }

        public virtual GiangVien? MaGvNavigation { get; set; }
        public virtual ICollection<BuoiTroGiang> BuoiTroGiangs { get; set; }
    }
}
