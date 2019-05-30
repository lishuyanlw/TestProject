using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    public class FileConversion
    {
        private ILineConversion iLineConversion;
        public StandardDataArray standardDataArray;
        private string sourceFilename;
        private string destinationFilename;
        private bool bHasHeader;
        private bool bSkipDate;
        public FileConversion(ILineConversion iLineConversion,ArgumentsParser argumentsParser)
        {
            this.iLineConversion = iLineConversion;
            this.sourceFilename = Path.Combine(argumentsParser.SourceFolder,argumentsParser.SourceFileName);
            this.destinationFilename = Path.Combine(argumentsParser.DestinationFolder,argumentsParser.DestinationFileName);
            this.bHasHeader = argumentsParser.HasHeader;
            this.bSkipDate = argumentsParser.SkipDate;
            standardDataArray = new StandardDataArray();            
        }        

        public void Process()
        {
            ReadFile(bHasHeader);
            WriteFile(bSkipDate);
        }

        private StandardDataItem FileConvert(string line)
        {
            return iLineConversion.LineConvert(line);
        }

        public void ReadFile(bool bHasHeader)
        {
            List<string> listLine = null;
            using (var reader = new StreamReader(sourceFilename))
            {
                listLine = new List<string>();
                if (bHasHeader)
                {
                    reader.ReadLine();
                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listLine.Add(line);
                    standardDataArray.recordList.Add(iLineConversion.LineConvert(line));
                }
                reader.Close();
            }
        }

        public void WriteFile(bool bSkipDate)
        {           
            using (var writer = new StreamWriter(destinationFilename, true))
            {
                writer.WriteLine(GetHeader(bSkipDate));
                foreach (var item in standardDataArray.recordList)
                {
                    writer.WriteLine(GetLine(item,bSkipDate));
                }
                writer.Close();              
            }
        }

        public string GetHeader(bool bSkipDate)
        {
            if (bSkipDate)
            {
                return "AccountCode,Name,Type,Currecy";
            }
            else
            {
                return "AccountCode,Name,Type,Open Date,Currecy";
            }            
        }

        public string GetLine(StandardDataItem standardDataItem,bool bSkipDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(standardDataItem.AccountCode);
            builder.Append(",");
            builder.Append(standardDataItem.Name);
            builder.Append(",");
            builder.Append(standardDataItem.Type);
            builder.Append(",");
            if (!bSkipDate)
            {
                builder.Append(standardDataItem.OpenDate);
                builder.Append(",");
            }            
            builder.Append(standardDataItem.Currency);

            return builder.ToString();
        }

    }

    public class StandardDataItem
    {
        public string AccountCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string OpenDate { get; set; }
        public string Currency { get; set; }
    }

    public class StandardDataArray
    {
        public List<StandardDataItem> recordList = new List<StandardDataItem>();
    }
}
