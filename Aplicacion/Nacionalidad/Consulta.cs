using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nacionalidad
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatNacionalidad>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatNacionalidad>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatNacionalidad>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var nacionalidad = await _context.TblCatNacionalidads.ToListAsync();
                return nacionalidad;
            }
        }
    }
}
