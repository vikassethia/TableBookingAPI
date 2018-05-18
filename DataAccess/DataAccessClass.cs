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
        private string _customerId = string.Empty;

        public DataAccessClass(TableBookingModel context)
        {
            _context = context;
        }

        public DataAccessClass(TableBookingModel context, string customerId)
        {
            _customerId = customerId;
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
                if (bookingRequest.EndTime == null)
                {
                    bookingRequest.EndTime = bookingRequest.StartTime.Add(new TimeSpan(2, 0, 0));
                }
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
                customerBooking.HasArrived = bookingRequest.HasArrived;
                customerBooking.CustomerId = _customerId;
                if(customerBooking.EndTime==null)
                {
                    customerBooking.EndTime = customerBooking.StartTime.Add(new TimeSpan(2, 0, 0));
                }
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
            var bookingList = (from b in _context.bookings where b.BookingDate == bookingDate.Date && b.CustomerId.Equals(_customerId) select b).ToList();

            return bookingList;
        }

        public List<booking> GetAllFutureBooking()
        {
            var bookingDate = DateTime.Now.Date;
            var bookingList = (from b in _context.bookings where b.BookingDate >= bookingDate.Date && b.CustomerId.Equals(_customerId) select b).ToList();

            return bookingList;
        }

        public List<tableinfo> GetTableList()
        {
            var tableList = (from t in _context.tableinfoes where t.IsDeleted == false && t.CustomerId.Equals(_customerId) select t).ToList();

            return tableList;
        }

        public List<tableshape> GetTableShapes()
        {
            var tableShapes = (from t in _context.tableshapes select t).ToList();

            return tableShapes;
        }

        public void AddUpdateTable(tableinfo tableRequest)
        {

            var table = _context.tableinfoes.FirstOrDefault(t => t.TableNumber == tableRequest.TableNumber && t.CustomerId.Equals(_customerId));
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
                table.CustomerId = _customerId;
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
            customerBooking.HasArrived = true;
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
                HasArrived = customerBooking.HasArrived,
                Email = customerBooking.Email,
                EndTime = customerBooking.EndTime,
                FirstName = customerBooking.FirstName,
                LastName = customerBooking.LastName,
                Notes = customerBooking.Notes,
                NumberOfGuests = customerBooking.NumberOfGuests,
                PhoneNumber = customerBooking.PhoneNumber,
                StartTime = customerBooking.StartTime,
                CustomerId = customerBooking.CustomerId
            };

            foreach(var table in customerBooking.bookedtables)
            {
                archiveCustomerBooking.Bookedtables += table.TableId + ",";                
            }
            _context.bookedtables.RemoveRange(customerBooking.bookedtables);

            _context.archivedbookings.Add(archiveCustomerBooking);
            _context.bookings.Remove(customerBooking);
            _context.SaveChanges();
        }       

        public void RemoveTable(int tableNumber)
        {
            var removedTable = _context.tableinfoes.FirstOrDefault(t => t.TableNumber==tableNumber && t.CustomerId.Equals(_customerId));
            removedTable.IsDeleted = true;
            _context.SaveChanges();
        }

        public customer GetLoggedInCustomer(string customerId)
        {
            return _context.customers.FirstOrDefault(c => c.CustomerId.Equals(customerId));
        }

        public void AddNewCustomer(customer customer)
        {
            _context.customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(customer customer)
        {
            var existingCustomer = _context.customers.FirstOrDefault(c => c.CustomerId.Equals(customer.CustomerId));
            if (existingCustomer == null)
            {
                throw new Exception("Customer not found!");
            }
            else
            {
                existingCustomer.CompanyName = customer.CompanyName ?? existingCustomer.CompanyName;
                existingCustomer.DisplayName = customer.DisplayName ?? existingCustomer.DisplayName;
                existingCustomer.Address = customer.Address ?? existingCustomer.Address;
                existingCustomer.IsActive = customer.IsActive;
            }
            _context.SaveChanges();
        }

        public List<customer> GetCustomerList()
        {
            var customerList = (from t in _context.customers select t).ToList();

            return customerList;
        }

        public List<user> GetUserList()
        {
            var userList = (from t in _context.users where t.CustomerId.Equals(_customerId) select t).ToList();

            return userList;
        }        
    }
}
