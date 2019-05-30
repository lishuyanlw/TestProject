using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    public static class Utility
    {
        public static string[] SplitLine(this string line, char parserChar)
        {
            return line.Split(parserChar);
        }

        public static bool CheckIsNumber(string checkString)
        {
            int n;
            return int.TryParse(checkString, out n);
        }

        public static string RemoveLastSlashFromPath(string inputFolder)
        {
            string outputFolder;
            if (inputFolder.Substring(inputFolder.Length - 1, 1) == @"\" || inputFolder.Substring(inputFolder.Length - 1, 1) == @"/")
            {
                outputFolder = inputFolder.Substring(0, inputFolder.Length - 1);
            }
            else
            {
                outputFolder = inputFolder;
            }

            return outputFolder;
        }

        public static string GetHelpMessage()
        {
            string help = "Usage:\r\n";
            help += "TransformData -S sourceFilename -D destinationFilename -C covererNumber -header -skipdate" + "\r\n";
            help += "Parameters description as follows:\r\n";
            help += "S: source filename, the folder can be defined in config file\r\n";
            help += "D: destination filename, the folder can be defined in config file\r\n";
            help += "C: file converter number, start from 1\r\n";
            help += "header: optional,the first line of source file is header, default is no header\r\n";
            help += "skipdate: optional, there is no date column in destination file, default is to contain date column";

            return help;
        }
    }
}
