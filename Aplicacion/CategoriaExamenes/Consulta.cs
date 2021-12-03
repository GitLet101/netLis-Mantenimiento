using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CategoriaExamenes
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatCategoriaExamenes>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatCategoriaExamenes>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatCategoriaExamenes>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var pais = await _context.TblCatCategoriaExamenes.ToListAsync();
                return pais;
            }
        }
    }
}
