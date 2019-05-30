using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    public class LineConversion1:ILineConversion
    {       
        public StandardDataItem LineConvert(string line)
        {
            string[] lineArray = line.SplitLine(',');
            StandardDataItem standardDataItem = new StandardDataItem();
            if (Utility.CheckIsNumber(lineArray[0].Split('|')[0].Trim()))
            {
                standardDataItem.AccountCode = lineArray[0].Split('|')[1].Trim();
            }
            else
            {
                standardDataItem.AccountCode = lineArray[0].Split('|')[0].Trim();
            }
            standardDataItem.Name = lineArray[1].Trim();
            standardDataItem.Type = ConvertType(lineArray[2]).Trim();
            standardDataItem.OpenDate = ConvertDate(lineArray[3]).Trim();
            standardDataItem.Currency = ConvertCurrency(lineArray[4]).Trim();

            return standardDataItem;
        }

        private string ConvertType(string type)
        {
            string lsType = String.Empty;
            switch (type)
            {
                case "1":
                    lsType = "Trading";
                    break;
                case "2":
                    lsType = "RRSP";
                    break;
                case "3":
                    lsType = "RESP";
                    break;
                case "4":
                    lsType = "Fund";
                    break;
                default:
                    break;
            }

            return lsType;
        }

        private string ConvertCurrency(string currency)
        {
            string lsCurrency = String.Empty;
            switch (currency)
            {
                case "CD":
                    lsCurrency = "CAD";
                    break;
                case "US":
                    lsCurrency = "USD";
                    break;
                default:
                    break;
            }

            return lsCurrency;
        }

        private string ConvertDate(string date)
        {
            string[] splitDate = date.Split('-');
            return splitDate[2] + "-" + splitDate[0] + "-" + splitDate[1];
        }
    }
}
