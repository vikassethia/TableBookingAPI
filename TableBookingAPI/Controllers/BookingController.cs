using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using System.Security.Claims;
using System.Data.Common;
using System.Data;
using Entities;

namespace TableBookingAPI.Controllers
{
    public class BookingController : ApiController
    {
        private IBookingLogic _bookingBL = new BookingLogic();

        /// <summary>
        /// Book table in restaurant
        /// </summary>
        /// <param name="bookTableRequest"></param>
        /// <returns>HttpStatusCode: Created = 201</returns>
        [Authorize]
        [HttpPost]
        [Route("api/booking/add")]
        public HttpResponseMessage BookTable(Booking bookTableRequest)
        {
            if (bookTableRequest == null) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(bookTableRequest))); }

            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                if(string.IsNullOrEmpty(bookTableRequest.BookedBy))
                {
                    bookTableRequest.BookedBy = identity.Name;
                }
                _bookingBL.AddNewBooking(bookTableRequest);

            }
            catch (DbException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Connection error");
            }
            catch (DuplicateNameException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occured");
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Get table booking details for given date (example value: 2018-01-16T15:46:27.948Z)
        /// </summary>
        /// <param name="bookingDateRequest"></param>
        /// <returns>List of booking object</returns>
        [Authorize]
        [HttpGet]
        [Route("api/booking/getbydate")]
        public List<Booking> GetBooking(DateTime bookingDateRequest)
        {
            if (bookingDateRequest == null) { bookingDateRequest = DateTime.Now; }

            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var response = _bookingBL.GetBookingOnDate(bookingDateRequest);
                return response;
            }
            catch (DbException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Connection error"));
            }
            catch (DuplicateNameException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occured"));
            }
            
        }

        /// <summary>
        ///  Get list of tables available for book
        /// </summary>
        /// <returns> list of tableinfo object</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/booking/gettables")]
        public List<TableInfo> GetTables()
        {            
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var response = _bookingBL.GetTablesList();
                return response;
            }
            catch (DbException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Connection error"));
            }
            catch (DuplicateNameException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occured"));
            }
        }

        /// <summary>
        /// Get different shape of tables (use this to create new table and table visualization) 
        /// </summary>
        /// <returns>List of table shapes object</returns>
        [Authorize]
        [HttpGet]
        [Route("api/booking/gettableshapes")]
        public List<TableShape> GetTableShapes()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var response = _bookingBL.GetTableShapes();
                return response;
            }
            catch (DbException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Connection error"));
            }
            catch (DuplicateNameException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occured"));
            }
        }


        [Authorize]
        [HttpPost]
        [Route("api/table/add")]
        public HttpResponseMessage AddTable(TableInfo addTableRequest)
        {
            if (addTableRequest == null) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(addTableRequest))); }

            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                               
                _bookingBL.AddNewTable(addTableRequest);

            }
            catch (DbException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Connection error");
            }
            catch (DuplicateNameException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occured");
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}