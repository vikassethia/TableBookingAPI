using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Model;

namespace BusinessLogic
{
    public class BookingLogic : IBookingLogic
    {
        private DataAccessClass _dataAccess;
        private TableBookingModel _context = new TableBookingModel();
        public BookingLogic()
        {
            _dataAccess = new DataAccessClass(_context);
        }
        public void AddNewBooking(booking newBooking)
        {
             _dataAccess.AddNewBooking(newBooking);
        }
        
        public List<booking> GetBookingOnDate(DateTime bookingDateRequest)
        {
            var bookingList = _dataAccess.GetBookingOnDate(bookingDateRequest);

            return bookingList;
        }

        public List<tableinfo> GetTablesList()
        {
            var tableList = _dataAccess.GetTableList();

            return tableList;
        }

        public List<booking> GetDayBooking(DateTime bookingDateRequest)
        {

            var response = new List<booking>();

            response.Add(new booking() {BookingId="1",FirstName="Vikas", LastName="Sethia", BookingDate=DateTime.Now, PhoneNumber="0789456123", NumberOfGuests=2, StartTime=new TimeSpan(12,30,00), bookedtables= getTables(new List<int>() {1}) });
            response.Add(new booking() { BookingId = "1", FirstName = "Martin", LastName = "Karlsson", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 2, StartTime = new TimeSpan(12, 00, 00), bookedtables = getTables(new List<int>() { 2 }) });
            response.Add(new booking() { BookingId = "1", FirstName = "Jonas", LastName = "Wu", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 4, StartTime = new TimeSpan(12, 30, 00), bookedtables = getTables(new List<int>() { 3,4 }) });

            return response;
        }        

        private List<bookedtable> getTables(List<int> tableNumbers)
        {
            var response = new List<bookedtable>();

            foreach(var item in tableNumbers)
            {
                response.Add(new bookedtable() { TableNumber=item, BookingId="1"});
            }


            return response;
        }

    }
}
