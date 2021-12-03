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
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
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
                Guid _departamentoid = Guid.NewGuid();
                Debug.WriteLine(_departamentoid);
                var departamento = new TblCatDepartamento
                {
                    IdDepartamento = _departamentoid,
                    IdPais = request.IdPais,
                    Descripcion = request.Descripcion,
                    Estado = request.Estado
                };

                _context.TblCatDepartamentos.Add(departamento);

                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el departamento");
            }
        }
    }
}
