using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TableInfo
    {
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string Shape { get; set; }
        public int? ShapeId { get; set; }
        public double?  Xposition { get; set; }
        public double? Yposition { get; set; }
        public bool IsBookable { get; set; }

    }
}
