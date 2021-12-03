using Aplicacion.CategoriaExamenes;
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
    public class CategoriaExamenesController : MiControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriaExamenesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<TblCatCategoriaExamenes>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatCategoriaExamenes>> Detalle(Guid id)
        {
            return await _mediator.Send(new ConsultaId.CategoriaExamenesUnico { Id = id });
        }
    }
}
