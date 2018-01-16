﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using BusinessLogic;
using System.Security.Claims;
using System.Data.Common;
using System.Data;

namespace TableBookingAPI.Controllers
{
    public class BookingController : ApiController
    {
        [Authorize]
        [HttpPost]
        [Route("api/post/booking")]
        public HttpResponseMessage BookTable(Booking bookTableRequest)
        {
            if (bookTableRequest == null) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(bookTableRequest))); }

            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var bookingBL = new BookingLogic();
                bookingBL.BookTable(bookTableRequest);

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
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("api/get/booking")]
        public List<Booking> GetBooking(DateTime bookingDateRequest)
        {
            if (bookingDateRequest == null) { bookingDateRequest = DateTime.Now; }

            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var bookingBL = new BookingLogic();
                var response = bookingBL.GetBookingOnDate(bookingDateRequest);
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