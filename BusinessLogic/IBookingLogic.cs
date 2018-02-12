using System;
using DataAccess.Model;
using System.Collections.Generic;
using Entities;

namespace BusinessLogic
{
    public interface IBookingLogic
    {
        List<BookingEntity> GetBookingOnDate(DateTime bookingDateREquest);
        List<TableInfoEntity> GetTablesList();
        void AddUpdateBooking(BookingEntity bookingRequest);
        List<TableShapeEntity> GetTableShapes();
        void AddUpdateTable(TableInfoEntity tableRequest);
        void AddNewShape(TableShapeEntity newShapeRequest);
        void HasArrivedCustomer(string bookingId);
        void ArchiveDeleteBooking(string bookingId);
        void RemoveTable(int tableNumber);
        List<TableStatus> GetTableStatusOnDate(DateTime requestedDate, int timeSpanInMinutes);
        List<TableStatus> GetTableStatus(List<BookingEntity> bookingList, int timeSpanInMinutes);

    }
}
