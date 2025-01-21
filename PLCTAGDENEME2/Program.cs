
using PlcTag;
namespace PLCTAGDENEME2
{
    public class Test12
    {
        public int AA1 { get; set; }
        public int AA2 { get; set; }
        public int AA3 { get; set; }
        public int AA4 { get; set; }
        public int AA5 { get; set; }
        public int AA6 { get; set; }
        public int AA7 { get; set; }
        public int AA8 { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //initialize controller
            using (var controller = new PlcController("10.155.128.192", "1, 0", CPUType.LGX))
            {
                //ping controller
                Console.Out.WriteLine("Ping " + controller.Ping(true));

                //create group tag
                var grp = controller.CreateGroup();

                //add tag
                var tag = grp.CreateTagType<string[]>("Track",  .STRING, 300);
                tag.Changed += TagChanged;
                var value = tag.Read();

                //add tag from Class
                var tag1 = grp.CreateTagType<Test12>("Test");
                tag.Changed += TagChanged;

                var tag2 = grp.CreateTagFloat32("Fl32");

                grp.Changed += GroupChanged;
                grp.Read();

            }
        }
        private static void PrintChange(string @event, ResultOperation result)
        {
            Console.Out.WriteLine($"{@event} {result.Timestamp} Changed: {result.Tag.Name}");
        }

        static void TagChanged(ResultOperation result)
        {
            PrintChange("TagChanged", result);
        }

        static void GroupChanged(IEnumerable<ResultOperation> results)
        {
            foreach (var result in results) PrintChange("GroupTagChanged", result);
        }
    }
}
