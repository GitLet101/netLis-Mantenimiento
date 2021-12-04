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

namespace Aplicacion.Examenes
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
                var perfiles = _context.TblCatPerfilesExamenes.Where(x => x.IdExamen == request.Id);
                foreach (var perfil in perfiles)
                {
                    _context.TblCatPerfilesExamenes.Remove(perfil);
                }
                var examenes = await _context.TblExamenes.FindAsync(request.Id);
                if (examenes == null)
                {
                    throw new ManejadorExcepcion(System.Net.HttpStatusCode.NotFound, new { examenes = "No se encontró el examen" });
                }
                _context.Remove(examenes);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el examen");
            }
        }
    }
}
