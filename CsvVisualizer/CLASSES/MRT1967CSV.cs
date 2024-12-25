using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvVisualizer.CLASSES
{
    public class MRT1967CSV
    {
        public int Id { get; set; }
        public bool Cut { get; set; }
        public int NumberOfBarInWorklist { get; set; }
        public double UncutBarLength { get; set; }
        public int NumberOfPieceInBar { get; set; }
        public double PieceLength { get; set; }
        public double Cut1Angle1 { get; set; }
        public int Cut1Angle1Saw { get; set; }
        public double Cut1Angle2 { get; set; }
        public int Cut1Angle2Saw { get; set; }
        public double Cut2Angle1 { get; set; }
        public int Cut2Angle1Saw { get; set; }
        public double Cut2Angle2 { get; set; }
        public int Cut2Angle2Saw { get; set; }
        public string StockCode { get; set; }
        public double WeldingSeamSpace { get; set; }
        public string ProfileName { get; set; }
        public double ProfileSizeX { get; set; }
        public double ProfileSizeY { get; set; }
        public string Trolley { get; set; }
        public string Shelf { get; set; }
        public string MountingPosition { get; set; }
        public string SteelCode { get; set; }
        public double SteelLength { get; set; }
        public string GlazingBeadCode { get; set; }
        public double GlazingBeadLength { get; set; }
        public string ProductionBatchNumber { get; set; }
        public string OrderName { get; set; }
        public string FrameId { get; set; }
        public string ProducerName { get; set; }
        public string CustomerName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string Operations { get; set; }
        public string BarcodeString { get; set; }
        public string LabelImagePath { get; set; }
        public string ProductionDate { get; set; }
        public string DeliveryDate { get; set; }
        public static double Zero { get { return 0; } }
        public int OrginalId { get; set; }
        public double FrameWidth { get; set; }
        public double FrameHeight { get; set; }
        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }
        public int ProfileIndex { get; set; }
        public string WasteImage { get; set; }
        public double ClampPressure { get; set; }
        public double FrameWidthWithWeldingSeam { get { return FrameWidth + WeldingSeamSpace; } }
        public double FrameHeightWithWeldingSeam { get { return FrameHeight + WeldingSeamSpace; } }

        public string FrameWidth_Barcode { get { return Convert.ToDouble(FrameWidth).ToString("0.0").Replace(".", ""); } }
        public string FrameHeight_Barcode { get { return Convert.ToDouble(FrameHeight).ToString("0.0").Replace(".", ""); } }
        public string FrameWidthWithWeldingSeam_Barcode { get { return Convert.ToDouble(FrameWidthWithWeldingSeam).ToString("0.0").Replace(".", ""); } }
        public string FrameHeightWithWeldingSeam_Barcode { get { return Convert.ToDouble(FrameHeightWithWeldingSeam).ToString("0.0").Replace(".", ""); } }
        public string PieceLength_Barcode { get { return Convert.ToDouble(PieceLength).ToString("0.0").Replace(".", ""); } }
        public string SteelLength_Barcode { get { return Convert.ToDouble(SteelLength).ToString("0.0").Replace(".", ""); } }

        public string Custom_1 { get; set; }
        public string Custom_2 { get; set; }
        public string Custom_3 { get; set; }
        public string Custom_4 { get; set; }
        public string Custom_5 { get; set; }
    }
}
