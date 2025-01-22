namespace Barcode.INTERFACES
{
    public interface IBarcode
    {
        
        string BarcodeCode { get; set; }
        string BarcodeType { get; set; }
        int Seperator { get; set; }    
    }
}
