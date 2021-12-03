using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.CategoriaExamenes
{
    public class ConsultaId
    {
        public class CategoriaExamenesUnico : IRequest<TblCatCategoriaExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<CategoriaExamenesUnico, TblCatCategoriaExamenes>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatCategoriaExamenes> Handle(CategoriaExamenesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatCategoriaExamenes.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
