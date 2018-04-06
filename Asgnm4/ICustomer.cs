using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgnm4
{
  public  interface ICustomer:IComparable<ICustomer>,ICloneable
    {
        //string Type { get; set; }
        uint Age { get; set; }
        double Size { get; set; }
        double PaddockSize { get; set; }
        string Name { get; set; }
        int Time { get; set; }
        void CreateDesign();
        void EstimateWork();
        void ArrangeWorkers();

    }
}
