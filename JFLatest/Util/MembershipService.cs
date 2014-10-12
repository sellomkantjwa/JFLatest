using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;


namespace JFLatest.Util
{
    public class MembershipService : CustomSimpleMembership
    {

        int CustomSimpleMembership.CurrentUserId
        {
            get { return WebSecurity.CurrentUserId; }
        }

        string CustomSimpleMembership.CurrentUserName
        {
            get { return WebSecurity.CurrentUserName; }
        }

        Boolean CustomSimpleMembership.IsAuthenticated
        {
            get { return WebSecurity.IsAuthenticated; }
        }

        Boolean CustomSimpleMembership.CreateUserAndAccount(string username, string password, string emailaddress)
        {
            WebSecurity.CreateUserAndAccount(username, password, emailaddress);
            return true;
        }

        Boolean CustomSimpleMembership.CreateUserAndAccount(string username, string password, out string confirmationToken, string emailaddress)
        {
            throw new NotImplementedException();
        }

        Boolean CustomSimpleMembership.Login(string username, string password, Boolean persistCookie)
        {

            return WebSecurity.Login(username, password, persistCookie);

        }

        void CustomSimpleMembership.Logout()
        {
            throw new NotImplementedException();
        }

        public Boolean CreateUserAndAccount(employer emp, string password)
        {
            emp.userType = Util.Constants.EMPLOYER_USER_TYPE;

            try
            {
                WebSecurity.CreateUserAndAccount(emp.email, password);
            }
            catch (Exception e)
            {
                throw;
            }
            using (
                var context = new jobfairContext())
            {
                context.employer.Add(emp);
                try
                {
                    emp.id = GetUserId(emp.email);
                    if (!Roles.IsUserInRole(emp.email, "employer"))
                    {
                        Roles.AddUserToRole(emp.email, "employer");
                    }

                }
                catch (HttpException e)
                {
                    throw e;
                }
                context.SaveChanges();
            }
            return true;
        }

        public int GetUserId(string email)
        {
            int userId = -1;
            using (jobfairContext db = new jobfairContext())
            {
                user emp = db.user.Where(e => e.email == email).FirstOrDefault();
                userId = emp.UserId;
            }

            return userId;
        }
    }
}