using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.ValoresNormales
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatValoresNormales>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatValoresNormales>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatValoresNormales>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var valoresN = await _context.TblCatValoresNormales.ToListAsync();
                return valoresN;
            }
        }
    }
}
