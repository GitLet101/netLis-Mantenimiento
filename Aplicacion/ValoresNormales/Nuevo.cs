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
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
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
    }*/

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _valoresNormalesid = Guid.NewGuid();
                Debug.WriteLine(_valoresNormalesid);
                var valoresNormales = new TblCatValoresNormales
                {
                    IdValoresNormales = _valoresNormalesid,
                    IdExamen = request.IdExamen,
                    IdSexo = request.IdSexo,
                    RangoAlto = request.RangoAlto,
                    RangoBajo = request.RangoBajo,
                    Estado = request.Estado
                };

                _context.TblCatValoresNormales.Add(valoresNormales);

                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el valor normal");
            }
        }
    }
}
