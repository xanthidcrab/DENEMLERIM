using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvVisualizer.CLASSES
{
    public interface ICreateSelf
    {
         void CreateSelf(SortedList<int,DXFMODEL> parent);
    }
}
