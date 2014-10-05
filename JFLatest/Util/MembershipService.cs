using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            WebSecurity.CreateUserAndAccount(emp.email, password);
            using (
                var context = new jobfairContext())
            {
                context.employer.Add(emp);
                context.SaveChanges();
            }

            return true;
        }
    }
}