using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlInterFaces.MVVM.Model
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }

        public PersonModel() 
        {
        
            Birth = DateTime.Now.Date;
        }
    }
}
