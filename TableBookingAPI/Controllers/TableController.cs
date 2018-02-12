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
using System.Web.Http.Cors;

namespace TableBookingAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TableController : ApiController
    {
        private IBookingLogic _bookingBL = new BookingLogic();

        /// <summary>
        ///  Get list of tables available for book
        /// </summary>
        /// <returns> list of tableinfo object</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/table/getall")]
        public List<TableInfoEntity> GetTables()
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
        [AllowAnonymous]
        [HttpGet]
        [Route("api/table/getshapes")]
        public List<TableShapeEntity> GetTableShapes()
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


        [AllowAnonymous]
        [HttpPost]
        [Route("api/table/post")]
        public HttpResponseMessage AddUpdateTable(TableInfoEntity tableRequest)
        {
            if (tableRequest == null) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(tableRequest))); }

            try
            {
                var identity = (ClaimsIdentity)User.Identity;

                _bookingBL.AddUpdateTable(tableRequest);

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
        /// Remove table from list
        /// </summary>
        /// <param name="tableRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/table/remove")]
        public HttpResponseMessage RemoveTable(string tableNumber)
        {
            if (string.IsNullOrEmpty(tableNumber)) { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(tableNumber))); }
            int requestedTable;
            if(!int.TryParse(tableNumber, out requestedTable))
            { return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(tableNumber))); }
            try
            {
                var identity = (ClaimsIdentity)User.Identity;

                _bookingBL.RemoveTable(requestedTable);

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
        /// Get all table status on requeted date and for for given time span in munites
        /// Free: Table is free      
        /// Booked: Table is booked
        /// DoubleBooked: Table is booked by more than 1 customer
        /// Occupied: Customer has arrived
        /// DoubleOccupied: Table is double booked and atleat 1 customer has arrived
        /// </summary>
        /// <param name="requestedDate"></param>
        /// <param name="timeSpanInMinutes"></param>
        /// <returns>List of table, time and status</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/table/gettablestatus")]
        public List<TableStatus> GetTableStatus(DateTime requestedDate, int timeSpanInMinutes)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var response = _bookingBL.GetTableStatusOnDate(requestedDate, timeSpanInMinutes);
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
