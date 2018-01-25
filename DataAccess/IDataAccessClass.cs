using System;
using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IDataAccessClass
    {
        void AddNewUser(user user);  
        user GetLoggedInUser(string userId);
        userrole GetUserRole(string userRole);
        void AddNewBooking(booking newBooking);
        void AddNewBooking(booking newBooking, List<bookedtable> bookedTableList);
        List<booking> GetBookingOnDate(DateTime bookingDate);
        List<tableinfo> GetTableList();
        List<tableshape> GetTableShapes();
        void AddNewTable(tableinfo newTableDetails);
        void AddNewShape(tableshape NewShapeRequest);
    }   

  
}
