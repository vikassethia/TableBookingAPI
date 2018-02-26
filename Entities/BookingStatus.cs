using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BookingStatus
    {
        public List<BookingEntity> BookingList { get; set; }
        public List<TableStatus> TableStatusList { get; set; }
       

    }
}
