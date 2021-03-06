using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Profesiones
{
    public class ConsultaId
    {
        public class ProfesionesUnico : IRequest<TblCatProfesiones>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ProfesionesUnico, TblCatProfesiones>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatProfesiones> Handle(ProfesionesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatProfesiones.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
