using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.PerfilesExamenes
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatPerfilesExamenes>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatPerfilesExamenes>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatPerfilesExamenes>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var perfilesExamenes = await _context.TblCatPerfilesExamenes.ToListAsync();
                return perfilesExamenes;
            }
        }
    }
}
