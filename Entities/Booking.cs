using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Booking
    {
        public string BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfGuests { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
        public List<TableInfo> TableNumbers { get; set; }
        public string Notes { get; set; }

    }
}
