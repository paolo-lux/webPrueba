using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webPrueba.Models
{
    public class AccountVM
    {
        public string usuarioID { get; set; }

        public string nombre { get; set; }

        public string correo { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}