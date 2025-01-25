using Barcode.INTERFACES;
using Barcode.UCS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Barcode.Classes
{
    public class CRUD
    {
        public DataSet XmlDataset 
        { 
            
            get; 
            
            set; 
        }
        public DataTable BarcodeTable { get; set; }
        public DataTable TextTable { get; set; }
        public DataTable ImageTable { get; set; }
        public DataTable PaperTable { get; set; }
        public MainWindow MainWindow { get; set; }
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
            ImageTable.Columns.Add("Xpos", typeof(double));
            ImageTable.Columns.Add("Ypos", typeof(double));
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
            TextTable.Columns.Add("Xpos", typeof(double));
            TextTable.Columns.Add("Ypos", typeof(double));
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
            BarcodeTable.Columns.Add("Xpos", typeof(double));
            BarcodeTable.Columns.Add("Ypos", typeof(double));
            BarcodeTable.Columns.Add("Width", typeof(double));
            BarcodeTable.Columns.Add("Height", typeof(double));
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
                    DataRow row = ImageTable.NewRow();
                     row = img.ConvertDataRow();
                    XmlDataset.Tables["IMAGETABLE"].Rows.Add(row);
                    break;
                default:
                    break;
            }
        }
        public Paper XmlToPaper()
        {
            Paper paper = new Paper(this);
            paper.MainWindow = MainWindow;
            foreach (DataRow row in XmlDataset.Tables["PAPERTABLE"].Rows)
            {
                paper.ID = (int)row["ID"];
                paper.ElementName = row["ElementName"].ToString();
                paper.RealSize = new System.Windows.Size((double)row["Width"], (double)row["Height"]);
            }
            foreach (DataRow row in XmlDataset.Tables["IMAGETABLE"].Rows)
            {
                Image img = new Image();
                img.MainWindow = MainWindow;
                img.Paper = paper;
                img.ID = (int)row["ID"];
                img.ElementName = row["ElementName"].ToString();
                img.RealSize = new System.Windows.Size((double)row["Width"], (double)row["Height"]);
                img.RelsizeFirstDef();
                img.RealPosition = new System.Windows.Point((double)row["Xpos"], (double)row["Ypos"]);
                img.ImagePath = row["ImagePath"].ToString();
                paper.ElementList.Add(img);
            }
            foreach (DataRow row in XmlDataset.Tables["TEXTTABLE"].Rows)
            {
                Text txt = new Text();
                txt.ID = (int)row["ID"];
                txt.ElementName = row["ElementName"].ToString();
                txt.RealPosition = new System.Windows.Point((double)row["Xpos"], (double)row["Ypos"]);
                txt.FontStylese = row["FontStyle"].ToString();
                txt.FontWeightse = row["FontWeight"].ToString();
                txt.FontSizes = (double)row["FontSize"];
                txt.FontFamilys = row["FontFamily"].ToString();
                txt.Textss = row["Text"].ToString();
                txt.RealPosition = new System.Windows.Point((double)row["Xpos"], (double)row["Ypos"]);
                paper.ElementList.Add(txt);



             
            }
            foreach (DataRow row in XmlDataset.Tables["BARCODETABLE"].Rows)
            {
                Image img = new Image();
                img.ID = (int)row["ID"];
                img.ElementName = row["ElementName"].ToString();
                img.RealPosition = new System.Windows.Point((double)row["Xpos"], (double)row["Ypos"]);
                img.Size = new System.Windows.Size((double)row["Width"], (double)row["Height"]);
                img.ImagePath = row["ImagePath"].ToString();
                paper.ElementList.Add(img);
            }
            return paper;
        }
    }
}
