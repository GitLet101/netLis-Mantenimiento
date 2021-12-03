using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Departamento
{
    public class ConsultaId
    {
        public class DepartamentoUnico : IRequest<TblCatDepartamento>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<DepartamentoUnico, TblCatDepartamento>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatDepartamento> Handle(DepartamentoUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatDepartamentos.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
