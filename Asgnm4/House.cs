using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgnm4
{
    class House : Customer
    {
        public string Type {get { return "Regular house"; }}
        public override void CreateDesign()
        {
            if (size == 0 & paddockSize == 0)
            {
                Console.WriteLine("Wrong data");
            }
            else
            {
                Console.WriteLine("A design for your sun room was created");
            }
        }
        public override object Clone()
        {
            House clone = new House();
            clone.Name = Name;
            clone.Time = Time;
            clone.Age = Age;
            clone.Size = Size;
            clone.PaddockSize = PaddockSize;
            return clone;
        }
    }

}
