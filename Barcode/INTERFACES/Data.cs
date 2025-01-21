using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Barcode.INTERFACES
{
    public interface IData 
    {
        MainWindow MainWindow { get; set; }
        int ID { get; set; }
        string ElementName { get; set; }
        int Type { get;  }

    }
    
}
