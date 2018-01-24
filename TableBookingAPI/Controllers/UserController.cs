using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Model;
using BusinessLogic;
using System.Security.Claims;
using System.Data.Common;
using System.Data;

namespace TableBookingAPI.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/add")]
        public HttpResponseMessage NewCustomerRegistration(NewUserRequest userRequest)
        {
            if (userRequest == null) { Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentNullException(nameof(userRequest))); }

            try
            {
                //{
                //    "UserId": "vikas.sethia21@gmail.com",
                //  "FirstName": "Vikas",
                //  "LastName": "Sethia",
                //  "Password": "Pass@123",
                //  "userRole": "Admin"
                //}

                var userBL = new Auth();
                userBL.AddNewUser(userRequest);

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
