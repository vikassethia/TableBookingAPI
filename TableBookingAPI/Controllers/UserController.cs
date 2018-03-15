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
using System.Web.Http.Cors;
using Entities;

namespace TableBookingAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IAuth _userBL = new Auth();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/add")]
        public HttpResponseMessage NewUserRegistration(UserRequest userRequest)
        {
            if (userRequest == null) { Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(userRequest))); }

            try
            {
                /*
                {
                    "UserId": "vikas.sethia21@gmail.com",
                  "FirstName": "Vikas",
                  "LastName": "Sethia",
                  "Password": "Pass@123",
                  "userRole": "Admin",
                  "customerId": "ricora"
                }

                */

                _userBL.AddNewUser(userRequest);

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
        /// Add new customer of booking software
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/customer/add")]
        public HttpResponseMessage NewCustomerRegistration(CustomerEntity customerRequest)
        {
            if (customerRequest == null) { Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(customerRequest))); }

            try
            {
                /*
                {
                    "UserId": "vikas.sethia21@gmail.com",
                  "FirstName": "Vikas",
                  "LastName": "Sethia",
                  "Password": "Pass@123",
                  "userRole": "Admin",
                  "customerId": "ricora"
                }

                */

                _userBL.AddNewCustomer(customerRequest);

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
        /// Update existing booking software customer
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/customer/update")]
        public HttpResponseMessage UpdateCustomer(CustomerEntity customerRequest)
        {
            if (customerRequest == null) { Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(customerRequest))); }

            try
            {
                /*
                {
                    "UserId": "vikas.sethia21@gmail.com",
                  "FirstName": "Vikas",
                  "LastName": "Sethia",
                  "Password": "Pass@123",
                  "userRole": "Admin",
                  "customerId": "ricora"
                }

                */

                _userBL.UpdateCustomer(customerRequest);

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
