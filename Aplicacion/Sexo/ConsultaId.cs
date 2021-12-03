using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Sexo
{
    public class ConsultaId
    {
        public class SexoUnico : IRequest<TblCatSexo>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<SexoUnico, TblCatSexo>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatSexo> Handle(SexoUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatSexos.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
