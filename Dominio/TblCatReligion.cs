using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Dominio.Model
{
    public partial class TblCatReligion
    {
        public TblCatReligion()
        {
            TblPacientes = new HashSet<TblPaciente>();
        }

        public Guid IdReigion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TblPaciente> TblPacientes { get; set; }
    }
}