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

namespace Aplicacion.Departamento
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {   
            public Guid IdDepartamento { get; set; }
            public Guid IdPais { get; set; }
            public string Descripcion { get; set; }
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
                var departamento = await _context.TblCatDepartamentos.FindAsync(request.IdDepartamento);
                if (departamento == null)
                {
                    throw new Exception("El curso no existe");
                }

                departamento.IdDepartamento = (request.IdDepartamento != null || request.IdDepartamento != Guid.Empty) ? request.IdDepartamento : departamento.IdDepartamento;
                departamento.IdPais = (request.IdPais != null || request.IdPais != Guid.Empty) ? request.IdPais : departamento.IdPais;
                departamento.Descripcion = request.Descripcion ?? departamento.Descripcion;

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
