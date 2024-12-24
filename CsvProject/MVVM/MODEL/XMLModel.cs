using CsvProject.CLASSES.ABSTRACT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CsvProject.CLASSES
{
    [XmlRoot("XMLModel")]
    public class XMLModel :BaseViewModel, IWriteXml
    {
        [XmlElement("PROFILESDATATABLE")]
        private ProfileModel _profile;
        [XmlElement("PROFILESDATATABLE")]
        public ProfileModel Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged(nameof(Profile));
            }
        }

        private List<OPERATIONSDATATABLE> _operations;
        [XmlArray("OPERATIONSDATATABLE")]
        public List<OPERATIONSDATATABLE> Operations
        {
            get { return _operations; }
            set
            {
                _operations = value;
                OnPropertyChanged(nameof(Operations));
            }
        }

        public XMLModel()
        {
            Profile = new ProfileModel();
            Operations = new List<OPERATIONSDATATABLE>();
        }

        public void WriteXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLModel));
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
            {
                serializer.Serialize(sw, this);
            }
        }
    }
}
