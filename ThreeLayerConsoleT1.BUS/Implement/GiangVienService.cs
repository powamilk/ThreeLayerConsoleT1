using ThreeLayerConsoleT1.BUS.Interface;
using ThreeLayerConsoleT1.BUS.Utils;
using ThreeLayerConsoleT1.BUS.ViewModel;
using ThreeLayerConsoleT1.DAL.Entities;
using ThreeLayerConsoleT1.DAL.Repositories.Implements;
using ThreeLayerConsoleT1.DAL.Repositories.Interfaces;

namespace ThreeLayerConsoleT1.BUS.Implement
{
    public class GiangVienService : IGiangVienService
    {
        private readonly IGiangVienRepo _giangVienRepo;

        // Constructor không tham số, khởi tạo GiangVienRepo
        public GiangVienService()
        {
            _giangVienRepo = new GiangVienRepo();
        }

        /// <summary>
        /// - What? Thêm mới giảng viên vào CSDL
        /// - Where? Được sử dụng ở case 1 của GiangVienUI
        /// - When? Khi người dùng chọn chức năng 1 để thêm mới giảng viên
        /// - How? Luồng xử lý:
        ///   - B1: Nhận thông tin giảng viên từ GiangVienCreateVM
        ///   - B2: Ánh xạ từ GiangVienCreateVM sang GiangVien entity
        ///   - B3: Thêm giảng viên vào repository
        ///   - B4: Trả về kết quả thêm thành công hoặc thất bại
        /// </summary>
        /// <param name="giangVienCreateVM">Thông tin giảng viên cần thêm</param>
        /// <returns>True nếu thêm thành công, False nếu thất bại</returns>
        public bool AddGiangVien(GiangVienCreateVM giangVienCreateVM)
        {
            try
            {
                // Ánh xạ từ GiangVienCreateVM sang GiangVien entity
                GiangVien giangVien = MappingExtension.MapCreateVMToEntity(giangVienCreateVM);

                // Thêm giảng viên vào repository
                _giangVienRepo.AddGiangVien(giangVien);

                // Trả về true nếu thêm thành công
                return true;
            }
            catch (Exception)
            {
                // Trả về false nếu có lỗi xảy ra
                return false;
            }
        }

        /// <summary>
        /// - What? Lấy danh sách GV từ CSDL
        /// - Where? Được sử dụng ở case 2 của GiangVienUI
        /// - When? Được sử dụng khi người dùng chọn chức năng 2
        /// - How? Luồng xử lý:
        ///   - B1: Lấy danh sách giảng viên từ CSDL
        ///   - B2: Map danh sách GiangVien -> Danh sách GiangVienVM
        ///   - B3: Trả về danh sách GiangVienVM
        ///   - Nếu không tìm thấy giảng viên trong CSDL -> trả về danh sách GiangVien rỗng
        /// </summary>
        /// <returns>Danh sách GiangVienVM, được map từ danh sách GiangVien lấy từ CSDL</returns>
        public List<GiangVienVM> GetListGiangVien()
        {
            // Lấy danh sách giảng viên từ repository
            List<GiangVien> listEntities = _giangVienRepo.GetListGiangVien();

            // Tạo danh sách GiangVienVM để trả về
            List<GiangVienVM> listVMs = new List<GiangVienVM>();

            // Ánh xạ từng thực thể GiangVien sang view model GiangVienVM
            foreach (var entity in listEntities)
            {
                listVMs.Add(MappingExtension.MapEntityToVM(entity));
            }

            // Trả về danh sách view model
            return listVMs;
        }

        /// <summary>
        /// - What? Lấy danh sách GV theo tên từ CSDL
        /// - Where? Được sử dụng ở case 3 của GiangVienUI
        /// - When? Khi người dùng chọn chức năng 3 để tìm kiếm giảng viên theo tên
        /// - How? Luồng xử lý:
        ///   - B1: Lấy danh sách giảng viên theo tên từ CSDL
        ///   - B2: Map danh sách GiangVien -> Danh sách GiangVienVM
        ///   - B3: Trả về danh sách GiangVienVM
        ///   - Nếu không tìm thấy giảng viên theo tên trong CSDL -> trả về danh sách GiangVien rỗng
        /// </summary>
        /// <param name="tenGV">Tên giảng viên cần tìm</param>
        /// <returns>Danh sách GiangVienVM theo tên, được map từ danh sách GiangVien lấy từ CSDL</returns>
        public List<GiangVienVM> GetListByTenGV(string tenGV)
        {
            // Lấy danh sách giảng viên từ repository theo tên
            List<GiangVien> listEntities = _giangVienRepo.GetListByTenGV(tenGV);

            // Tạo danh sách GiangVienVM để trả về
            List<GiangVienVM> listVMs = new List<GiangVienVM>();

            // Ánh xạ từng thực thể GiangVien sang view model GiangVienVM
            foreach (var entity in listEntities)
            {
                listVMs.Add(MappingExtension.MapEntityToVM(entity));
            }

            // Trả về danh sách view model
            return listVMs;
        }

