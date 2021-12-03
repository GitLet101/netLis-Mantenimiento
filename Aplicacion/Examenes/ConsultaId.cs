using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Examenes
{
    public class ConsultaId
    {
        public class ExamenesUnico : IRequest<TblExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ExamenesUnico, TblExamenes>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblExamenes> Handle(ExamenesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblExamenes.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
