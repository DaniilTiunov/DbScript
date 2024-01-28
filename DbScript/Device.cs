using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript
{
    public class Device
    {
        public string Name { get; set; }
        public string Column { get; set; }

        public Device(string name, string column)
        {
            this.Name = name;
            this.Column = column;
        }
    }
}
