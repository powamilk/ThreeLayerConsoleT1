namespace ThreeLayerConsoleT1.DAL.Entities
{
    public partial class GiangVien
    {
        public GiangVien()
        {
            MonHocs = new HashSet<MonHoc>();
        }

        public int MaGv { get; set; }
        public string? TenGv { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }

        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
