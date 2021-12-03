using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using Dominio.Model;
using MediatR;
using Persistencia;

namespace Aplicacion.Medico
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTblMedico { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public Guid IdtblCatSucursales { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime? FechaModificacion { get; set; }
            public DateTime? FechaEliminacion { get; set; }
            public Guid IdDepartamentoNac { get; set; }
            public Guid IdDepartamentoRes { get; set; }
            public Guid IdPaisNac { get; set; }
            public Guid IdPaisRes { get; set; }
            public Guid IdIdentificacion { get; set; }
            public Guid IdEstadoCivil { get; set; }
            public Guid IdSexo { get; set; }
            public string NumIdentificacion { get; set; }
            public string CodMinsa { get; set; }
            public DateTime FechaNac { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string UrlFoto { get; set; }
            public int Estado { get; set; }
        }

        /*public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
            }
        }
*/
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;

            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var medico = await _context.TblMedicos.FindAsync(request.IdTblMedico);
                if (medico == null)
                {
                    throw new Exception("El medico no existe");
                }

                medico.Nombres = request.Nombres ?? medico.Nombres;
                medico.Apellidos = request.Apellidos ?? medico.Apellidos;
                medico.CodMinsa = request.CodMinsa ?? medico.CodMinsa;
                medico.FechaCreacion = (request.FechaCreacion != null || request.FechaCreacion != DateTime.MinValue) ? request.FechaCreacion : medico.FechaCreacion;
                medico.FechaModificacion = (request.FechaModificacion != null || request.FechaModificacion != DateTime.MinValue) ? request.FechaModificacion : medico.FechaModificacion;
                medico.FechaEliminacion = (request.FechaEliminacion != null || request.FechaEliminacion != DateTime.MinValue) ? request.FechaEliminacion : medico.FechaEliminacion;
                medico.FechaNac = (request.FechaNac != null || request.FechaNac != DateTime.MinValue) ? request.FechaNac : medico.FechaNac;
                medico.NumIdentificacion = request.NumIdentificacion ?? medico.NumIdentificacion;
                medico.Email = request.Email ?? medico.Email;
                medico.Telefono = request.Telefono ?? medico.Telefono;
                medico.UrlFoto = request.UrlFoto ?? medico.UrlFoto;
                medico.IdtblCatSucursales = (request.IdtblCatSucursales != null || request.IdtblCatSucursales != Guid.Empty) ? request.IdtblCatSucursales : medico.IdtblCatSucursales;
                medico.IdDepartamentoNac = (request.IdDepartamentoNac != null || request.IdDepartamentoNac != Guid.Empty) ? request.IdDepartamentoNac : medico.IdDepartamentoNac;
                medico.IdDepartamentoRes = (request.IdDepartamentoRes != null || request.IdDepartamentoRes != Guid.Empty) ? request.IdDepartamentoRes : medico.IdDepartamentoRes;
                medico.IdPaisNac = (request.IdPaisNac != null || request.IdPaisNac != Guid.Empty) ? request.IdPaisNac : medico.IdPaisNac;
                medico.IdPaisRes = (request.IdPaisRes != null || request.IdPaisRes != Guid.Empty) ? request.IdPaisRes : medico.IdPaisRes;
                medico.IdIdentificacion = (request.IdIdentificacion != null || request.IdIdentificacion != Guid.Empty) ? request.IdIdentificacion : medico.IdIdentificacion;
                medico.IdEstadoCivil = (request.IdEstadoCivil != null || request.IdEstadoCivil != Guid.Empty) ? request.IdEstadoCivil : medico.IdEstadoCivil;
                medico.IdSexo = (request.IdSexo != null || request.IdSexo != Guid.Empty) ? request.IdSexo : medico.IdSexo;
                medico.Estado = request.Estado != 0 ? request.Estado : medico.Estado;
                
                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el medico");
            }
        }
    }
}
