using System;


namespace exam_29
{
    class Painter
    {
        public Interpreter Intepreter { get; set; }

        public Painter(Interpreter intepreter)
        {
            Intepreter = intepreter;
        }

        public void Draw()
        {
            Console.Clear();
            var res = Intepreter.GetDiffrences();
            for (int i = 0; i < res.Item1.Length; i++)
            {
                Console.ForegroundColor = res.Item2[i];
                Console.WriteLine(res.Item1[i]);
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
