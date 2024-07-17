using System;
using System.Text;
using ThreeLayerConsoleT1.PL.UI;

namespace ThreeLayerConsoleT1.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;


            GiangVienUI giangVienUI = new GiangVienUI();

            // Khởi tạo và chạy UI
            giangVienUI.Menu();
        }
    }

}
