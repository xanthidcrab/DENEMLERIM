using Barcode.INTERFACES;
using Barcode.UCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Barcode.Classes
{
    public class CRUD
    {
        public DataSet XmlDataset { get; set; }
        public DataTable BarcodeTable { get; set; }
        public DataTable TextTable { get; set; }
        public DataTable ImageTable { get; set; }
        public DataTable PaperTable { get; set; }

        public CRUD()
        {
            XmlDataset = new DataSet();
            BarcodeTable = new DataTable();
            TextTable = new DataTable();
            ImageTable = new DataTable();
            PaperTable = new DataTable();

            InitBarcode();
            InitText();
            InitImage();
            InitPaper();
        }

        private void InitPaper()
        {
            PaperTable.Columns.Add("ID", typeof(int));
            PaperTable.Columns.Add("ElementName", typeof(string));
            PaperTable.Columns.Add("Width", typeof(double));
            PaperTable.Columns.Add("Height", typeof(double));
            PaperTable.TableName = "PAPERTABLE";
            XmlDataset.Tables.Add(PaperTable);  
        }

        private void InitImage()
        {
            ImageTable.Columns.Add("ID", typeof(int));
            ImageTable.Columns.Add("ElementName", typeof(string));
            ImageTable.Columns.Add("Width", typeof(double));
            ImageTable.Columns.Add("Height", typeof(double));
            ImageTable.Columns.Add("ImagePath", typeof(string));
            ImageTable.TableName = "IMAGETABLE";
            XmlDataset.Tables.Add(ImageTable);
        }

        private void InitText()
        {
            TextTable.Columns.Add("ID", typeof(int));
            TextTable.Columns.Add("ElementName", typeof(string));
            TextTable.Columns.Add("FontFamily", typeof(string));
            TextTable.Columns.Add("FontSize", typeof(int));
            TextTable.Columns.Add("FontStyle", typeof(string));
            TextTable.Columns.Add("FontWeight", typeof(string));
            TextTable.TableName = "TEXTTABLE";
            TextTable.Columns.Add("Text", typeof(string));
            
           
            XmlDataset.Tables.Add(TextTable);
        }

        private void InitBarcode()
        {
            BarcodeTable.Columns.Add("ID", typeof(int));
            BarcodeTable.Columns.Add("ElementName", typeof(string));
            BarcodeTable.Columns.Add("BarcodeCode", typeof(string));
            BarcodeTable.Columns.Add("BarcodeType", typeof(string));
            BarcodeTable.Columns.Add("Seperator", typeof(int));
            BarcodeTable.TableName = "BARCODETABLE";
            XmlDataset.Tables.Add(BarcodeTable);

        }
        public void SaveXml(string name) 
        {
            XmlDataset.DataSetName = name;
            XmlDataset.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "PAPERS\\" + name + ".xml", XmlWriteMode.WriteSchema);
        }
        public void LoadDataSet(IData data)
        {
            switch (data.Type)
            {
                case 0:
                    Image img = (Image)data;
                    DataRow row = img.ConvertDataRow();
                    ImageTable.Rows.Add(row);
                    break;
                default:
                    break;
            }
        }
    }
}
