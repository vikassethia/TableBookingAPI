using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Entities;

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
     
        public void AddUpdateBooking(booking bookingRequest)
        {

            var customerBooking = _context.bookings.FirstOrDefault(b => b.BookingId.Equals(bookingRequest.BookingId, StringComparison.OrdinalIgnoreCase));

            if (customerBooking == null)
            {
                _context.bookings.Add(bookingRequest);
            }
            else
            {
                customerBooking.BookingDate = bookingRequest.BookingDate;
                customerBooking.StartTime = bookingRequest.StartTime;
                customerBooking.FirstName = bookingRequest.FirstName ?? customerBooking.FirstName;
                customerBooking.LastName = bookingRequest.LastName ?? customerBooking.LastName;
                customerBooking.Email = bookingRequest.Email ?? customerBooking.Email;
                customerBooking.Notes = bookingRequest.Notes ?? customerBooking.Notes;
                customerBooking.NumberOfGuests = bookingRequest.NumberOfGuests;
                customerBooking.PhoneNumber = bookingRequest.PhoneNumber ?? customerBooking.PhoneNumber;
                customerBooking.BookedBy = bookingRequest.BookedBy ?? customerBooking.BookedBy;
                customerBooking.EndTime = bookingRequest.EndTime ?? customerBooking.EndTime;
                customerBooking.hasArrived = bookingRequest.hasArrived;
                if (bookingRequest.bookedtables != null)
                {
                    _context.bookedtables.RemoveRange(customerBooking.bookedtables);
                    _context.bookedtables.AddRange(bookingRequest.bookedtables);
                }

            }           

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

        public void AddUpdateTable(tableinfo tableRequest)
        {

            var table = _context.tableinfoes.FirstOrDefault(t => t.TableNumber == tableRequest.TableNumber);
            if (table == null)
            {
                _context.tableinfoes.Add(tableRequest);
            }
            else
            {
                table.TableName = tableRequest.TableName ?? table.TableName;
                table.Xposition = tableRequest.Xposition ?? table.Xposition;
                table.Yposition = tableRequest.Yposition ?? table.Yposition;
                table.ShapeId = tableRequest.ShapeId ?? table.ShapeId;
                table.IsBookable = tableRequest.IsBookable;
                table.Capacity = tableRequest.Capacity;
                table.IsDeleted = false;
            }
            _context.SaveChanges();
        }        

        public void AddNewShape(tableshape NewShapeRequest)
        {
            _context.tableshapes.Add(NewShapeRequest);
            _context.SaveChanges();
        }

        public void HasArrivedCustomer(string bookingId)
        {
            var customerBooking = _context.bookings.FirstOrDefault(b => b.BookingId.Equals(bookingId, StringComparison.OrdinalIgnoreCase));
            customerBooking.hasArrived = true;
            _context.SaveChanges();
        }

        public void ArchiveDeleteBooking(string bookingId)
        {
            var customerBooking = _context.bookings.FirstOrDefault(b => b.BookingId.Equals(bookingId, StringComparison.OrdinalIgnoreCase));

            var archiveCustomerBooking = new archivedbooking()
            {
                BookingId=customerBooking.BookingId,
                BookedBy = customerBooking.BookedBy,
                BookingDate = customerBooking.BookingDate,
                hasArrived = customerBooking.hasArrived,
                Email = customerBooking.Email,
                EndTime = customerBooking.EndTime,
                FirstName = customerBooking.FirstName,
                LastName = customerBooking.LastName,
                Notes = customerBooking.Notes,
                NumberOfGuests = customerBooking.NumberOfGuests,
                PhoneNumber = customerBooking.PhoneNumber,
                StartTime = customerBooking.StartTime
            };

            foreach(var table in customerBooking.bookedtables)
            {
                archiveCustomerBooking.bookedtables += table.TableNumber + ",";
                _context.bookedtables.Remove(table);
            }

            _context.archivedbookings.Add(archiveCustomerBooking);
            _context.bookings.Remove(customerBooking);
            _context.SaveChanges();
        }       

        public void RemoveTable(int tableNumber)
        {
            var removedTable = _context.tableinfoes.FirstOrDefault(t => t.TableNumber==tableNumber);
            removedTable.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
