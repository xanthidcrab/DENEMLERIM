using System.Data;

namespace Barcode.INTERFACES
{
    public interface IConvertDataRow
    {
        DataRow ConvertDataRow(IData data);
    }
    
}
