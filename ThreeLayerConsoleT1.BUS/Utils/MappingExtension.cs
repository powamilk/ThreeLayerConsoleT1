using ThreeLayerConsoleT1.BUS.ViewModel;
using ThreeLayerConsoleT1.DAL.Entities;

namespace ThreeLayerConsoleT1.BUS.Utils
{
    public static class MappingExtension
    {
        public static GiangVienVM MapEntityToVM(GiangVien entity)
        {
            if (entity == null)
                return null;

            return new GiangVienVM
            {
                MaGV = entity.MaGv,
                TenGV = entity.TenGv,
                Email = entity.Email,
                SoDienThoai = entity.SoDienThoai
            };
        }

        public static GiangVien MapCreateVMToEntity(GiangVienCreateVM createVM)
        {
            if (createVM == null)
                return null;

            return new GiangVien
            {
                TenGv = createVM.TenGV,
                Email = createVM.Email,
                SoDienThoai = createVM.SoDienThoai
            };
        }

        public static GiangVien MapUpdateVMToEntity(GiangVienUpdateVM updateVM)
        {
            return new GiangVien
            {
                MaGv = updateVM.MaGV,
                Email = updateVM.Email,
                SoDienThoai = updateVM.SoDienThoai
            };
        }
    }
}

