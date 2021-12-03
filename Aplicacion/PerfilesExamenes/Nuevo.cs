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
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
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
                Guid _perfilesExamenesid = Guid.NewGuid();
                Debug.WriteLine(_perfilesExamenesid);
                var perfilesExamenes = new TblCatPerfilesExamenes
                {
                    IdPerfilesExamenes = _perfilesExamenesid,
                    IdExamen = request.IdExamen,
                    IdPerfiles = request.IdPerfiles
                };

                _context.TblCatPerfilesExamenes.Add(perfilesExamenes);

                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el Perfil Examen");
            }
        }
    }
}
