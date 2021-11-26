using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Departamento
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatDepartamento>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatDepartamento>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatDepartamento>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var departamento = await _context.TblCatDepartamentos.ToListAsync();
                return departamento;
            }
        }
    }
}
