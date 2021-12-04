using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using AutoMapper;
using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Examenes
{
    public class ConsultaId
    {
        public class ExamenesUnico : IRequest<ExamenesDTO>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ExamenesUnico, ExamenesDTO>
        {
            private readonly netLisContext _context;
            private readonly IMapper _mapper;
            public Manejador(netLisContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ExamenesDTO> Handle(ExamenesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblExamenes
                    .Include(x => x.TblCatPerfilesExamenesLink)
                    .ThenInclude(x => x.IdPerfilesNavigation)
                    .FirstOrDefaultAsync(a => a.IdExamen == request.Id);
                if(consulta == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se encontro la consulta" });
                }

                var examenesDTO = _mapper.Map<TblExamenes, ExamenesDTO>(consulta);
                return examenesDTO;
            }
        }
    }
}
