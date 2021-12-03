using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UnidadesMedidas
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatUnidadMedida>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatUnidadMedida>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatUnidadMedida>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var unidadesMedidas = await _context.TblCatUnidadMedidas.ToListAsync();
                return unidadesMedidas;
            }
        }
    }
}
