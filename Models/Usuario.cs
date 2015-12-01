using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace KingdomWeb.Models
{
    public class Usuario
    {


        public int UsuarioId { get; set; }
         //[Required]
         //[Display(Name = "NombreUsuario: ")]
        public string NombreUsuario { get; set; }

         //[Required]
         //[DataType(DataType.Password)]
         //[StringLength(50, MinimumLength = 6)]
         //[Display(Name = "ContraseñaUsuario: ")]
        public string ContraseñaUsuario { get; set; }


        //public string ContraseñaUsuarioSalt { get; set; }

        //[Required]
        //[EmailAddress]
        //[StringLength(50)]
        //[Display(Name = "EmailUsuario: ")]
        public string EmailUsuario { get; set; }
    }


   
}