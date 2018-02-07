using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BookingEntity
    {
        public string BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfGuests { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime  { get; set; }
        public TimeSpan? EndTime { get; set; }
        public List<TableInfoEntity> TableNumbers { get; set; }
        public string Notes { get; set; }
        public string BookedBy { get; set; }
        public bool hasArrived { get; set; }

    }
}
