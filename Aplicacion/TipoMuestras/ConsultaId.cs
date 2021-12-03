using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.TipoMuestras
{
    public class ConsultaId
    {
        public class TipoMuestrasUnico : IRequest<TblCatTipoMuestra>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoMuestrasUnico, TblCatTipoMuestra>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatTipoMuestra> Handle(TipoMuestrasUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatTipoMuestras.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
