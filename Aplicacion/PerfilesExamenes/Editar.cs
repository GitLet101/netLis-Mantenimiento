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

namespace Aplicacion.PerfilesExamenes
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdPerfilesExamenes { get; set; }
            public Guid IdExamen { get; set; }
            public Guid IdPerfiles { get; set; }
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
                var perfilesExamenes = await _context.TblCatPerfilesExamenes.FindAsync(request.IdPerfilesExamenes);
                if (perfilesExamenes == null)
                {
                    throw new Exception("El perfil examen no existe");
                }

                perfilesExamenes.IdPerfilesExamenes = (request.IdPerfilesExamenes != null || request.IdPerfilesExamenes != Guid.Empty) ? request.IdPerfilesExamenes : perfilesExamenes.IdPerfilesExamenes;
                perfilesExamenes.IdExamen = (request.IdExamen != null || request.IdExamen != Guid.Empty) ? request.IdExamen : perfilesExamenes.IdExamen;
                perfilesExamenes.IdPerfiles = (request.IdPerfiles != null || request.IdPerfiles != Guid.Empty) ? request.IdPerfiles : perfilesExamenes.IdPerfiles;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el perfil examen");
            }
        }
    }
}
