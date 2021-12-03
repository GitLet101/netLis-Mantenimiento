using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Paciente
{
    public class ConsultaId
    {
        public class PacienteUnico : IRequest<TblPaciente>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<PacienteUnico, TblPaciente>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblPaciente> Handle(PacienteUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblPacientes.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