        /// <summary>
        /// - What? Lấy danh sách GV theo khoảng mã từ CSDL
        /// - Where? Được sử dụng ở case 4 của GiangVienUI
        /// - When? Khi người dùng chọn chức năng 4 để tìm kiếm giảng viên theo khoảng mã
        /// - How? Luồng xử lý:
        ///   - B1: Lấy danh sách giảng viên theo khoảng mã từ CSDL
        ///   - B2: Map danh sách GiangVien -> Danh sách GiangVienVM
        ///   - B3: Trả về danh sách GiangVienVM
        ///   - Nếu không tìm thấy giảng viên theo khoảng mã trong CSDL -> trả về danh sách GiangVien rỗng
        /// </summary>
        /// <param name="fromMaGV">Mã giảng viên bắt đầu</param>
        /// <param name="toMaGV">Mã giảng viên kết thúc</param>
        /// <returns>Danh sách GiangVienVM theo khoảng mã, được map từ danh sách GiangVien lấy từ CSDL</returns>
        public List<GiangVienVM> GetListByMaGVRange(int fromMaGV, int toMaGV)
        {
            // Lấy danh sách giảng viên từ repository theo khoảng mã
            List<GiangVien> listEntities = _giangVienRepo.GetListByMaGVRange(fromMaGV, toMaGV);

            // Tạo danh sách GiangVienVM để trả về
            List<GiangVienVM> listVMs = new List<GiangVienVM>();

            // Ánh xạ từng thực thể GiangVien sang view model GiangVienVM
            foreach (var entity in listEntities)
            {
                listVMs.Add(MappingExtension.MapEntityToVM(entity));
            }

            // Trả về danh sách view model
            return listVMs;
        }

        /// <summary>
        /// - What? Cập nhật thông tin giảng viên trong CSDL
        /// - Where? Được sử dụng ở case 5 của GiangVienUI
        /// - When? Khi người dùng chọn chức năng 5 để cập nhật thông tin giảng viên
        /// - How? Luồng xử lý:
        ///   - B1: Nhận thông tin giảng viên từ GiangVienUpdateVM
        ///   - B2: Ánh xạ từ GiangVienUpdateVM sang GiangVien entity
        ///   - B3: Cập nhật giảng viên trong repository
        ///   - B4: Trả về kết quả cập nhật (số lượng bản ghi được cập nhật)
        /// </summary>
        /// <param name="giangVienUpdateVM">Thông tin giảng viên cần cập nhật</param>
        /// <returns>Số lượng giảng viên được cập nhật</returns>
        public int UpdateGiangVien(GiangVienUpdateVM giangVienUpdateVM)
        {
            // Ánh xạ từ GiangVienUpdateVM sang GiangVien entity
            GiangVien giangVien = MappingExtension.MapUpdateVMToEntity(giangVienUpdateVM);

            // Cập nhật giảng viên trong repository
            return _giangVienRepo.UpdateGiangVien(giangVien);
        }

        /// <summary>
        /// - What? Xóa giảng viên khỏi CSDL
        /// - Where? Được sử dụng ở case 6 của GiangVienUI
        /// - When? Khi người dùng chọn chức năng 6 để xóa giảng viên
        /// - How? Luồng xử lý:
        ///   - B1: Nhận mã giảng viên cần xóa
        ///   - B2: Xóa giảng viên trong repository
        ///   - B3: Trả về kết quả xóa (số lượng bản ghi được xóa)
        /// </summary>
        /// <param name="maGV">Mã giảng viên cần xóa</param>
        /// <returns>Số lượng giảng viên được xóa</returns>
        public int DeleteGiangVien(int maGV)
        {
            // Xóa giảng viên trong repository
            return _giangVienRepo.DeleteGiangVien(maGV);
        }
    }
}
