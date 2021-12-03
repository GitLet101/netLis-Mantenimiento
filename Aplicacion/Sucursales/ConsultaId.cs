using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Sucursales
{
    public class ConsultaId
    {
        public class SucursalesUnico : IRequest<TblCatSucursales>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<SucursalesUnico, TblCatSucursales>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatSucursales> Handle(SucursalesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatSucursales.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
