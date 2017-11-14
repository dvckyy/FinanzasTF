using FinanzasCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanzasCF.Helpers
{
    public static class SessionHelper
    {

        public static Int32 GetIDUsuario(this HttpSessionStateBase session, Int32 def = 0)
        {
            return session["IDUsuario"].ToInteger(def);            
        }
        public static void SetIDUsuario(this HttpSessionStateBase session, Int32 val)
        {
            session["IDUsuario"] = val;
        }

        public static Usuario GetUsuario(this HttpSessionStateBase session)
        {
            return (Usuario)session["Usuario"];
        }
        public static void SetUsuario(this HttpSessionStateBase session, Usuario val)
        {
            session["Usuario"] = val;
        }
    }
}