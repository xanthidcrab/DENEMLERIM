using System.Text.Json;
using System.Xml.Serialization;

public class DataModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
}

// IOutputAdapter arayüzü
public interface IOutputAdapter
{
    string GetOutput(DataModel data);
}

// JSON Adapter
public class JsonOutputAdapter : IOutputAdapter
{
    public string GetOutput(DataModel data)
    {
        return JsonSerializer.Serialize(data);
    }
}

// XML Adapter
public class XmlOutputAdapter : IOutputAdapter
{
    public string GetOutput(DataModel data)
    {
        var xmlSerializer = new XmlSerializer(typeof(DataModel));
        using (var stringWriter = new StringWriter())
        {
            xmlSerializer.Serialize(stringWriter, data);
            return stringWriter.ToString();
        }
    }
}

// Ana sınıf
public class DataProcessor
{
    private readonly IOutputAdapter _adapter;

    public DataProcessor(IOutputAdapter adapter)
    {
        _adapter = adapter;
    }

    public string Process(DataModel data)
    {
        return _adapter.GetOutput(data);
    }
}

// Kullanım
class Program
{
    static void Main(string[] args)
    {
        var data = new DataModel { Id = 1, Name = "Test Data", Value = 123.45 };

        // JSON formatında çıktı
        var jsonProcessor = new DataProcessor(new JsonOutputAdapter());
        Console.WriteLine("JSON Output:");
        Console.WriteLine(jsonProcessor.Process(data));

        // XML formatında çıktı
        var xmlProcessor = new DataProcessor(new XmlOutputAdapter());
        Console.WriteLine("\nXML Output:");
        Console.WriteLine(xmlProcessor.Process(data));
    }
}