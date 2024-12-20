using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvVisualizer.CLASSES
{
    public class XMLMODEL
    {
        public PROFILEMODEL Profile { get; set; }
        public SortedDictionary<int, OPERATIONMODEL> OPTABLE;
    }
}
