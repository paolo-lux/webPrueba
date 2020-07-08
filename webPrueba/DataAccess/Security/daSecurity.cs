using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webPrueba.Models;

namespace webPrueba.DataAccess.Security
{
    public class daSecurity
    {

        public static AccountVM ValidateLogin(string Usuario)
        {
            AccountVM res = new AccountVM();
            try
            {
                if (Usuario == "admin")
                {
                    res = new AccountVM { correo = "admin@algo.com", nombre = "Administrador del Sistema", usuarioID = "admin" };
                }

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}