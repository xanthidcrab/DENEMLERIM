using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlInterFaces.Interfaces
{
    public interface IXmlable
    {
         void XmlPrint();
         void XmlRead();
         DataSet XmlDataSet { get; set; }
         DataTable Xml { get; set; }
    }
}
