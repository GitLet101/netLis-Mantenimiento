using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Religiones
{
    public class ConsultaId
    {
        public class ReligionesUnico : IRequest<TblCatReligion>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ReligionesUnico, TblCatReligion>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatReligion> Handle(ReligionesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatReligion.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
