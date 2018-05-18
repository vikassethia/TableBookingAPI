using System;
using DataAccess.Model;
using System.Collections.Generic;
using Entities;

namespace DataAccess
{
    public interface IDataAccessClass
    {
        void AddNewUser(user user);  
        user GetLoggedInUser(string userId);
        userrole GetUserRole(string userRole);
        void AddUpdateBooking(booking bookingRequest);
        List<booking> GetBookingOnDate(DateTime bookingDate);
        List<tableinfo> GetTableList();
        List<tableshape> GetTableShapes();
        void AddUpdateTable(tableinfo tableRequest);
        void AddNewShape(tableshape NewShapeRequest);
        void HasArrivedCustomer(string bookingId);
        void ArchiveDeleteBooking(string bookingId);
        void RemoveTable(int tableNumber);
        customer GetLoggedInCustomer(string customerId);
        void AddNewCustomer(customer customer);
        void UpdateCustomer(customer customer);
        List<customer> GetCustomerList();
        List<user> GetUserList();
        List<booking> GetAllFutureBooking();
    }     
}
