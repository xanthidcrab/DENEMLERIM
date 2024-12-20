using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace CsvDeneme.MVVM.Model
{
    public class CsvModel : ObservableObject
    {
        private int ıD;
        private int kSN;
        private int bLEN;
        private int kTN;
        private double pLEN;
        private int l;
        private int r;
        private int pKODU;
        private string pADI;
        private double gENISLIK;
        private double yUKSEKLIK;
        private string aRABA;
        private string rAF;
        private string kONUM;
        private string dSKOD;
        private double? dSLENGHT;
        private string uRETIMNO;
        private string tEKLIFNO;
        private string pOZ;
        private string bAYI;
        private string mUSTERI;
        private string rENKK;
        private string rENKA;
        private double? pANGENIS;
        private double? pENYUKSEK;
        private string mAKRO;
        private string bARKOD;
        private string rESIM;
        private string wASTE;
        private string cUSTOM1;
        private string cUSTOM2;
        private string cUSTOM3;
        private string cUSTOM4;
        private string cUSTOM5;
        [Name(name: "id")]
        public int ID { get => ıD; set { ıD = value; OnpropertyChange(nameof(ID)); } }

        [Name(name: "ksn")]
        public int KSN { get => kSN; set { kSN = value; OnpropertyChange(nameof(KSN)); } }

        [Name(name: "blen")]
        public int BLEN { get => bLEN; set { bLEN = value; OnpropertyChange(nameof(BLEN)); } }

        [Name(name: "ktn")]
        public int KTN { get => kTN; set { kTN = value; OnpropertyChange(nameof(KTN)); } }

        [Name(name: "plen")]
        public double PLEN { get => pLEN; set { pLEN = value; OnpropertyChange(nameof(PLEN)); } }

        [Name(name: "l")]
        public int L { get => l; set { l = value; OnpropertyChange(nameof(L)); } }

        [Name(name: "r")]
        public int R { get => r; set { r = value; OnpropertyChange(nameof(R)); } }

        [Name(name: "pkodu")]
        public int PKODU { get => pKODU; set { pKODU = value; OnpropertyChange(nameof(PKODU)); } }

        [Name(name: "padi")]
        public string PADI { get => pADI; set { pADI = value; OnpropertyChange(nameof(PADI)); } }

        [Name(name: "genislik")]
        public double GENISLIK { get => gENISLIK; set { gENISLIK = value; OnpropertyChange(nameof(GENISLIK)); } }

        [Name(name: "yukseklik")]
        public double YUKSEKLIK { get => yUKSEKLIK; set { yUKSEKLIK = value; OnpropertyChange(nameof(YUKSEKLIK)); } }

        [Name(name: "araba")]
        public string ARABA { get => aRABA; set { aRABA = value; OnpropertyChange(nameof(ARABA)); } }

        [Name(name: "raf")]
        public string RAF { get => rAF; set { rAF = value; OnpropertyChange(nameof(RAF)); } }

        [Name(name: "konum")]
        public string KONUM { get => kONUM; set { kONUM = value; OnpropertyChange(nameof(KONUM)); } }

        [Name(name: "dskod")]
        public string DSKOD { get => dSKOD; set { dSKOD = value; OnpropertyChange(nameof(DSKOD)); } }

        [Name(name: "dslenght")]
        public double? DSLENGHT { get => dSLENGHT; set { dSLENGHT = value; OnpropertyChange(nameof(DSLENGHT)); } }

        [Name(name: "uretimno")]
        public string URETIMNO { get => uRETIMNO; set { uRETIMNO = value; OnpropertyChange(nameof(URETIMNO)); } }

        [Name(name: "teklifno")]
        public string TEKLIFNO { get => tEKLIFNO; set { tEKLIFNO = value; OnpropertyChange(nameof(TEKLIFNO)); } }

        [Name(name: "poz")]
        public string POZ { get => pOZ; set { pOZ = value; OnpropertyChange(nameof(POZ)); } }

        [Name(name: "bayi")]
        public string BAYI { get => bAYI; set { bAYI = value; OnpropertyChange(nameof(BAYI)); } }

        [Name(name: "musteri")]
        public string MUSTERI { get => mUSTERI; set { mUSTERI = value; OnpropertyChange(nameof(MUSTERI)); } }

        [Name(name: "renkk")]
        public string RENKK { get => rENKK; set { rENKK = value; OnpropertyChange(nameof(RENKK)); } }

        [Name(name: "renka")]
        public string RENKA { get => rENKA; set { rENKA = value; OnpropertyChange(nameof(RENKA)); } }

        [Name(name: "pangeniş")]
        public double? PANGENIS { get => pANGENIS; set { pANGENIS = value; OnpropertyChange(nameof(PANGENIS)); } }

        [Name(name: "penyüksek")]
        public double? PENYUKSEK { get => pENYUKSEK; set { pENYUKSEK = value; OnpropertyChange(nameof(PENYUKSEK)); } }

        [Name(name: "makro")]
        public string MAKRO { get => mAKRO; set { mAKRO = value; OnpropertyChange(nameof(MAKRO)); } }

        [Name(name: "barkod")]
        public string BARKOD { get => bARKOD; set { bARKOD = value; OnpropertyChange(nameof(BARKOD)); } }

        [Name(name: "resim")]
        public string RESIM { get => rESIM; set { rESIM = value; OnpropertyChange(nameof(RESIM)); } }

        [Name(name: "waste")]
        public string WASTE { get => wASTE; set { wASTE = value; OnpropertyChange(nameof(WASTE)); } }

        [Name(name: "custom1")]
        public string CUSTOM1 { get => cUSTOM1; set { cUSTOM1 = value; OnpropertyChange(nameof(CUSTOM1)); } }

        [Name(name: "custom2")]
        public string CUSTOM2 { get => cUSTOM2; set { cUSTOM2 = value; OnpropertyChange(nameof(CUSTOM2)); } }

        [Name(name: "custom3")]
        public string CUSTOM3 { get => cUSTOM3; set { cUSTOM3 = value; OnpropertyChange(nameof(CUSTOM3)); } }

        [Name(name: "custom4")]
        public string CUSTOM4 { get => cUSTOM4; set { cUSTOM4 = value; OnpropertyChange(nameof(CUSTOM4)); } }

        [Name(name: "custom5")]
        public string CUSTOM5 { get => cUSTOM5; set { cUSTOM5 = value; OnpropertyChange(nameof(CUSTOM5)); } }





    }
}
