using Microsoft.AspNetCore.Http;
using System;

namespace PBL.Controllers
{
    public static class HelperControllers
    {

        public static Boolean VerificaUserLogado(ISession session)
        {
            string logado = session.GetString("Logado");
            if (logado == null)
                return false;
            else
                return true;
        }

        public static string GetUsername(ISession session)
        {
            return session.GetString("Username");
        }

        public static int GetUsuarioId(ISession session)
        {
            return int.Parse(session.GetString("id"));
        }
    }
}
