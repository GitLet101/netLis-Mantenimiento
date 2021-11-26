using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Religiones
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatReligion>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatReligion>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatReligion>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var pais = await _context.TblCatReligion.ToListAsync();
                return pais;
            }
        }
    }
}
