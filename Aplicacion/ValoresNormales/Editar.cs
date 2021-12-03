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

namespace Aplicacion.ValoresNormales
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdValoresNormales { get; set; }
            public Guid IdExamen { get; set; }
            public Guid IdSexo { get; set; }
            public double RangoAlto { get; set; }
            public double RangoBajo { get; set; }
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
                var valoresNormales = await _context.TblCatValoresNormales.FindAsync(request.IdValoresNormales);
                if (valoresNormales == null)
                {
                    throw new Exception("El valor normal no existe");
                }
                valoresNormales.IdExamen = (request.IdExamen != null || request.IdExamen != Guid.Empty) ? request.IdExamen : valoresNormales.IdExamen;
                valoresNormales.IdSexo = (request.IdSexo != null || request.IdSexo != Guid.Empty) ? request.IdSexo : valoresNormales.IdSexo;
                valoresNormales.RangoAlto = request.RangoAlto != 0 ? request.RangoAlto : valoresNormales.RangoAlto;
                valoresNormales.RangoBajo = request.RangoBajo != 0 ? request.RangoBajo : valoresNormales.RangoBajo;
                valoresNormales.Estado = request.Estado != 0 ? request.Estado : valoresNormales.Estado;
                
                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el valor normal");
            }
        }
    }
}
