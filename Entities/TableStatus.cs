using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TableStatus
    {
        public TimeSpan StartTime { get; set; }
        public string TableNumber { get; set; }
        public string Status { get; set; }
    }

    public enum TableStatusEnum
    {
        /// <summary>
        /// Table is free
        /// </summary>
        Free,
        /// <summary>
        /// Table is booked
        /// </summary>
        Booked,
        /// <summary>
        /// Table is booked by more than 1 customer
        /// </summary>
        DoubleBooked,
        /// <summary>
        /// Customer has arrived
        /// </summary>
        Occupied,
        /// <summary>
        /// Table is double booked and atleat 1 customer has arrived
        /// </summary>
        DoubleOccupied
    }
}
