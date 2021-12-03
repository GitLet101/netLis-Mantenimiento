using Aplicacion.UnidadesMedidas;
using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidasController : MiControllerBase
    {
        private readonly IMediator _mediator;
        public UnidadesMedidasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<TblCatUnidadMedida>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatUnidadMedida>> Detalle(Guid id)
        {
            return await _mediator.Send(new ConsultaId.UnidadesMedidasUnico { Id = id });
        }
    }
}
