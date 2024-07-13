using ThreeLayerConsoleT1.DAL.Entities;

namespace ThreeLayerConsoleT1.DAL.Repositories.Interfaces
{
    public interface IGiangVienRepo
    {
        void AddGiangVien(GiangVien giangVien);
        List<GiangVien> GetListGiangVien();
        List<GiangVien> GetListByTenGV(string tenGV);
        List<GiangVien> GetListByMaGVRange(int fromMaGV, int toMaGV);
        int UpdateGiangVien(GiangVien giangVien);
        int DeleteGiangVien(int maGV);
    }
}
