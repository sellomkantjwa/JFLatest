using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFLatest.Util
{
    interface CustomSimpleMembership
    {
        Int32 CurrentUserId { get; }
        String CurrentUserName { get; }
        Boolean IsAuthenticated { get; }

        Boolean CreateUserAndAccount(String username, String password, String emailaddress = null);
        Boolean CreateUserAndAccount(String username, string password, out String confirmationToken, String emailaddress = null);
        Boolean Login(String username, String password, Boolean persistCookie = false);
        Boolean CreateUserAndAccount(employer emp, string password);
        void Logout();
    }
}
