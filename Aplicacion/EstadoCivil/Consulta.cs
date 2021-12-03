using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.EstadoCivil
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatEstadoCivil>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatEstadoCivil>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatEstadoCivil>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var estadoCivil = await _context.TblCatEstadoCivils.ToListAsync();
                return estadoCivil;
            }
        }
    }
}
