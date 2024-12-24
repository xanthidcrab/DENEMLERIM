using CsvProject.CLASSES.ABSTRACT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CsvProject.CLASSES
{
    [XmlRoot("OPERATIONDATATABLE")]
    public class OPERATIONSDATATABLE : BaseViewModel
    {
        private int? id = 0;
        private int? operationCode = 0;
        private int? operationType = 0;
        private int? originalOperationType = 0;
        private int? toolNm = 0;
        private double? xPos = 0.0;
        private double? yPos = 0.0;
        private double? zPos = 0.0;
        private double? approachDist = 0.0;
        private double? depth = 0.0;
        private double? a = 0.0;
        private double? b = 0.0;
        private double? c = 0.0;
        private double? d = 0.0;
        private double? e = 0.0;
        private double? xOffset = 0.0;
        private double? yOffset = 0.0;
        private double? zOffset = 0.0;
        private double? idleSpd = 0.0;
        private double? penetrateSpd = 0.0;
        private double? millFeedSpd = 0.0;
        private double? circleSpd = 0.0;
        private double? jumpSpd = 0.0;
        private double? rpm = 0.0;
        private double? hierarchy = 0.0;
        private string operationName = string.Empty;
        private int? opGroup = 0;
        private int? pieceId = 0;
        private double? angle = 0.0;
        private double? r1 = 0.0;
        private double? r2 = 0.0;
        private double? r3 = 0.0;
        private double? r4 = 0.0;
        private double? r5 = 0.0;
        private double? r6 = 0.0;
        private int? cw = 0;
        private string depthTable = string.Empty;
        private int? priority = 0;
        private int? groupNm = 0;
        private int? jumpStep = 0;
        private double? drawStroke = 0.0;
        private string ownerProfileCode = string.Empty;
        private int? depthLevelNumber = 0;
        private int? zeroDepthLevelTool = 0;
        private string operationsDataTableId = string.Empty;
        private int? localId = 0;

        [XmlElement("ID")]
        public int? ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        [XmlElement("OPERATIONCODE")]
        public int? OPERATIONCODE
        {
            get => operationCode;
            set
            {
                operationCode = value;
                OnPropertyChanged(nameof(OPERATIONCODE));
            }
        }

        [XmlElement("OPERATIONTYPE")]
        public int? OPERATIONTYPE
        {
            get => operationType;
            set
            {
                operationType = value;
                OnPropertyChanged(nameof(OPERATIONTYPE));
            }
        }

        [XmlElement("ORIGINALOPERATIONTYPE")]
        public int? ORIGINALOPERATIONTYPE
        {
            get => originalOperationType;
            set
            {
                originalOperationType = value;
                OnPropertyChanged(nameof(ORIGINALOPERATIONTYPE));
            }
        }

        [XmlElement("TOOLNM")]
        public int? TOOLNM
        {
            get => toolNm;
            set
            {
                toolNm = value;
                OnPropertyChanged(nameof(TOOLNM));
            }
        }

        [XmlElement("XPOS")]
        public double? XPOS
        {
            get => xPos;
            set
            {
                xPos = value;
                OnPropertyChanged(nameof(XPOS));
            }
        }

        [XmlElement("YPOS")]
        public double? YPOS
        {
            get => yPos;
            set
            {
                yPos = value;
                OnPropertyChanged(nameof(YPOS));
            }
        }

        [XmlElement("ZPOS")]
        public double? ZPOS
        {
            get => zPos;
            set
            {
                zPos = value;
                OnPropertyChanged(nameof(ZPOS));
            }
        }

        [XmlElement("APPROACHDIST")]
        public double? APPROACHDIST
        {
            get => approachDist;
            set
            {
                approachDist = value;
                OnPropertyChanged(nameof(APPROACHDIST));
            }
        }

        [XmlElement("DEPTH")]
        public double? DEPTH
        {
            get => depth;
            set
            {
                depth = value;
                OnPropertyChanged(nameof(DEPTH));
            }
        }

        [XmlElement("A")]
        public double? A
        {
            get => a;
            set
            {
                a = value;
                OnPropertyChanged(nameof(A));
            }
        }

        [XmlElement("B")]
        public double? B
        {
            get => b;
            set
            {
                b = value;
                OnPropertyChanged(nameof(B));
            }
        }

        [XmlElement("C")]
        public double? C
        {
            get => c;
            set
            {
                c = value;
                OnPropertyChanged(nameof(C));
            }
        }

        [XmlElement("D")]
        public double? D
        {
            get => d;
            set
            {
                d = value;
                OnPropertyChanged(nameof(D));
            }
        }

        [XmlElement("E")]
        public double? E
        {
            get => e;
            set
            {
                e = value;
                OnPropertyChanged(nameof(E));
            }
        }

        [XmlElement("XOFFSET")]
        public double? XOFFSET
        {
            get => xOffset;
            set
            {
                xOffset = value;
                OnPropertyChanged(nameof(XOFFSET));
            }
        }

        [XmlElement("YOFFSET")]
        public double? YOFFSET
        {
            get => yOffset;
            set
            {
                yOffset = value;
                OnPropertyChanged(nameof(YOFFSET));
            }
        }

        [XmlElement("ZOFFSET")]
        public double? ZOFFSET
        {
            get => zOffset;
            set
            {
                zOffset = value;
                OnPropertyChanged(nameof(ZOFFSET));
            }
        }

        [XmlElement("IDLESPD")]
        public double? IDLESPD
        {
            get => idleSpd;
            set
            {
                idleSpd = value;
                OnPropertyChanged(nameof(IDLESPD));
            }
        }

        [XmlElement("PENETRATESPD")]
        public double? PENETRATESPD
        {
            get => penetrateSpd;
            set
            {
                penetrateSpd = value;
                OnPropertyChanged(nameof(PENETRATESPD));
            }
        }

        [XmlElement("MILLFEEDSPD")]
        public double? MILLFEEDSPD
        {
            get => millFeedSpd;
            set
            {
                millFeedSpd = value;
                OnPropertyChanged(nameof(MILLFEEDSPD));
            }
        }

        [XmlElement("CIRCLESPD")]
        public double? CIRCLESPD
        {
            get => circleSpd;
            set
            {
                circleSpd = value;
                OnPropertyChanged(nameof(CIRCLESPD));
            }
        }

        [XmlElement("JUMPSPD")]
        public double? JUMPSPD
        {
            get => jumpSpd;
            set
            {
                jumpSpd = value;
                OnPropertyChanged(nameof(JUMPSPD));
            }
        }

        [XmlElement("RPM")]
        public double? RPM
        {
            get => rpm;
            set
            {
                rpm = value;
                OnPropertyChanged(nameof(RPM));
            }
        }

        [XmlElement("HIERARCHY")]
        public double? HIERARCHY
        {
            get => hierarchy;
            set
            {
                hierarchy = value;
                OnPropertyChanged(nameof(HIERARCHY));
            }
        }

        [XmlElement("OPERATIONNAME")]
        public string OPERATIONNAME
        {
            get => operationName;
            set
            {
                operationName = value;
                OnPropertyChanged(nameof(OPERATIONNAME));
            }
        }

        [XmlElement("OPGROUP")]
        public int? OPGROUP
        {
            get => opGroup;
            set
            {
                opGroup = value;
                OnPropertyChanged(nameof(OPGROUP));
            }
        }

        [XmlElement("PIECEID")]
        public int? PIECEID
        {
            get => pieceId;
            set
            {
                pieceId = value;
                OnPropertyChanged(nameof(PIECEID));
            }
        }

        [XmlElement("ANGLE")]
        public double? ANGLE
        {
            get => angle;
            set
            {
                angle = value;
                OnPropertyChanged(nameof(ANGLE));
            }
        }

        [XmlElement("R1")]
        public double? R1
        {
            get => r1;
            set
            {
                r1 = value;
                OnPropertyChanged(nameof(R1));
            }
        }

        [XmlElement("R2")]
        public double? R2
        {
            get => r2;
            set
            {
                r2 = value;
                OnPropertyChanged(nameof(R2));
            }
        }

        [XmlElement("R3")]
        public double? R3
        {
            get => r3;
            set
            {
                r3 = value;
                OnPropertyChanged(nameof(R3));
            }
        }

        [XmlElement("R4")]
        public double? R4
        {
            get => r4;
            set
            {
                r4 = value;
                OnPropertyChanged(nameof(R4));
            }
        }

        [XmlElement("R5")]
        public double? R5
        {
            get => r5;
            set
            {
                r5 = value;
                OnPropertyChanged(nameof(R5));
            }
        }

        [XmlElement("R6")]
        public double? R6
        {
            get => r6;
            set
            {
                r6 = value;
                OnPropertyChanged(nameof(R6));
            }
        }

        [XmlElement("CW")]
        public int? CW
        {
            get => cw;
            set
            {
                cw = value;
                OnPropertyChanged(nameof(CW));
            }
        }

        [XmlElement("DEPTHTABLE")]
        public string DEPTHTABLE
        {
            get => depthTable;
            set
            {
                depthTable = value;
                OnPropertyChanged(nameof(DEPTHTABLE));
            }
        }

        [XmlElement("PRIORITY")]
        public int? PRIORITY
        {
            get => priority;
            set
            {
                priority = value;
                OnPropertyChanged(nameof(PRIORITY));
            }
        }

        [XmlElement("GROUPNM")]
        public int? GROUPNM
        {
            get => groupNm;
            set
            {
                groupNm = value;
                OnPropertyChanged(nameof(GROUPNM));
            }
        }

        [XmlElement("JUMPSTEP")]
        public int? JUMPSTEP
        {
            get => jumpStep;
            set
            {
                jumpStep = value;
                OnPropertyChanged(nameof(JUMPSTEP));
            }
        }

        [XmlElement("DRAWSTROKE")]
        public double? DRAWSTROKE
        {
            get => drawStroke;
            set
            {
                drawStroke = value;
                OnPropertyChanged(nameof(DRAWSTROKE));
            }
        }

        [XmlElement("OWNERPROFILECODE")]
        public string OWNERPROFILECODE
        {
            get => ownerProfileCode;
            set
            {
                ownerProfileCode = value;
                OnPropertyChanged(nameof(OWNERPROFILECODE));
            }
        }

        [XmlElement("DEPTHLEVELNUMBER")]
        public int? DEPTHLEVELNUMBER
        {
            get => depthLevelNumber;
            set
            {
                depthLevelNumber = value;
                OnPropertyChanged(nameof(DEPTHLEVELNUMBER));
            }
        }

        [XmlElement("ZERODEPTHLEVELTOOL")]
        public int? ZERODEPTHLEVELTOOL
        {
            get => zeroDepthLevelTool;
            set
            {
                zeroDepthLevelTool = value;
                OnPropertyChanged(nameof(ZERODEPTHLEVELTOOL));
            }
        }

        [XmlElement("OPERATIONSDATATABLE_Id")]
        public string OPERATIONSDATATABLE_Id
        {
            get => operationsDataTableId;
            set
            {
                operationsDataTableId = value;
                OnPropertyChanged(nameof(OPERATIONSDATATABLE_Id));
            }
        }

        [XmlElement("LOCALID")]
        public int? LOCALID
        {
            get => localId;
            set
            {
                localId = value;
                OnPropertyChanged(nameof(LOCALID));
            }
        }
    }
}
