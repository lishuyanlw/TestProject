using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0].ToLower().Trim().Equals("help"))
            {
                Console.WriteLine(Utility.GetHelpMessage());
                return;
            }   
                  
            if (args.Length<3)
            {
                Console.WriteLine("Please input 'TransformData help' to get correct usages!");
                return;
            }

            Factory.CreateFileConversion(new ArgumentsParser(args)).Process();
            
            Console.WriteLine("Sucessfully!");
        }
    }
}
