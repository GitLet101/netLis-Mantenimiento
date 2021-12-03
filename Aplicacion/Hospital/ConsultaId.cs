using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Hospital
{
    public class ConsultaId
    {
        public class HospitalUnico : IRequest<TblCatHospital>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<HospitalUnico, TblCatHospital>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatHospital> Handle(HospitalUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatHospitals.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
