using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoResultado
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatTipoResultado>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatTipoResultado>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatTipoResultado>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var tipoResultado = await _context.TblCatTipoResultados.ToListAsync();
                return tipoResultado;
            }
        }
    }
}
