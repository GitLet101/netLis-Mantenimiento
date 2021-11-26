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

namespace Aplicacion.Pais
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public string Descripcion { get; set; }
            public int Estado { get; set; }
            public Guid IdPais { get; set; }
        }

        /*public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
            }
        }
*/
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;

            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var pais = await _context.TblCatPais.FindAsync(request.IdPais);
                if (pais == null)
                {
                    throw new Exception("El curso no existe");
                }

                pais.Descripcion = request.Descripcion ?? pais.Descripcion;
                pais.Estado = request.Estado != 0 ? request.Estado : pais.Estado;
                
                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el curso");
            }
        }
    }
}
