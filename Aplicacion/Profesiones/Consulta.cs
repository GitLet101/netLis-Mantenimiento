using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Profesiones
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatProfesiones>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatProfesiones>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatProfesiones>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var profesiones = await _context.TblCatProfesiones.ToListAsync();
                return profesiones;
            }
        }
    }
}
