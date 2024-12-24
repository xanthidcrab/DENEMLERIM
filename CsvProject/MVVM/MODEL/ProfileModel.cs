using CsvProject.CLASSES.ABSTRACT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CsvProject.CLASSES
{
    [XmlRoot("PROFILESDATATABLE")]
    public class ProfileModel : BaseViewModel
    {
        private string stockCode;
        private string profileName;
        private string profileBrand;
        private double profileBeadChannelX;
        private double profileBeadChannelY;
        private double profilSizeX;
        private double profilSizeY;
        private double liftPointX;
        private double liftPointY;
        private double supportPointX;
        private double supportPointY;
        private double gripperCatchX;
        private double gripperCatchY;
        private double gripperAngle;
        private string profileType;
        private string rawMaterial;
        private string gasketClamp;
        private string option1;
        private string option2;
        private string option3;
        private string option4;
        private string option5;
        private double heightOffset;
        private double widthOffset;
        private int saw;
        private int cutSpeed;
        private int beltReverse;
        private double gripperDescend;
        private string optionParam1;
        private string optionParam2;
        private string optionParam3;
        private string optionParam4;
        private string optionParam5;
        private string optionParam6;
        private string optionParam7;
        private string optionParam8;
        private string optionParam9;
        private string optionParam10;
        private double vClampPosBackX;
        private double vClampPosBackY;
        private double vClampPosFrontX;
        private double vClampPosFrontY;
        private double hClampPosX;
        private double hClampPosY;
        private double verticalAlMeasureY;
        private double horizontalMeasureX;
        private string operations;
        private int id;

        [XmlElement("STOCKCODE")]
        public string STOCKCODE
        {
            get => stockCode;
            set
            {
                stockCode = value;
                OnPropertyChanged(nameof(STOCKCODE));
            }
        }

        [XmlElement("PROFILENAME")]
        public string PROFILENAME
        {
            get => profileName;
            set
            {
                profileName = value;
                OnPropertyChanged(nameof(PROFILENAME));
            }
        }

        [XmlElement("PROFILEBRAND")]
        public string PROFILEBRAND
        {
            get => profileBrand;
            set
            {
                profileBrand = value;
                OnPropertyChanged(nameof(PROFILEBRAND));
            }
        }

        [XmlElement("PROFILEBEADCHANNELX")]
        public double PROFILEBEADCHANNELX
        {
            get => profileBeadChannelX;
            set
            {
                profileBeadChannelX = value;
                OnPropertyChanged(nameof(PROFILEBEADCHANNELX));
            }
        }

        [XmlElement("PROFILEBEADCHANNELY")]
        public double PROFILEBEADCHANNELY
        {
            get => profileBeadChannelY;
            set
            {
                profileBeadChannelY = value;
                OnPropertyChanged(nameof(PROFILEBEADCHANNELY));
            }
        }

        [XmlElement("PROFILSIZEX")]
        public double PROFILSIZEX
        {
            get => profilSizeX;
            set
            {
                profilSizeX = value;
                OnPropertyChanged(nameof(PROFILSIZEX));
            }
        }

        [XmlElement("PROFILSIZEY")]
        public double PROFILSIZEY
        {
            get => profilSizeY;
            set
            {
                profilSizeY = value;
                OnPropertyChanged(nameof(PROFILSIZEY));
            }
        }

        [XmlElement("LIFTPOINTX")]
        public double LIFTPOINTX
        {
            get => liftPointX;
            set
            {
                liftPointX = value;
                OnPropertyChanged(nameof(LIFTPOINTX));
            }
        }

        [XmlElement("LIFTPOINTY")]
        public double LIFTPOINTY
        {
            get => liftPointY;
            set
            {
                liftPointY = value;
                OnPropertyChanged(nameof(LIFTPOINTY));
            }
        }

        [XmlElement("SUPPORTPOINTX")]
        public double SUPPORTPOINTX
        {
            get => supportPointX;
            set
            {
                supportPointX = value;
                OnPropertyChanged(nameof(SUPPORTPOINTX));
            }
        }

        [XmlElement("SUPPORTPOINTY")]
        public double SUPPORTPOINTY
        {
            get => supportPointY;
            set
            {
                supportPointY = value;
                OnPropertyChanged(nameof(SUPPORTPOINTY));
            }
        }

        [XmlElement("GRIPPERCATCHX")]
        public double GRIPPERCATCHX
        {
            get => gripperCatchX;
            set
            {
                gripperCatchX = value;
                OnPropertyChanged(nameof(GRIPPERCATCHX));
            }
        }

        [XmlElement("GRIPPERCATCHY")]
        public double GRIPPERCATCHY
        {
            get => gripperCatchY;
            set
            {
                gripperCatchY = value;
                OnPropertyChanged(nameof(GRIPPERCATCHY));
            }
        }

        [XmlElement("GRIPPERANGLE")]
        public double GRIPPERANGLE
        {
            get => gripperAngle;
            set
            {
                gripperAngle = value;
                OnPropertyChanged(nameof(GRIPPERANGLE));
            }
        }

        [XmlElement("PROFILETYPE")]
        public string PROFILETYPE
        {
            get => profileType;
            set
            {
                profileType = value;
                OnPropertyChanged(nameof(PROFILETYPE));
            }
        }

        [XmlElement("RAWMATERIAL")]
        public string RAWMATERIAL
        {
            get => rawMaterial;
            set
            {
                rawMaterial = value;
                OnPropertyChanged(nameof(RAWMATERIAL));
            }
        }

        [XmlElement("GASKETCLAMP")]
        public string GASKETCLAMP
        {
            get => gasketClamp;
            set
            {
                gasketClamp = value;
                OnPropertyChanged(nameof(GASKETCLAMP));
            }
        }

        [XmlElement("OPTION1")]
        public string OPTION1
        {
            get => option1;
            set
            {
                option1 = value;
                OnPropertyChanged(nameof(OPTION1));
            }
        }

        [XmlElement("OPTION2")]
        public string OPTION2
        {
            get => option2;
            set
            {
                option2 = value;
                OnPropertyChanged(nameof(OPTION2));
            }
        }

        [XmlElement("OPTION3")]
        public string OPTION3
        {
            get => option3;
            set
            {
                option3 = value;
                OnPropertyChanged(nameof(OPTION3));
            }
        }

        [XmlElement("OPTION4")]
        public string OPTION4
        {
            get => option4;
            set
            {
                option4 = value;
                OnPropertyChanged(nameof(OPTION4));
            }
        }

        [XmlElement("OPTION5")]
        public string OPTION5
        {
            get => option5;
            set
            {
                option5 = value;
                OnPropertyChanged(nameof(OPTION5));
            }
        }

        [XmlElement("HEIGHTOFFSET")]
        public double HEIGHTOFFSET
        {
            get => heightOffset;
            set
            {
                heightOffset = value;
                OnPropertyChanged(nameof(HEIGHTOFFSET));
            }
        }

        [XmlElement("WIDTHOFFSET")]
        public double WIDTHOFFSET
        {
            get => widthOffset;
            set
            {
                widthOffset = value;
                OnPropertyChanged(nameof(WIDTHOFFSET));
            }
        }

        [XmlElement("SAW")]
        public int SAW
        {
            get => saw;
            set
            {
                saw = value;
                OnPropertyChanged(nameof(SAW));
            }
        }

        [XmlElement("CUTSPEED")]
        public int CUTSPEED
        {
            get => cutSpeed;
            set
            {
                cutSpeed = value;
                OnPropertyChanged(nameof(CUTSPEED));
            }
        }

        [XmlElement("BELTREVERSE")]
        public int BELTREVERSE
        {
            get => beltReverse;
            set
            {
                beltReverse = value;
                OnPropertyChanged(nameof(BELTREVERSE));
            }
        }

        [XmlElement("GRIPPERDESCEND")]
        public double GRIPPERDESCEND
        {
            get => gripperDescend;
            set
            {
                gripperDescend = value;
                OnPropertyChanged(nameof(GRIPPERDESCEND));
            }
        }

        [XmlElement("OPTIONPARAM1")]
        public string OPTIONPARAM1
        {
            get => optionParam1;
            set
            {
                optionParam1 = value;
                OnPropertyChanged(nameof(OPTIONPARAM1));
            }
        }

        [XmlElement("OPTIONPARAM2")]
        public string OPTIONPARAM2
        {
            get => optionParam2;
            set
            {
                optionParam2 = value;
                OnPropertyChanged(nameof(OPTIONPARAM2));
            }
        }

        [XmlElement("OPTIONPARAM3")]
        public string OPTIONPARAM3
        {
            get => optionParam3;
            set
            {
                optionParam3 = value;
                OnPropertyChanged(nameof(OPTIONPARAM3));
            }
        }

        [XmlElement("OPTIONPARAM4")]
        public string OPTIONPARAM4
        {
            get => optionParam4;
            set
            {
                optionParam4 = value;
                OnPropertyChanged(nameof(OPTIONPARAM4));
            }
        }

        [XmlElement("OPTIONPARAM5")]
        public string OPTIONPARAM5
        {
            get => optionParam5;
            set
            {
                optionParam5 = value;
                OnPropertyChanged(nameof(OPTIONPARAM5));
            }
        }

        [XmlElement("OPTIONPARAM6")]
        public string OPTIONPARAM6
        {
            get => optionParam6;
            set
            {
                optionParam6 = value;
                OnPropertyChanged(nameof(OPTIONPARAM6));
            }
        }

        [XmlElement("OPTIONPARAM7")]
        public string OPTIONPARAM7
        {
            get => optionParam7;
            set
            {
                optionParam7 = value;
                OnPropertyChanged(nameof(OPTIONPARAM7));
            }
        }

        [XmlElement("OPTIONPARAM8")]
        public string OPTIONPARAM8
        {
            get => optionParam8;
            set
            {
                optionParam8 = value;
                OnPropertyChanged(nameof(OPTIONPARAM8));
            }
        }

        [XmlElement("OPTIONPARAM9")]
        public string OPTIONPARAM9
        {
            get => optionParam9;
            set
            {
                optionParam9 = value;
                OnPropertyChanged(nameof(OPTIONPARAM9));
            }
        }

        [XmlElement("OPTIONPARAM10")]
        public string OPTIONPARAM10
        {
            get => optionParam10;
            set
            {
                optionParam10 = value;
                OnPropertyChanged(nameof(OPTIONPARAM10));
            }
        }

        [XmlElement("VCLAMPPOS_BACK_X")]
        public double VCLAMPPOS_BACK_X
        {
            get => vClampPosBackX;
            set
            {
                vClampPosBackX = value;
                OnPropertyChanged(nameof(VCLAMPPOS_BACK_X));
            }
        }

        [XmlElement("VCLAMPPOS_BACK_Y")]
        public double VCLAMPPOS_BACK_Y
        {
            get => vClampPosBackY;
            set
            {
                vClampPosBackY = value;
                OnPropertyChanged(nameof(VCLAMPPOS_BACK_Y));
            }
        }

        [XmlElement("VCLAMPPOS_FRONT_X")]
        public double VCLAMPPOS_FRONT_X
        {
            get => vClampPosFrontX;
            set
            {
                vClampPosFrontX = value;
                OnPropertyChanged(nameof(VCLAMPPOS_FRONT_X));
            }
        }

        [XmlElement("VCLAMPPOS_FRONT_Y")]
        public double VCLAMPPOS_FRONT_Y
        {
            get => vClampPosFrontY;
            set
            {
                vClampPosFrontY = value;
                OnPropertyChanged(nameof(VCLAMPPOS_FRONT_Y));
            }
        }

        [XmlElement("HCLAMPPOS_X")]
        public double HCLAMPPOS_X
        {
            get => hClampPosX;
            set
            {
                hClampPosX = value;
                OnPropertyChanged(nameof(HCLAMPPOS_X));
            }
        }

        [XmlElement("HCLAMPPOS_Y")]
        public double HCLAMPPOS_Y
        {
            get => hClampPosY;
            set
            {
                hClampPosY = value;
                OnPropertyChanged(nameof(HCLAMPPOS_Y));
            }
        }

        [XmlElement("VERTICALALMEASUREY")]
        public double VERTICALALMEASUREY
        {
            get => verticalAlMeasureY;
            set
            {
                verticalAlMeasureY = value;
                OnPropertyChanged(nameof(VERTICALALMEASUREY));
            }
        }

        [XmlElement("HORIZONTALMEASUREX")]
        public double HORIZONTALMEASUREX
        {
            get => horizontalMeasureX;
            set
            {
                horizontalMeasureX = value;
                OnPropertyChanged(nameof(HORIZONTALMEASUREX));
            }
        }

        [XmlElement("OPERATIONS")]
        public string OPERATIONS
        {
            get => operations;
            set
            {
                operations = value;
                OnPropertyChanged(nameof(OPERATIONS));
            }
        }

        [XmlElement("ID")]
        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
    }
}
