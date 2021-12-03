using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Identificacion
{
    public class ConsultaId
    {
        public class IdentificacionUnico : IRequest<TblCatIdentificacion>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<IdentificacionUnico, TblCatIdentificacion>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatIdentificacion> Handle(IdentificacionUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatIdentificacions.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
