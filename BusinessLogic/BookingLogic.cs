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
        private string _customerId = string.Empty;
        public BookingLogic()
        {
            _dataAccess = new DataAccessClass(_context);
        }

        public BookingLogic(string customerId)
        {
            _customerId = customerId;
            _dataAccess = new DataAccessClass(_context, customerId);
        }

        public void AddUpdateBooking(BookingEntity bookingRequest)
        {
            bookingRequest.BookingId = Guid.NewGuid().ToString();
            var bookingEntity = new booking()
            {
                BookedBy=bookingRequest.BookedBy,
                bookedtables = new List<bookedtable>(),
                BookingDate = bookingRequest.BookingDate,
                BookingId = bookingRequest.BookingId.ToString(),
                Email = bookingRequest.Email,
                EndTime = bookingRequest.EndTime,
                FirstName = bookingRequest.FirstName,
                LastName = bookingRequest.LastName,
                Notes = bookingRequest.Notes,
                NumberOfGuests = bookingRequest.NumberOfGuests,
                PhoneNumber = bookingRequest.PhoneNumber,
                StartTime = bookingRequest.StartTime,
                HasArrived=bookingRequest.hasArrived,
                CustomerId=_customerId
            };
            var customerTableList = _dataAccess.GetTableList();
            foreach(var table in bookingRequest.TableNumbers)
            {
                var selectedTable = customerTableList.FirstOrDefault(t => t.TableNumber == table.TableNumber);
                bookingEntity.bookedtables.Add(new bookedtable() {
                    BookingId=bookingRequest.BookingId.ToString(),
                    TableId= selectedTable.TableId
                });
            }

            _dataAccess.AddUpdateBooking(bookingEntity);
        }

        public List<BookingEntity> GetBookingOnDate(DateTime bookingDateRequest)
        {
            var bookingList = _dataAccess.GetBookingOnDate(bookingDateRequest);

            var response = new List<BookingEntity>();

            foreach (var item in bookingList)
            {
                var bookingItem = new BookingEntity()
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
                    hasArrived=item.HasArrived,
                    TableNumbers = new List<TableInfoEntity>()
                };

                foreach (var t in item.bookedtables)
                {
                    bookingItem.TableNumbers.Add(new TableInfoEntity() {
                        TableNumber=t.tableinfo.TableNumber,                        
                        TableName=t.tableinfo.TableName,
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

        public List<TableInfoEntity> GetTablesList()
        {
            var tableList = _dataAccess.GetTableList();

            var response = new List<TableInfoEntity>();

            foreach (var table in tableList)
            {
                response.Add(
                    new TableInfoEntity()
                    {
                        TableNumber = table.TableNumber,
                        TableName = table.TableName,
                        Capacity = table.Capacity,
                        IsBookable = table.IsBookable,
                        Shape = table.tableshape.ShapeName,
                        ShapeId = table.ShapeId,
                        Xposition = table.Xposition,
                        Yposition = table.Yposition
                    }
                    );
            }


            return response;
        }

        public List<TableShapeEntity> GetTableShapes()
        {
            var tableShapes = _dataAccess.GetTableShapes();

            var response = new List<TableShapeEntity>();

            foreach (var shape in tableShapes)
            {
                response.Add(
                    new TableShapeEntity()
                    {
                        Id = shape.ShapeId,
                        Name = shape.ShapeName
                    }
                    );
            }

            return response;
        }

        //public List<booking> GetDayBooking(DateTime bookingDateRequest)
        //{

        //    var response = new List<booking>();

        //    response.Add(new booking() { BookingId = "1", FirstName = "Vikas", LastName = "Sethia", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 2, StartTime = new TimeSpan(12, 30, 00), bookedtables = getTables(new List<int>() { 1 }) });
        //    response.Add(new booking() { BookingId = "1", FirstName = "Martin", LastName = "Karlsson", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 2, StartTime = new TimeSpan(12, 00, 00), bookedtables = getTables(new List<int>() { 2 }) });
        //    response.Add(new booking() { BookingId = "1", FirstName = "Jonas", LastName = "Wu", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 4, StartTime = new TimeSpan(12, 30, 00), bookedtables = getTables(new List<int>() { 3, 4 }) });

        //    return response;
        //}

        //private List<bookedtable> getTables(List<int> tableNumbers)
        //{
        //    var response = new List<bookedtable>();

        //    foreach (var item in tableNumbers)
        //    {
        //        response.Add(new bookedtable() { TableNumber = item, BookingId = "1" });
        //    }


        //    return response;
        //}

        public void AddUpdateTable(TableInfoEntity tableRequest)
        {
            var newTableDetails = new tableinfo() {
                IsDeleted = false,
                Capacity=tableRequest.Capacity,
                IsBookable = tableRequest.IsBookable,
                Xposition = tableRequest.Xposition,
                Yposition = tableRequest.Yposition,
                TableNumber = tableRequest.TableNumber,
                TableName = tableRequest.TableName,
                ShapeId=tableRequest.ShapeId,
                CustomerId=_customerId
            };           

            _dataAccess.AddUpdateTable(newTableDetails);
        }

        public void AddNewShape(TableShapeEntity newShapeRequest)
        {
            var newShape = new tableshape()
            {
                ShapeName = newShapeRequest.Name
            };
            _dataAccess.AddNewShape(newShape);
        }

        public void HasArrivedCustomer(string bookingId)
        {
            _dataAccess.HasArrivedCustomer(bookingId);
        }

        public void ArchiveDeleteBooking(string bookingId)
        {
            _dataAccess.ArchiveDeleteBooking(bookingId);
        }      

        public void RemoveTable(int tableNumber)
        {
            _dataAccess.RemoveTable(tableNumber);
        }

        public List<TableStatus> GetTableStatusOnDate(DateTime requestedDate, int timeSpanInMinutes)
        {
            return GetTableStatus(GetBookingOnDate(requestedDate), timeSpanInMinutes);
        }

        public  List<TableStatus>  GetTableStatus(List<BookingEntity> bookingList, int timeSpanInMinutes)
        {
            var response = new List<TableStatus>();

            foreach(var b in bookingList)
            {
                var bookedTimeList = GetTimeList(timeSpanInMinutes,b.StartTime, b.EndTime);
                foreach(var t in b.TableNumbers)
                {
                    foreach (var span in bookedTimeList)
                    {
                        var tableStatusItem = new TableStatus() { StartTime=span, TableNumber=t.TableNumber.ToString(),Status=TableStatusEnum.Booked.ToString()};
                        if(b.hasArrived)
                        {
                            tableStatusItem.Status = TableStatusEnum.Occupied.ToString();
                        }
                        var findDouble = response.Find(r => r.TableNumber.Equals(t.TableNumber) && r.StartTime == span);
                        if(findDouble==null)
                        {
                            response.Add(tableStatusItem);
                        }
                        else
                        {
                            if (findDouble.Status.Equals(TableStatusEnum.Occupied.ToString()) || findDouble.Status.Equals(TableStatusEnum.DoubleOccupied.ToString()))
                            {
                                findDouble.Status = TableStatusEnum.DoubleOccupied.ToString();
                            }
                            else
                            {
                                findDouble.Status = TableStatusEnum.DoubleBooked.ToString();
                            }
                        }

                    }
                }

            }


            return response;

        }

        
        public BookingStatus GetBookingStatus(DateTime requestedDate, int timeSpanInMinutes)
        {
            var response = new BookingStatus();
            response.BookingList = GetBookingOnDate(requestedDate);
            response.TableStatusList= GetTableStatus(response.BookingList, timeSpanInMinutes);
            return response;
        }

        private List<TimeSpan> GetTimeList(int timeSpanInMinutes, TimeSpan startTime, TimeSpan? endTime = null)
        {
            var response = new List<TimeSpan>();
                      

            startTime = new TimeSpan(startTime.Hours, (startTime.Minutes / timeSpanInMinutes) * timeSpanInMinutes, 00);
            if (endTime == null)
            { endTime = startTime.Add(new TimeSpan(02, 00, 00)); }

            var checkTime = startTime;

            while(checkTime<endTime)
            {
                response.Add(checkTime);
                checkTime = checkTime.Add(new TimeSpan(0, timeSpanInMinutes, 0));
            }

            return response;
        }


    }

    
}
