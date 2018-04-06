using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgnm4
{ 
   public abstract class Customer:ICustomer
    {
        protected uint age;
        protected double size;
        protected double paddockSize;
        protected int time;
        protected string name;
        public Customer()
        {
            Age = 0;
            Size = 1;
            PaddockSize = 0;
        }
        public Customer(uint age, double size, double paddockSize)
        {
            this.age = age;
            this.size = size;
            this.paddockSize = paddockSize;
        }
        //public string Type { get; set; }
        public uint Age { get { return age; } set { age = value; } }
        public double Size { get { return size; } set { size = value; } }
        public double PaddockSize { get { return paddockSize; } set { paddockSize = value; } }
        public int Time { get { return time; } set { time = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Time_str { get { return time.ToString() + ":00"; }}
        public abstract void CreateDesign();
        public void EstimateWork()
        {
            if (size == 0 )
                Console.WriteLine("Problem with your house data, work can not be calculated");
            else
            {
                Console.WriteLine("Work calculation was runned succesfully");
            }
        }
        public void ArrangeWorkers()
        {
            if (size == 0 )
            {
                Console.WriteLine("Problem with your house data, workers can not be assigned");
            }
            else
            {
                Console.WriteLine("For this project workers were succesfully assigned");
            }
        }

        public int CompareTo(ICustomer other)
        {
            return this.Time.CompareTo(other.Time);
        }

        public abstract object Clone();
    }
}
