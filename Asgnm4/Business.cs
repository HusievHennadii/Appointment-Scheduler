using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgnm4
{
    class Business:Customer
    {
        public string Type { get { return "Business centre"; }}
        public override void CreateDesign()
        {
            if (size == 0 & paddockSize == 0)
            {
                Console.WriteLine("Wrong data");
            }
            else
            {
                Console.WriteLine("A design for your customer loby was created");
            }
        }
        public override object Clone()
        {
            Business clone = new Business();
            clone.Name = Name;
            clone.Time = Time;
            clone.Age = Age;
            clone.Size = Size;
            clone.PaddockSize = PaddockSize;
            return clone;
        }
    }
}
