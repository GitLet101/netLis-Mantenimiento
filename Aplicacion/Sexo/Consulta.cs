using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sexo
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatSexo>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatSexo>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatSexo>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var sexo = await _context.TblCatSexos.ToListAsync();
                return sexo;
            }
        }
    }
}
