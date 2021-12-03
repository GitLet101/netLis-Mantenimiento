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

namespace Aplicacion.Paciente
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdPaciente { get; set; }
            public Guid IdIdentificacion { get; set; }
            public string NumIdentificacion { get; set; }
            public string NumInss { get; set; }
            public Guid IdEstadoCivil { get; set; }
            public string Email { get; set; }
            public Guid IdSexo { get; set; }
            public Guid IdPaisNac { get; set; }
            public Guid IdDepartamentoNac { get; set; }
            public Guid IdPaisRes { get; set; }
            public Guid IdDepartamentoRes { get; set; }
            public Guid IdTipoSangre { get; set; }
            public Guid IdProfesiones { get; set; }
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public DateTime FechaNac { get; set; }
            public string DireccionDomiciliar { get; set; }
            public string TelefonoDomiciliar { get; set; }
            public string TelefonoMovil { get; set; }
            public Guid Religion { get; set; }
            public string Activo { get; set; }
            public string Emabrazada { get; set; }
            public string Fallecido { get; set; }
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
                var Paciente = await _context.TblPacientes.FindAsync(request.IdPaciente);
                if (Paciente == null)
                {
                    throw new Exception("El paciente no existe");
                }
                DateTime date = request.FechaNac;

                Paciente.IdIdentificacion = (request.IdIdentificacion != null || request.IdIdentificacion != Guid.Empty) 
                    ? request.IdIdentificacion : Paciente.IdIdentificacion;
                Paciente.NumIdentificacion = request.NumIdentificacion ?? Paciente.NumIdentificacion;
                Paciente.NumInss = request.NumInss ?? Paciente.NumInss;
                Paciente.IdEstadoCivil = (request.IdEstadoCivil != null || request.IdEstadoCivil != Guid.Empty) ? request.IdEstadoCivil : Paciente.IdEstadoCivil;
                Paciente.IdSexo = (request.IdSexo != null || request.IdSexo != Guid.Empty) ? request.IdSexo : Paciente.IdSexo;
                Paciente.IdPaisNac = (request.IdPaisNac != null || request.IdPaisNac != Guid.Empty) ? request.IdPaisNac : Paciente.IdPaisNac;
                Paciente.IdDepartamentoNac = (request.IdDepartamentoNac != null || request.IdDepartamentoNac != Guid.Empty) ? request.IdDepartamentoNac : Paciente.IdDepartamentoNac;
                Paciente.IdPaisRes = (request.IdPaisRes != null || request.IdPaisRes != Guid.Empty) ? request.IdPaisRes : Paciente.IdPaisRes;
                Paciente.IdDepartamentoRes = (request.IdDepartamentoRes != null || request.IdDepartamentoRes != Guid.Empty) ? request.IdDepartamentoRes : Paciente.IdDepartamentoRes;
                Paciente.IdTipoSangre = (request.IdTipoSangre != null || request.IdTipoSangre != Guid.Empty) ? request.IdTipoSangre : Paciente.IdTipoSangre;
                Paciente.IdProfesiones = (request.IdProfesiones != null || request.IdProfesiones != Guid.Empty) ? request.IdProfesiones : Paciente.IdProfesiones;
                Paciente.PrimerNombre = request.PrimerNombre ?? Paciente.PrimerNombre;
                Paciente.SegundoNombre = request.SegundoNombre ?? Paciente.SegundoNombre;
                Paciente.PrimerApellido = request.PrimerApellido ?? Paciente.PrimerApellido;
                Paciente.SegundoApellido = request.SegundoApellido ?? Paciente.SegundoApellido;
                Paciente.FechaNac = date != DateTime.MinValue ? date : Paciente.FechaNac;
                Paciente.DireccionDomiciliar = request.DireccionDomiciliar ?? Paciente.DireccionDomiciliar;
                Paciente.TelefonoDomiciliar = request.TelefonoDomiciliar ?? Paciente.TelefonoDomiciliar;
                Paciente.TelefonoMovil = request.TelefonoMovil ?? Paciente.TelefonoMovil;
                Paciente.Religion = (request.Religion != null || request.Religion != Guid.Empty) ? request.Religion : Paciente.Religion;
                Paciente.Activo = request.Activo ?? Paciente.Activo;
                Paciente.Emabrazada = request.Emabrazada ?? Paciente.Emabrazada;
                Paciente.Fallecido = request.Fallecido ?? Paciente.Fallecido;
                Paciente.Estado = request.Estado != 0 ? request.Estado : Paciente.Estado;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el paciente");
            }
        }
    }
}
