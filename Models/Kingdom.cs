using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KingdomWeb.Models
{
    public class Kingdom:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}