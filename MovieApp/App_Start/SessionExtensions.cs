using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp
{
    public static class SessionExtensions
    {
        public static void Set(this HttpSessionStateBase session, UserSessionModel value)
        {
            session["user"] = value;
        }
        

        public static UserSessionModel Get(this HttpSessionStateBase session)
        {
            return session["user"] as UserSessionModel;
        }
    }
}