using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.UnidadesMedidas
{
    public class ConsultaId
    {
        public class UnidadesMedidasUnico : IRequest<TblCatUnidadMedida>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<UnidadesMedidasUnico, TblCatUnidadMedida>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatUnidadMedida> Handle(UnidadesMedidasUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatUnidadMedidas.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
