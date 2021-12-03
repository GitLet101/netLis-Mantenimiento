using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Nacionalidad
{
    public class ConsultaId
    {
        public class NacionalidadUnico : IRequest<TblCatNacionalidad>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<NacionalidadUnico, TblCatNacionalidad>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatNacionalidad> Handle(NacionalidadUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatNacionalidads.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
