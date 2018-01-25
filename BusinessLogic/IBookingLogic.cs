using System;
using DataAccess.Model;
using System.Collections.Generic;
using DataAccess.Model;

namespace BusinessLogic
{
    public interface IBookingLogic
    {
        List<booking> GetBookingOnDate(DateTime bookingDateREquest);
        List<tableinfo> GetTablesList();
        void AddNewBooking(booking newBooking);
        List<booking> GetDayBooking(DateTime bookingDateRequest);
        List<tableshape> GetTableShapes();
        void AddNewTable(tableinfo newTableDetails);

    }
}
