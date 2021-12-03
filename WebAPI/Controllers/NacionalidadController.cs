using Aplicacion.Nacionalidad;
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
    public class NacionalidadController : MiControllerBase
    {
        private readonly IMediator _mediator;
        public NacionalidadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<TblCatNacionalidad>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatNacionalidad>> Detalle(Guid id)
        {
            return await _mediator.Send(new ConsultaId.NacionalidadUnico { Id = id });
        }
    }
}
