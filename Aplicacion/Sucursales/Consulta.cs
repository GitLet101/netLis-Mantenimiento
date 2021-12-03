using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sucursales
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatSucursales>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatSucursales>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatSucursales>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var sucursales = await _context.TblCatSucursales.ToListAsync();
                return sucursales;
            }
        }
    }
}
