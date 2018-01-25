using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Model;
using Entities;

namespace BusinessLogic
{
    public class BookingLogic : IBookingLogic
    {
        private IDataAccessClass _dataAccess;
        private TableBookingModel _context = new TableBookingModel();
        public BookingLogic()
        {
            _dataAccess = new DataAccessClass(_context);
        }
        public void AddNewBooking(Booking newBooking)
        {
            var bookingEntity = new booking()
            {
                BookedBy=newBooking.BookedBy,
                bookedtables = new List<bookedtable>(),
                BookingDate = newBooking.BookingDate,
                BookingId = newBooking.BookingId,
                Email = newBooking.Email,
                EndTime = newBooking.EndTime,
                FirstName = newBooking.FirstName,
                LastName = newBooking.LastName,
                Notes = newBooking.Notes,
                NumberOfGuests = newBooking.NumberOfGuests,
                PhoneNumber = newBooking.PhoneNumber,
                StartTime = newBooking.StartTime
            };

            foreach(var table in newBooking.TableNumbers)
            {
                bookingEntity.bookedtables.Add(new bookedtable() {
                    BookingId=newBooking.BookingId,
                    TableNumber=table.TableNumber
                });
            }

            _dataAccess.AddNewBooking(bookingEntity);
        }

        public List<Booking> GetBookingOnDate(DateTime bookingDateRequest)
        {
            var bookingList = _dataAccess.GetBookingOnDate(bookingDateRequest);

            var response = new List<Booking>();

            foreach (var item in bookingList)
            {
                var bookingItem = new Booking()
                {
                    BookingDate = item.BookingDate,
                    BookingId = item.BookingId,
                    Email = item.Email,
                    EndTime = item.EndTime,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Notes = item.Notes,
                    NumberOfGuests = item.NumberOfGuests,
                    PhoneNumber = item.PhoneNumber,
                    StartTime = item.StartTime,
                    TableNumbers = new List<TableInfo>()
                };

                foreach (var t in item.bookedtables)
                {
                    bookingItem.TableNumbers.Add(new TableInfo() {
                        TableNumber=t.TableNumber,
                        Capacity=t.tableinfo.Capacity,
                        IsBookable=t.tableinfo.IsBookable,
                        Shape=t.tableinfo.tableshape.ShapeName,
                        Xposition=t.tableinfo.Xposition,
                        Yposition=t.tableinfo.Yposition
                    });
                }
                response.Add(bookingItem);

            }

            return response;
        }

        public List<TableInfo> GetTablesList()
        {
            var tableList = _dataAccess.GetTableList();

            var response = new List<TableInfo>();

            foreach (var table in tableList)
            {
                response.Add(
                    new TableInfo()
                    {
                        TableNumber = table.TableNumber,
                        Capacity = table.Capacity,
                        IsBookable = table.IsBookable,
                        Shape = table.tableshape.ShapeName,
                        Xposition = table.Xposition,
                        Yposition = table.Yposition
                    }
                    );
            }


            return response;
        }

        public List<TableShape> GetTableShapes()
        {
            var tableShapes = _dataAccess.GetTableShapes();

            var response = new List<TableShape>();

            foreach (var shape in tableShapes)
            {
                response.Add(
                    new TableShape()
                    {
                        Id = shape.ShapeId,
                        Name = shape.ShapeName
                    }
                    );
            }

            return response;
        }

        public List<booking> GetDayBooking(DateTime bookingDateRequest)
        {

            var response = new List<booking>();

            response.Add(new booking() { BookingId = "1", FirstName = "Vikas", LastName = "Sethia", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 2, StartTime = new TimeSpan(12, 30, 00), bookedtables = getTables(new List<int>() { 1 }) });
            response.Add(new booking() { BookingId = "1", FirstName = "Martin", LastName = "Karlsson", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 2, StartTime = new TimeSpan(12, 00, 00), bookedtables = getTables(new List<int>() { 2 }) });
            response.Add(new booking() { BookingId = "1", FirstName = "Jonas", LastName = "Wu", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 4, StartTime = new TimeSpan(12, 30, 00), bookedtables = getTables(new List<int>() { 3, 4 }) });

            return response;
        }

        private List<bookedtable> getTables(List<int> tableNumbers)
        {
            var response = new List<bookedtable>();

            foreach (var item in tableNumbers)
            {
                response.Add(new bookedtable() { TableNumber = item, BookingId = "1" });
            }


            return response;
        }

        public void AddNewTable(TableInfo tableRequest)
        {
            var newTableDetails = new tableinfo() {
                IsDeleted = false,
                Capacity=tableRequest.Capacity,
                IsBookable = tableRequest.IsBookable,
                Xposition = tableRequest.Xposition,
                Yposition = tableRequest.Yposition,
                TableNumber = tableRequest.TableNumber,
                ShapeId=tableRequest.ShapeId
            };           

            _dataAccess.AddNewTable(newTableDetails);
        }
    }
}
