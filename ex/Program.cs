using System.IO;

namespace exam_29
{
    class Program
    {
        static void Main(string[] args)
        {
            var intepr = new Interpreter(File.ReadAllLines("../../FirstFile.txt"), File.ReadAllLines("../../SecondFile.txt"));
            var painter = new Painter(intepr);
            painter.Draw();
        }
    }
}
