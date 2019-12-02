using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpCodeStr = System.IO.File.ReadAllText(@".\..\..\input.txt");
            int[] inpCode = inpCodeStr.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            CompIntcode(ref inpCode, 12, 2);

            for (int i = 0; i < inpCode.Length; i++)
            {
                Console.WriteLine("{0:00}: {1}", i, inpCode[i]);
            }
            Console.ReadLine();

            // Initial value on pos. 0: 250673
            // with chagnged values at start: 5110675
        }

        private static void CompIntcode(ref int[] inpCode, int noun, int verb)
        {
            int pc = 0;
            // prepate with values to replace
            inpCode[1] = noun;
            inpCode[2] = verb;
            // compute
            while (true)
            {
                if (inpCode[pc] == 99)
                {
                    break;
                }
                else if (inpCode[pc] == 1)
                {
                    // addition
                    inpCode[inpCode[pc + 3]] = inpCode[inpCode[pc + 1]] + inpCode[inpCode[pc + 2]];
                }
                else if (inpCode[pc] == 2)
                {
                    // multiplication
                    inpCode[inpCode[pc + 3]] = inpCode[inpCode[pc + 1]] * inpCode[inpCode[pc + 2]];
                }
                pc += 4;
            }
        }
    }
}
