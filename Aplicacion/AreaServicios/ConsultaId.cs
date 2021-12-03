using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.AreaServicios
{
    public class ConsultaId
    {
        public class AreaServiciosUnico : IRequest<TblCatAreasServ>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<AreaServiciosUnico, TblCatAreasServ>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatAreasServ> Handle(AreaServiciosUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatAreasServs.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
