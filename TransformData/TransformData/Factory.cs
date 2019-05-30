using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    class Factory
    {
        public static FileConversion CreateFileConversion(ArgumentsParser argumentsParser)
        {
            FileConversion fileConversion=null;
            switch (argumentsParser.ConversionType)
            {
                case 1:
                    fileConversion = new FileConversion(new LineConversion1(), argumentsParser);
                    break;
                case 2:
                    fileConversion = new FileConversion(new LineConversion2(), argumentsParser);
                    break;
                default:
                    break;
            }

            return fileConversion;
        }
    }
        
}
