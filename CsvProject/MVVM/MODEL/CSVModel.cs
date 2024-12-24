using CsvProject.CLASSES.ABSTRACT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvProject.CLASSES
{
    public class CSVModel : BaseViewModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        private bool _cut;
        public bool Cut
        {
            get { return _cut; }
            set { _cut = value; OnPropertyChanged(nameof(Cut)); }
        }

        private int _numberOfBarInWorklist;
        public int NumberOfBarInWorklist
        {
            get { return _numberOfBarInWorklist; }
            set { _numberOfBarInWorklist = value; OnPropertyChanged(nameof(NumberOfBarInWorklist)); }
        }

        private double _uncutBarLength;
        public double UncutBarLength
        {
            get { return _uncutBarLength; }
            set { _uncutBarLength = value; OnPropertyChanged(nameof(UncutBarLength)); }
        }

        private int _numberOfPieceInBar;
        public int NumberOfPieceInBar
        {
            get { return _numberOfPieceInBar; }
            set { _numberOfPieceInBar = value; OnPropertyChanged(nameof(NumberOfPieceInBar)); }
        }

        private double _pieceLength;
        public double PieceLength
        {
            get { return _pieceLength; }
            set { _pieceLength = value; OnPropertyChanged(nameof(PieceLength)); }
        }

        private double _cut1Angle1;
        public double Cut1Angle1
        {
            get { return _cut1Angle1; }
            set { _cut1Angle1 = value; OnPropertyChanged(nameof(Cut1Angle1)); }
        }

        private int _cut1Angle1Saw;
        public int Cut1Angle1Saw
        {
            get { return _cut1Angle1Saw; }
            set { _cut1Angle1Saw = value; OnPropertyChanged(nameof(Cut1Angle1Saw)); }
        }

        private double _cut1Angle2;
        public double Cut1Angle2
        {
            get { return _cut1Angle2; }
            set { _cut1Angle2 = value; OnPropertyChanged(nameof(Cut1Angle2)); }
        }

        private int _cut1Angle2Saw;
        public int Cut1Angle2Saw
        {
            get { return _cut1Angle2Saw; }
            set { _cut1Angle2Saw = value; OnPropertyChanged(nameof(Cut1Angle2Saw)); }
        }

        private double _cut2Angle1;
        public double Cut2Angle1
        {
            get { return _cut2Angle1; }
            set { _cut2Angle1 = value; OnPropertyChanged(nameof(Cut2Angle1)); }
        }

        private int _cut2Angle1Saw;
        public int Cut2Angle1Saw
        {
            get { return _cut2Angle1Saw; }
            set { _cut2Angle1Saw = value; OnPropertyChanged(nameof(Cut2Angle1Saw)); }
        }

        private double _cut2Angle2;
        public double Cut2Angle2
        {
            get { return _cut2Angle2; }
            set { _cut2Angle2 = value; OnPropertyChanged(nameof(Cut2Angle2)); }
        }

        private int _cut2Angle2Saw;
        public int Cut2Angle2Saw
        {
            get { return _cut2Angle2Saw; }
            set { _cut2Angle2Saw = value; OnPropertyChanged(nameof(Cut2Angle2Saw)); }
        }

        private string _stockCode;
        public string StockCode
        {
            get { return _stockCode; }
            set { _stockCode = value; OnPropertyChanged(nameof(StockCode)); }
        }

        private double _weldingSeamSpace;
        public double WeldingSeamSpace
        {
            get { return _weldingSeamSpace; }
            set { _weldingSeamSpace = value; OnPropertyChanged(nameof(WeldingSeamSpace)); }
        }

        private string _profileName;
        public string ProfileName
        {
            get { return _profileName; }
            set { _profileName = value; OnPropertyChanged(nameof(ProfileName)); }
        }

        private double _profileSizeX;
        public double ProfileSizeX
        {
            get { return _profileSizeX; }
            set { _profileSizeX = value; OnPropertyChanged(nameof(ProfileSizeX)); }
        }

        private double _profileSizeY;
        public double ProfileSizeY
        {
            get { return _profileSizeY; }
            set { _profileSizeY = value; OnPropertyChanged(nameof(ProfileSizeY)); }
        }

        private string _trolley;
        public string Trolley
        {
            get { return _trolley; }
            set { _trolley = value; OnPropertyChanged(nameof(Trolley)); }
        }

        private string _shelf;
        public string Shelf
        {
            get { return _shelf; }
            set { _shelf = value; OnPropertyChanged(nameof(Shelf)); }
        }

        private string _mountingPosition;
        public string MountingPosition
        {
            get { return _mountingPosition; }
            set { _mountingPosition = value; OnPropertyChanged(nameof(MountingPosition)); }
        }

        private string _steelCode;
        public string SteelCode
        {
            get { return _steelCode; }
            set { _steelCode = value; OnPropertyChanged(nameof(SteelCode)); }
        }

        private double _steelLength;
        public double SteelLength
        {
            get { return _steelLength; }
            set { _steelLength = value; OnPropertyChanged(nameof(SteelLength)); }
        }

        private string _glazingBeadCode;
        public string GlazingBeadCode
        {
            get { return _glazingBeadCode; }
            set { _glazingBeadCode = value; OnPropertyChanged(nameof(GlazingBeadCode)); }
        }

        private double _glazingBeadLength;
        public double GlazingBeadLength
        {
            get { return _glazingBeadLength; }
            set { _glazingBeadLength = value; OnPropertyChanged(nameof(GlazingBeadLength)); }
        }

        private string _productionBatchNumber;
        public string ProductionBatchNumber
        {
            get { return _productionBatchNumber; }
            set { _productionBatchNumber = value; OnPropertyChanged(nameof(ProductionBatchNumber)); }
        }

        private string _orderName;
        public string OrderName
        {
            get { return _orderName; }
            set { _orderName = value; OnPropertyChanged(nameof(OrderName)); }
        }

        private string _frameId;
        public string FrameId
        {
            get { return _frameId; }
            set { _frameId = value; OnPropertyChanged(nameof(FrameId)); }
        }

        private string _producerName;
        public string ProducerName
        {
            get { return _producerName; }
            set { _producerName = value; OnPropertyChanged(nameof(ProducerName)); }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; OnPropertyChanged(nameof(CustomerName)); }
        }

        private string _colorCode;
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; OnPropertyChanged(nameof(ColorCode)); }
        }

        private string _colorName;
        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; OnPropertyChanged(nameof(ColorName)); }
        }

        private string _operations;
        public string Operations
        {
            get { return _operations; }
            set { _operations = value; OnPropertyChanged(nameof(Operations)); }
        }

        private string _barcodeString;
        public string BarcodeString
        {
            get { return _barcodeString; }
            set { _barcodeString = value; OnPropertyChanged(nameof(BarcodeString)); }
        }

        private string _labelImagePath;
        public string LabelImagePath
        {
            get { return _labelImagePath; }
            set { _labelImagePath = value; OnPropertyChanged(nameof(LabelImagePath)); }
        }

        private string _productionDate;
        public string ProductionDate
        {
            get { return _productionDate; }
            set { _productionDate = value; OnPropertyChanged(nameof(ProductionDate)); }
        }

        private string _deliveryDate;
        public string DeliveryDate
        {
            get { return _deliveryDate; }
            set { _deliveryDate = value; OnPropertyChanged(nameof(DeliveryDate)); }
        }

        public static double Zero { get { return 0; } }

        private int _orginalId;
        public int OrginalId
        {
            get { return _orginalId; }
            set { _orginalId = value; OnPropertyChanged(nameof(OrginalId)); }
        }

        private double _frameWidth;
        public double FrameWidth
        {
            get { return _frameWidth; }
            set { _frameWidth = value; OnPropertyChanged(nameof(FrameWidth)); }
        }

        private double _frameHeight;
        public double FrameHeight
        {
            get { return _frameHeight; }
            set { _frameHeight = value; OnPropertyChanged(nameof(FrameHeight)); }
        }

        private double _windowWidth;
        public double WindowWidth
        {
            get { return _windowWidth; }
            set { _windowWidth = value; OnPropertyChanged(nameof(WindowWidth)); }
        }

        private double _windowHeight;
        public double WindowHeight
        {
            get { return _windowHeight; }
            set { _windowHeight = value; OnPropertyChanged(nameof(WindowHeight)); }
        }

        private int _profileIndex;
        public int ProfileIndex
        {
            get { return _profileIndex; }
            set { _profileIndex = value; OnPropertyChanged(nameof(ProfileIndex)); }
        }

        private string _wasteImage;
        public string WasteImage
        {
            get { return _wasteImage; }
            set { _wasteImage = value; OnPropertyChanged(nameof(WasteImage)); }
        }

        private double _clampPressure;
        public double ClampPressure
        {
            get { return _clampPressure; }
            set { _clampPressure = value; OnPropertyChanged(nameof(ClampPressure)); }
        }

        public double FrameWidthWithWeldingSeam
        {
            get { return FrameWidth + WeldingSeamSpace; }
        }

        public double FrameHeightWithWeldingSeam
        {
            get { return FrameHeight + WeldingSeamSpace; }
        }

        public string FrameWidth_Barcode
        {
            get { return Convert.ToDouble(FrameWidth).ToString("0.0").Replace(".", ""); }
        }

        public string FrameHeight_Barcode
        {
            get { return Convert.ToDouble(FrameHeight).ToString("0.0").Replace(".", ""); }
        }

        public string FrameWidthWithWeldingSeam_Barcode
        {
            get { return Convert.ToDouble(FrameWidthWithWeldingSeam).ToString("0.0").Replace(".", ""); }
        }

        public string FrameHeightWithWeldingSeam_Barcode
        {
            get { return Convert.ToDouble(FrameHeightWithWeldingSeam).ToString("0.0").Replace(".", ""); }
        }

        public string PieceLength_Barcode
        {
            get { return Convert.ToDouble(PieceLength).ToString("0.0").Replace(".", ""); }
        }

        public string SteelLength_Barcode
        {
            get { return Convert.ToDouble(SteelLength).ToString("0.0").Replace(".", ""); }
        }

        private string _custom_1;
        public string Custom_1
        {
            get { return _custom_1; }
            set { _custom_1 = value; OnPropertyChanged(nameof(Custom_1)); }
        }

        private string _custom_2;
        public string Custom_2
        {
            get { return _custom_2; }
            set { _custom_2 = value; OnPropertyChanged(nameof(Custom_2)); }
        }

        private string _custom_3;
        public string Custom_3
        {
            get { return _custom_3; }
            set { _custom_3 = value; OnPropertyChanged(nameof(Custom_3)); }
        }

        private string _custom_4;
        public string Custom_4
        {
            get { return _custom_4; }
            set { _custom_4 = value; OnPropertyChanged(nameof(Custom_4)); }
        }

        private string _custom_5;
        public string Custom_5
        {
            get { return _custom_5; }
            set { _custom_5 = value; OnPropertyChanged(nameof(Custom_5)); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }
    }
}
