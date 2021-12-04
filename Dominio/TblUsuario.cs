using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Dominio.Model
{
    public class TblUsuario : IdentityUser
    {
        public Guid? IdEmpleado { get; set; }
    }
}
