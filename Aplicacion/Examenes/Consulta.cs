using AutoMapper;
using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examenes
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<ExamenesDTO>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<ExamenesDTO>>
        {
            private readonly netLisContext _context;
            private readonly IMapper _mapper;
            public Manejador(netLisContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

        }
            public async Task<List<ExamenesDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var examenes = await _context.TblExamenes
                    .Include(x => x.TblCatPerfilesExamenesLink)
                    .ThenInclude(x => x.IdPerfilesNavigation).ToListAsync();

                var examenesDTO = _mapper.Map<List<TblExamenes>, List<ExamenesDTO>>(examenes);
                return examenesDTO;
            }
        }
    }
}
