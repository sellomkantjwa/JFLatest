using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace JFLatest.Util
{
    public static class RoleService
    {
        public static void AddUserToRole(employer user, string rolename)
        {

            if(!Roles.IsUserInRole(user.email, "employer")){
            Roles.AddUserToRole(user.email, rolename);
            }

            //change the id in users table to match user table
            using (jobfairContext db = new jobfairContext())
            {
                var query =
                    from q in db.my_aspnet_users
                    where q.name == user.email
                    select q;

                my_aspnet_users selectedUser = query.First();
                selectedUser.id = user.id;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;

                }
            }


        }

    }
}