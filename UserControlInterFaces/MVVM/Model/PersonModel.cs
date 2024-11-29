using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlInterFaces.Interfaces;

namespace UserControlInterFaces.MVVM.Model
{
    public class PersonModel : IXmlable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public DataSet XmlDataSet { get; set; }
        public DataTable Xml { get; set; }
        public PersonModel() 
        {
        
            Birth = DateTime.Now;
            XmlDataSet = new DataSet(Name+Surname+Birth.Date);
            Xml = new DataTable("XMLTABLE");
            Xml.Columns.Add("Name", typeof(string));
            Xml.Columns.Add("Surname", typeof(string));
            Xml.Columns.Add("Birth", typeof(DateTime));

        }

        public void XmlPrint()
        {
            DataRow dataRow = Xml.NewRow();
            dataRow["Name"] = Name;
            dataRow["Surname"] = Surname;
            dataRow["Birth"] = Birth;

            Xml.Rows.Add(dataRow);
            XmlDataSet.Tables.Add(Xml);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";

            saveFileDialog.Title = Name + Surname + "Kaydet";
            saveFileDialog.ShowDialog();
            XmlDataSet.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
        }

        public void XmlRead()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.xml";
            openFileDialog.Title = "XML AÇ";
            openFileDialog.ShowDialog();

            if (Name != null || Name == "")
            {
                XmlDataSet.ReadXml(openFileDialog.FileName, XmlReadMode.ReadSchema);
            }
            DataTable dataTable = XmlDataSet.Tables[0];
            Name = dataTable.Rows[0]["Name"].ToString();
            Surname = dataTable.Rows[0]["Surname"].ToString();
            Birth = Convert.ToDateTime(dataTable.Rows[0]["Birth"]);
        }
    }
}
