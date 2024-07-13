using ThreeLayerConsoleT1.DAL.Entities;
using ThreeLayerConsoleT1.DAL.Repositories.Interfaces;

namespace ThreeLayerConsoleT1.DAL.Repositories.Implements
{
    public class GiangVienRepo : IGiangVienRepo
    {
        private readonly AppDbContext _dbContext;

        public GiangVienRepo()
        {
            _dbContext = new AppDbContext(); // Khởi tạo DbContext 
        }

        public void AddGiangVien(GiangVien giangVien)
        {
            _dbContext.GiangViens.Add(giangVien);
            _dbContext.SaveChanges();
        }

        public List<GiangVien> GetListGiangVien()
        {
            return _dbContext.GiangViens.ToList();
        }

        public List<GiangVien> GetListByTenGV(string tenGV)
        {
            return _dbContext.GiangViens.Where(gv => gv.TenGv.Contains(tenGV)).ToList();
        }

        public List<GiangVien> GetListByMaGVRange(int fromMaGV, int toMaGV)
        {
            return _dbContext.GiangViens.Where(gv => gv.MaGv >= fromMaGV && gv.MaGv <= toMaGV).ToList();
        }

        public int UpdateGiangVien(GiangVien giangVien)
        {
            var existingGV = _dbContext.GiangViens.Find(giangVien.MaGv);

            if (existingGV != null)
            {
                existingGV.Email = giangVien.Email;
                existingGV.SoDienThoai = giangVien.SoDienThoai;

                _dbContext.SaveChanges();
                return 1; // Sửa thành công
            }
            else
            {
                return 3; // Không tìm thấy giảng viên để sửa
            }
        }

        public int DeleteGiangVien(int maGV)
        {
            var giangVien = _dbContext.GiangViens.Find(maGV);

            if (giangVien != null)
            {
                _dbContext.GiangViens.Remove(giangVien);
                _dbContext.SaveChanges();
                return 1; // Xóa thành công
            }
            else
            {
                return 3; // Không tìm thấy giảng viên để xóa
            }
        }
    }
}
