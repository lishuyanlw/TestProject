using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    public interface ILineConversion
    {
        StandardDataItem LineConvert(string line);
    }
}
