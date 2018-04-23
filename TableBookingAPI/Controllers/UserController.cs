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
        private IAuth _userBL;

        public UserController()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var customerClaim = identity.Claims.FirstOrDefault(c => c.Type.Equals("customerid"));
            var customerId = (customerClaim == null) ? "ricora" : customerClaim.Value;
            _userBL = new Auth(customerId);

        }

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


        /// <summary>
        ///  Get list of registered customers of booking software
        /// </summary>
        /// <returns> list of customer object</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/customer/get")]
        public List<CustomerEntity> GetCustomers()
        {
            try
            {

                var response = _userBL.GetCustomerList();
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
        ///  Get list of registered users of logged-in customer
        /// </summary>
        /// <returns> list of user object</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/user/get")]
        public List<UserEntity> GetUsers()
        {
            try
            {

                var response = _userBL.GetUserList();
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
