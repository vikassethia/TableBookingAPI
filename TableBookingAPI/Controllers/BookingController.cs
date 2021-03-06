﻿using System;
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
using System.Web.Http.Cors;

namespace TableBookingAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookingController : ApiController
    {
        private IBookingLogic _bookingBL;

        public BookingController()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var customerClaim = identity.Claims.FirstOrDefault(c => c.Type.Equals("customerid"));
            var customerId = (customerClaim == null) ? "ricora" : customerClaim.Value;
            _bookingBL = new BookingLogic(customerId);

        }

        /// <summary>
        /// Book table in restaurant
        /// </summary>
        /// <param name="bookTableRequest"></param>
        /// <returns>HttpStatusCode: Created = 201</returns>
       // [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("api/booking/post")]
        public HttpResponseMessage BookTable(BookingEntity bookTableRequest)
        {
            if (bookTableRequest == null) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(bookTableRequest))); }

            try
            {


                /*
                 {
                      "FirstName": "Vikas",
                      "LastName": "Sethia",
                      "PhoneNumber": "0123456789",
                      "NumberOfGuests": 4,
                      "BookingDate": "2018-01-26",
                      "StartTime": "18:00",
                      "TableNumbers": [
                        {
                          "TableNumber": 2,
                        },
	                    {
                          "TableNumber": 3,
                        }
                      ],
                      "Notes": "Veg",
                      "BookedBy": "vikas.sethia21@gmail"
                    }
                 */

                var identity = (ClaimsIdentity)User.Identity;
                if(string.IsNullOrEmpty(bookTableRequest.BookedBy))
                {
                    bookTableRequest.BookedBy = identity.Name;
                }
                _bookingBL.AddUpdateBooking(bookTableRequest);

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
        [AllowAnonymous]
        [HttpGet]
        [Route("api/booking/getbydate")]
        public List<BookingEntity> GetBooking(DateTime bookingDateRequest)
        {
            if (bookingDateRequest == null) { bookingDateRequest = DateTime.Now; }

            try
            {
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
        /// Get all future booking
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/booking/getall")]
        public List<BookingEntity> GetAllBooking()
        {
            
            try
            {
                var response = _bookingBL.GetAllfutureBooking();
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
        /// Mark customer as arrived in restaurant
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns>HttpStatusCode: Created = 201</returns>
       // [Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("api/booking/hasarrived")]
        public HttpResponseMessage HasArrived(string bookingId)
        {
            if (string.IsNullOrEmpty(bookingId)) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(bookingId))); }

            try
            {    
                _bookingBL.HasArrivedCustomer(bookingId);

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


        [AllowAnonymous]
        [HttpPost]
        [Route("api/booking/delete")]
        public HttpResponseMessage DeleteBooking(string bookingId)
        {
            if (string.IsNullOrEmpty(bookingId)) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(bookingId))); }

            try
            {
                _bookingBL.ArchiveDeleteBooking(bookingId);

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

        [AllowAnonymous]
        [HttpGet]
        [Route("api/booking/getstatusbydate")]
        public BookingStatus GetBookingStatus(DateTime bookingDateRequest, int timeSpanInMinutes)
        {
            if (bookingDateRequest == null) { bookingDateRequest = DateTime.Now; }

            try
            {
                var response = _bookingBL.GetBookingStatus(bookingDateRequest, timeSpanInMinutes);
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

    }
}