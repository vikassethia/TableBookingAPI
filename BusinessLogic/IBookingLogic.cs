using System;
using DataAccess.Model;
using System.Collections.Generic;
using DataAccess.Model;
using Entities;

namespace BusinessLogic
{
    public interface IBookingLogic
    {
        List<Booking> GetBookingOnDate(DateTime bookingDateREquest);
        List<TableInfo> GetTablesList();
        void AddNewBooking(Booking newBooking);
        List<booking> GetDayBooking(DateTime bookingDateRequest);
        List<TableShape> GetTableShapes();
        void AddNewTable(TableInfo tableRequest);

    }
}
