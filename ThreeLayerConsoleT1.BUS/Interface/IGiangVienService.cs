using ThreeLayerConsoleT1.BUS.ViewModel;

namespace ThreeLayerConsoleT1.BUS.Interface
{
    public interface IGiangVienService
    {
        // C: Create
        bool AddGiangVien(GiangVienCreateVM createVM);

        // R: Read
        List<GiangVienVM> GetListGiangVien();
        List<GiangVienVM> GetListByTenGV(string tenGV);
        List<GiangVienVM> GetListByMaGVRange(int fromMaGV, int toMaGV);

        // U: Update
        int UpdateGiangVien(GiangVienUpdateVM updateVM);

        // D: Delete
        int DeleteGiangVien(int maGV);
    }
}
