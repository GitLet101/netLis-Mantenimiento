using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreaServicios
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatAreasServ>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatAreasServ>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatAreasServ>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var areaServicios = await _context.TblCatAreasServs.ToListAsync();
                return areaServicios;
            }
        }
    }
}
