using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;
using Aplicacion.ManejadorError;

namespace Aplicacion.Pais
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public Guid Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var pais = await _context.TblCatPais.FindAsync(request.Id);
                if (pais == null)
                {
                    throw new ManejadorExcepcion(System.Net.HttpStatusCode.NotFound, new { pais = "No se encontró el pais" });
                }
                _context.Remove(pais);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el pais");
            }
        }
    }
}
