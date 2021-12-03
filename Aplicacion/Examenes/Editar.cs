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

namespace Aplicacion.Examenes
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdExamen { get; set; }
            public Guid IdAreaLabServicio { get; set; }
            public Guid IdCategoriaExamenes { get; set; }
            public Guid IdTipoMuestra { get; set; }
            public Guid IdUnidadMedidas { get; set; }
            public Guid IdTipoResultado { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
            public string Confidencial { get; set; }
            public int Estado { get; set; }
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
                var examenes = await _context.TblExamenes.FindAsync(request.IdExamen);
                if (examenes == null)
                {
                    throw new Exception("El examen no existe");
                }

                examenes.IdAreaLabServicio = (request.IdAreaLabServicio != null || request.IdAreaLabServicio != Guid.Empty) ? request.IdAreaLabServicio : examenes.IdAreaLabServicio;
                examenes.IdCategoriaExamenes = (request.IdCategoriaExamenes != null || request.IdCategoriaExamenes != Guid.Empty) ? request.IdCategoriaExamenes : examenes.IdCategoriaExamenes;
                examenes.IdTipoMuestra = (request.IdTipoMuestra != null || request.IdTipoMuestra != Guid.Empty) ? request.IdTipoMuestra : examenes.IdTipoMuestra;
                examenes.IdUnidadMedidas = (request.IdUnidadMedidas != null || request.IdUnidadMedidas != Guid.Empty) ? request.IdUnidadMedidas : examenes.IdUnidadMedidas;
                examenes.IdTipoResultado = (request.IdTipoResultado != null || request.IdTipoResultado != Guid.Empty) ? request.IdTipoResultado : examenes.IdTipoResultado;
                examenes.Descripcion = request.Descripcion ?? examenes.Descripcion;
                examenes.DescripcionCorta = request.DescripcionCorta ?? examenes.DescripcionCorta;
                examenes.Confidencial = request.Confidencial ?? examenes.Confidencial;
                examenes.Estado = request.Estado != 0 ? request.Estado : examenes.Estado;
                
                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el examen");
            }
        }
    }
}
