﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.ValoresNormales
{
    public class ConsultaId
    {
        public class ValoresNormalesUnico : IRequest<TblCatValoresNormales>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ValoresNormalesUnico, TblCatValoresNormales>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatValoresNormales> Handle(ValoresNormalesUnico request, CancellationToken cancellationToken)
            {
                var consulta = await _context.TblCatValoresNormales.FindAsync(request.Id);
                return consulta;
            }
        }
    }
}
