namespace ThreeLayerConsoleT1.BUS.ViewModel
{
    public class GiangVienVM
    {
        public int MaGV { get; set; }
        public string TenGV { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }

        public void InThongTin()
        {
            Console.WriteLine($"MaGV: {MaGV}, TenGV: {TenGV}, Email: {Email}, SoDienThoai: {SoDienThoai}");
        }
    }
}
