using ThreeLayerConsoleT1.BUS.Interface;
using ThreeLayerConsoleT1.BUS.Utils;
using ThreeLayerConsoleT1.BUS.ViewModel;
using ThreeLayerConsoleT1.DAL.Entities;
using ThreeLayerConsoleT1.DAL.Repositories.Interfaces;



namespace ThreeLayerConsoleT1.BUS.Implement
{
    public class GiangVienService : IGiangVienService
    {
        private readonly IGiangVienRepo _giangVienRepo;

        public GiangVienService(IGiangVienRepo giangVienRepo)
        {
            _giangVienRepo = giangVienRepo;
        }

        public bool AddGiangVien(GiangVienCreateVM giangVienCreateVM)
        {
            try
            {
                GiangVien giangVien = MappingExtension.MapCreateVMToEntity(giangVienCreateVM);
                _giangVienRepo.AddGiangVien(giangVien);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GiangVienVM> GetListGiangVien()
        {
            List<GiangVien> listEntities = _giangVienRepo.GetListGiangVien();
            List<GiangVienVM> listVMs = new List<GiangVienVM>();

            foreach (var entity in listEntities)
            {
                listVMs.Add(MappingExtension.MapEntityToVM(entity));
            }

            return listVMs;
        }

        public List<GiangVienVM> GetListByTenGV(string tenGV)
        {
            List<GiangVien> listEntities = _giangVienRepo.GetListByTenGV(tenGV);
            List<GiangVienVM> listVMs = new List<GiangVienVM>();

            foreach (var entity in listEntities)
            {
                listVMs.Add(MappingExtension.MapEntityToVM(entity));
            }

            return listVMs;
        }

        public List<GiangVienVM> GetListByMaGVRange(int fromMaGV, int toMaGV)
        {
            List<GiangVien> listEntities = _giangVienRepo.GetListByMaGVRange(fromMaGV, toMaGV);
            List<GiangVienVM> listVMs = new List<GiangVienVM>();

            foreach (var entity in listEntities)
            {
                listVMs.Add(MappingExtension.MapEntityToVM(entity));
            }

            return listVMs;
        }

        public int UpdateGiangVien(GiangVienUpdateVM giangVienUpdateVM)
        {
            GiangVien giangVien = MappingExtension.MapUpdateVMToEntity(giangVienUpdateVM);
            return _giangVienRepo.UpdateGiangVien(giangVien);
        }

        public int DeleteGiangVien(int maGV)
        {
            return _giangVienRepo.DeleteGiangVien(maGV);
        }
    }
}
