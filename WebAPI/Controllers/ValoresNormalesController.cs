using Aplicacion.ValoresNormales;
using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoresNormalesController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatValoresNormales>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }
    }
}
