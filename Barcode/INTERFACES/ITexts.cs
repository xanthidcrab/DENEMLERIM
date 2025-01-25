namespace Barcode.INTERFACES
{
    public interface ITexts: IHasPaper
    {
        string FontFamilys { get; set; }
        double FontSizes { get; set; }
        string FontStylese { get; set; }
        string FontWeightse { get; set; }
        string Textss { get; set; }
    }
}