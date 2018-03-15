using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CustomerEntity
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}
