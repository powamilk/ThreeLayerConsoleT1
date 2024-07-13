using System;
using ThreeLayerConsoleT1.BUS.Interface;
using ThreeLayerConsoleT1.BUS.ViewModel;

namespace ThreeLayerConsoleT1.PL.UI
{
    public class GiangVienUI
    {
        private readonly IGiangVienService _giangVienService;

        public GiangVienUI(IGiangVienService giangVienService)
        {
            _giangVienService = giangVienService;
        }
        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Chọn chức năng:");
                Console.WriteLine("1. AddGiangVien");
                Console.WriteLine("2. GetListGiangVien");
                Console.WriteLine("3. GetListByTenGV");
                Console.WriteLine("4. GetListByMaGVRange");
                Console.WriteLine("5. UpdateGiangVien");
                Console.WriteLine("6. DeleteGiangVien");
                Console.WriteLine("7. Thoát");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            GiangVienCreateVM createVM = new GiangVienCreateVM();

                            Console.WriteLine("Nhập tên giảng viên:");
                            createVM.TenGV = Console.ReadLine();

                            Console.WriteLine("Nhập email:");
                            createVM.Email = Console.ReadLine();

                            Console.WriteLine("Nhập số điện thoại:");
                            createVM.SoDienThoai = Console.ReadLine();

                            bool result = _giangVienService.AddGiangVien(createVM);
                            if (result)
                            {
                                Console.WriteLine("Thêm giảng viên thành công.");
                            }
                            else
                            {
                                Console.WriteLine("Thêm giảng viên thất bại.");
                            }
                            break;
                        }
                    case "2":
                        {
                            var listGiangVien = _giangVienService.GetListGiangVien();
                            foreach (var giangVien in listGiangVien)
                            {
                                Console.WriteLine($"Mã GV: {giangVien.MaGV}, Tên GV: {giangVien.TenGV}, Email: {giangVien.Email}, SĐT: {giangVien.SoDienThoai}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Nhập tên giảng viên:");
                            string tenGV = Console.ReadLine();

                            var listGiangVien = _giangVienService.GetListByTenGV(tenGV);
                            foreach (var giangVien in listGiangVien)
                            {
                                Console.WriteLine($"Mã GV: {giangVien.MaGV}, Tên GV: {giangVien.TenGV}, Email: {giangVien.Email}, SĐT: {giangVien.SoDienThoai}");
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Nhập từ mã GV:");
                            int fromMaGV = int.Parse(Console.ReadLine());

                            Console.WriteLine("Nhập đến mã GV:");
                            int toMaGV = int.Parse(Console.ReadLine());

                            var listGiangVien = _giangVienService.GetListByMaGVRange(fromMaGV, toMaGV);
                            foreach (var giangVien in listGiangVien)
                            {
                                Console.WriteLine($"Mã GV: {giangVien.MaGV}, Tên GV: {giangVien.TenGV}, Email: {giangVien.Email}, SĐT: {giangVien.SoDienThoai}");
                            }
                            break;
                        }
                    case "5":
                        {
                            GiangVienUpdateVM updateVM = new GiangVienUpdateVM();

                            Console.WriteLine("Nhập mã giảng viên cần cập nhật:");
                            updateVM.MaGV = int.Parse(Console.ReadLine());

                            Console.WriteLine("Nhập email mới:");
                            updateVM.Email = Console.ReadLine();

                            Console.WriteLine("Nhập số điện thoại mới:");
                            updateVM.SoDienThoai = Console.ReadLine();

                            int result = _giangVienService.UpdateGiangVien(updateVM);
                            if (result > 0)
                            {
                                Console.WriteLine("Cập nhật giảng viên thành công.");
                            }
                            else
                            {
                                Console.WriteLine("Cập nhật giảng viên thất bại.");
                            }
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Nhập mã giảng viên cần xóa:");
                            int maGV = int.Parse(Console.ReadLine());

                            int result = _giangVienService.DeleteGiangVien(maGV);
                            if (result > 0)
                            {
                                Console.WriteLine("Xóa giảng viên thành công.");
                            }
                            else
                            {
                                Console.WriteLine("Xóa giảng viên thất bại.");
                            }
                            break;
                        }
                    case "7":
                        Console.WriteLine("Thoát chương trình.");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

                // Đợi người dùng nhấn một phím để tiếp tục hoặc thoát
                if (!exit)
                {
                    Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                    Console.Clear(); // Xóa màn hình để chọn menu tiếp theo
                }

            }
            Console.ReadKey();
        }
    }
}
