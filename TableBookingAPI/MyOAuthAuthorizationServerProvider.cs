using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities;
using Microsoft.Owin.Security.OAuth;
using BusinessLogic;

namespace TableBookingAPI
{
    public class MyOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            //return base.ValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Vikas Sethia"));
                context.Validated(identity);
                return;
            }
            var bookingBl = new Auth();
            UserRequest userIdentity;
            if (bookingBl.IsUserAuthorized(context.UserName, context.Password, out userIdentity))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userIdentity.UserRole));
                identity.AddClaim(new Claim("username", userIdentity.UserId));
                identity.AddClaim(new Claim(ClaimTypes.Name, userIdentity.UserId));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, userIdentity.FirstName));
                identity.AddClaim(new Claim(ClaimTypes.Surname, userIdentity.LastName));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Invalid credential", "Provided username and password is incorrect");
                return;
            }



            //return base.GrantResourceOwnerCredentials(context);
        }


    }
}