using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess
{
    public class DataAccessClass : IDataAccessClass
    {
        private readonly TableBookingModel _context;

        public DataAccessClass(TableBookingModel context)
        {
            _context = context;
        }
        public void AddNewUser(user user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public user GetLoggedInUser(string userId)
        {
            return _context.users.FirstOrDefault(u => u.UserId.Equals(userId));
        }

        public userrole GetUserRole(string userRole)
        {
            return _context.userroles.FirstOrDefault(u => u.UserRoleName.Equals(userRole, StringComparison.OrdinalIgnoreCase));
        }

        public void AddNewBooking(booking newBooking)
        {
            _context.bookings.Add(newBooking);
            _context.SaveChanges();
        }

        public void AddNewBooking(booking newBooking, List<bookedtable> bookedTableList)
        {
            _context.bookings.Add(newBooking);
            _context.bookedtables.AddRange(bookedTableList);

            _context.SaveChanges();
        }

        public List<booking> GetBookingOnDate(DateTime bookingDate)
        {
            var bookingList = (from b in _context.bookings where b.BookingDate == bookingDate.Date select b).ToList();

            return bookingList;
        }

        public List<tableinfo> GetTableList()
        {
            var tableList = (from t in _context.tableinfoes where t.IsDeleted == false select t).ToList();

            return tableList;
        }

        public List<tableshape> GetTableShapes()
        {
            var tableShapes = (from t in _context.tableshapes select t).ToList();

            return tableShapes;
        }

        public void AddNewTable(tableinfo newTableDetails)
        {
            _context.tableinfoes.Add(newTableDetails);
            _context.SaveChanges();
        }        

        public void AddNewShape(tableshape NewShapeRequest)
        {
            _context.tableshapes.Add(NewShapeRequest);
            _context.SaveChanges();
        }
    }
}
