using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            for(int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    int[] tempInp = new int[inpCode.Length];
                    Array.Copy(inpCode, tempInp, inpCode.Length);
                    CompIntcode(ref tempInp, noun, verb);
                    if(tempInp[0] == 19690720)
                    {
                        Console.WriteLine("x={0}, y{1} = {2}", noun, verb, tempInp[0]);
                        Console.WriteLine("Result is: 100 * {0} + {1} = {2}", noun, verb, 100 * noun + verb);
                    }
                }
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }

        private static void CompIntcode(ref int[] inpCode, int noun, int verb)
        {
            int pc = 0;
            // prepate with values to replace
            inpCode[1] = noun;
            inpCode[2] = verb;
            // compute
            try
            {
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
            catch(Exception ex)
            {
                Debug.WriteLine("{0} and {1} caused an error at pc={2}", noun, verb, pc);
            }
        }
    }
}
