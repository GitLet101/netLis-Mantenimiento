﻿using Aplicacion.Departamento;
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
    public class DepartamentoController : MiControllerBase
    {
        private readonly IMediator _mediator;
        public DepartamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<TblCatDepartamento>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatDepartamento>> Detalle(Guid id)
        {
            return await _mediator.Send(new ConsultaId.DepartamentoUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data)
        {
            data.IdDepartamento = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> EliminarDepartamento(Guid id)
        {
            return await Mediator.Send(new Eliminar.Ejecuta { Id = id });
        }
    }
}
