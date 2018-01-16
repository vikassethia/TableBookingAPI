using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogic
{
    public class BookingLogic
    {
        public void BookTable(Booking tableBookingRequest)
        {


        }

        public List<Booking> GetBookingOnDate(DateTime bookingDateREquest)
        {

            var response = new List<Booking>();

            response.Add(new Booking() {BookingId="1",FirstName="Vikas", LastName="Sethia", BookingDate=DateTime.Now, PhoneNumber="0789456123", NumberOfGuests=2, StartTime=DateTime.Now, TableNumbers= getTables(new List<int>() {1}) });
            response.Add(new Booking() { BookingId = "1", FirstName = "Martin", LastName = "Karlsson", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 2, StartTime = DateTime.Now, TableNumbers = getTables(new List<int>() { 2 }) });
            response.Add(new Booking() { BookingId = "1", FirstName = "Jonas", LastName = "Wu", BookingDate = DateTime.Now, PhoneNumber = "0789456123", NumberOfGuests = 4, StartTime = DateTime.Now, TableNumbers = getTables(new List<int>() { 3,4 }) });

            return response;
        }


        private List<TableInfo> getTables(List<int> tableNumbers)
        {
            var response = new List<TableInfo>();

            foreach(var item in tableNumbers)
            {
                response.Add(new TableInfo() { TableNumber=item, Seats=2, Shape="Square"});
            }


            return response;
        }
    }
}
