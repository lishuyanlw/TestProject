using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    public class ArgumentsParser
    {
        string[] Args = { };
        private string sourceFileName = String.Empty;
        private string destinationFileName = String.Empty;
        private int conversionType;
        private bool hasHeader = false;
        private bool skipDate=false;
        private string sourceFolder = String.Empty;
        private string destinationFolder = String.Empty;
       
        public ArgumentsParser(string[] args)
        {
            Args = args;
        }

        public string SourceFileName
        {
            get
            {
                if (string.IsNullOrEmpty(sourceFileName))
                {
                    for (int i=0;i<Args.Length;i++)
                    {
                        if (Args[i].ToUpper().Trim().Equals("-S"))
                        {
                            sourceFileName = Args[i+1];
                            break;
                        }
                    }
                }
                return sourceFileName;
            }
        }

        public string DestinationFileName
        {
            get
            {
                if (string.IsNullOrEmpty(destinationFileName))
                {
                    for (int i = 0; i < Args.Length; i++)
                    {
                        if (Args[i].ToUpper().Trim().Equals("-D"))
                        {
                            destinationFileName = Args[i + 1];
                            break;
                        }
                    }                    
                }
                return destinationFileName;
            }
        }

        public int ConversionType
        {
            get
            {
                for (int i = 0; i < Args.Length; i++)
                {
                    if (Args[i].ToUpper().Trim().Equals("-C"))
                    {
                        conversionType = int.Parse(Args[i + 1]);
                        break;
                    }
                }                              
                return conversionType;
            }
        }

        public bool HasHeader
        {
            get
            {
                foreach (var item in Args)
                {
                    if (item.ToLower().Trim().Equals("-header"))
                    {
                        hasHeader = true;
                        break;
                    }
                }

                return hasHeader;
            }
        }

        public bool SkipDate
        {
            get
            {
                foreach (var item in Args)
                {
                    if (item.ToLower().Trim().Equals("-skipdate"))
                    {
                        skipDate = true;
                        break;
                    }
                }

                return skipDate;
            }
        }

        public string SourceFolder
        {
            get
            {
                if (string.IsNullOrEmpty(sourceFolder))
                {
                    sourceFolder = ConfigurationManager.AppSettings["SourceFolder"].ToLower();                    
                }
                sourceFolder = Utility.RemoveLastSlashFromPath(sourceFolder);

                return sourceFolder;
            }
        }

        public string DestinationFolder
        {
            get
            {
                if (string.IsNullOrEmpty(destinationFolder))
                {
                    destinationFolder = ConfigurationManager.AppSettings["DestinationFolder"].ToLower();
                }
                destinationFolder = Utility.RemoveLastSlashFromPath(destinationFolder);

                return destinationFolder;
            }
        }


    }
}
