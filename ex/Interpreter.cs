using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_29
{
    class Interpreter
    {
        public string[] FirstFile { get; set; }

        public string[] SecondFile { get; set; }

        public Interpreter(string[] firstFile, string[] secondFile)
        {
            FirstFile = firstFile;
            SecondFile = secondFile;
        }
        //по сути пойдёт, есть косяки, но это хуйня я надеюсь ты переписал всё
        public Tuple<string[], ConsoleColor[]> GetDiffrences()
        {
            var adv = Math.Max(FirstFile.Length, SecondFile.Length);
            var result = new string[adv];
            var colors = new ConsoleColor[result.Length];
            var sb = new StringBuilder();
            for (int i = 0; i < adv-1; i++)
            {
                int countDiff = 0;          
                if (i>FirstFile.Length || i > SecondFile.Length)
                {
                    result[i] = "??";
                    colors[i] = ConsoleColor.Yellow;
                    break;
                }
                var splitFirstStr = FirstFile[i].ToCharArray();
                var splitSecondStr = SecondFile[i].ToCharArray();
                var diffCountSymbols = Math.Abs(splitFirstStr.Length - splitSecondStr.Length);
                for (int j = 0; j < Math.Min(splitFirstStr.Length, splitSecondStr.Length)-1; j++)
                {
                    if (splitFirstStr[j] != splitSecondStr[j])
                    {
                        sb.Append(splitSecondStr[j]);
                        countDiff++;
                    }
                    else if (splitFirstStr[j] == splitSecondStr[j])
                        sb.Append(splitSecondStr[j]);
                    else 
                        sb.Append(' ');
                }
                if (countDiff == 0)
                    result[i] = null;
                else if(countDiff>2 && splitFirstStr.Length>splitSecondStr.Length)
                {
                    result[i]= RefreshStringBuilder(sb,'-');
                    colors[i] = ConsoleColor.Red;
                }
                else if(countDiff > 2 && splitFirstStr.Length < splitSecondStr.Length)
                {
                    result[i] = RefreshStringBuilder(sb,'+');
                    colors[i] = ConsoleColor.Green;
                }
                else 
                {
                    result[i] = RefreshStringBuilder(sb, '~');
                    colors[i] = ConsoleColor.Blue;
                }
                sb.Clear();
            }
            return new Tuple<string[], ConsoleColor[]>(result, colors);
        }

        public string RefreshStringBuilder(StringBuilder sb, char op)
        {
            if (op == '+')
            {
                var str = sb.ToString();
                sb.Clear();
                sb.Append("+");
                sb.Append(str);
            }
            else if (op == '-')
            {
                var str = sb.ToString();
                sb.Clear();
                sb.Append("-");
                sb.Append(str);
            }
            else if (op == '~')
            {
                var str = sb.ToString();
                sb.Clear();
                sb.Append("~");
                sb.Append(str);
            }
            else throw new Exception();
            return sb.ToString();
        }
    }
}
