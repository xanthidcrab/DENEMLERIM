using ClassMusteri.Interfaces;

namespace ClassMusteri.Models
{

    public class Musteri : IXmlConverters, ISqlLites
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; }
        public List<Machine> Machines { get; set; }

        public void ReadSqlLite()
        {
            throw new NotImplementedException();
        }

        public void ReadXml()
        {
            throw new NotImplementedException();
        }

        public void WriteSqLite()
        {
            throw new NotImplementedException();
        }

        public void WriteXml()
        {
            throw new NotImplementedException();
        }
    }

}