using System;
using System.Text;
using ThreeLayerConsoleT1.BUS.Implement;
using ThreeLayerConsoleT1.DAL.Repositories.Implements;
using ThreeLayerConsoleT1.DAL.Repositories.Interfaces;
using ThreeLayerConsoleT1.PL.UI;

namespace ThreeLayerConsoleT1.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            IGiangVienRepo giangVienRepo = new GiangVienRepo();

            // Truyền giangVienRepo vào GiangVienService
            var giangVienService = new GiangVienService(giangVienRepo);

            // Khởi tạo và chạy UI
            var giangVienUI = new GiangVienUI(giangVienService);
            giangVienUI.Menu();
        }
    }

}
