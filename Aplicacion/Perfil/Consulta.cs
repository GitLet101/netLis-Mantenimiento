using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfil
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatPerfiles>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatPerfiles>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatPerfiles>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var perfil = await _context.TblCatPerfiles.ToListAsync();
                return perfil;
            }
        }
    }
}
