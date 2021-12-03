using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.PerfilesExamenes
{
    public class ConsultaId
    {
        public class PerfilesExamenesUnico : IRequest<TblCatPerfilesExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<PerfilesExamenesUnico, TblCatPerfilesExamenes>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatPerfilesExamenes> Handle(PerfilesExamenesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatPerfilesExamenes.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
