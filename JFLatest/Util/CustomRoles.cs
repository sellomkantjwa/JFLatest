using MySql.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFLatest.Util
{
    interface CustomRoles
    {
        void AddUserToRole(employer user, string rolename);
    }
}
