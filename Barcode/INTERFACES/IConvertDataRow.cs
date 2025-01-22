using Barcode.Classes;
using System.Data;

namespace Barcode.INTERFACES
{
    public interface IConvertDataRow
    {
        CRUD CRUD { get;  }
        DataRow ConvertDataRow();
    }
    
}
