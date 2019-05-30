using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    public class LineConversion2 : ILineConversion
    {
        public StandardDataItem LineConvert(string line)
        {
            string[] lineArray = line.SplitLine(',');
            StandardDataItem standardDataItem = new StandardDataItem();
            standardDataItem.AccountCode = lineArray[3].Trim();
            standardDataItem.Name = lineArray[0].Trim();
            standardDataItem.Type = lineArray[1].Trim();
            standardDataItem.OpenDate = "";
            standardDataItem.Currency = ConvertCurrency(lineArray[2]).Trim();

            return standardDataItem;
        }

        private string ConvertCurrency(string currency)
        {
            string lsCurrency = String.Empty;
            switch (currency)
            {
                case "C":
                    lsCurrency = "CAD";
                    break;
                case "U":
                    lsCurrency = "USD";
                    break;
                default:
                    break;
            }

            return lsCurrency;
        }
    }
}
