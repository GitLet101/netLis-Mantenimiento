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
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdIdentificacion { get; set; }
            public string NumIdentificacion { get; set; }
            public string NumInss { get; set; }
            public Guid IdEstadoCivil { get; set; }
            public string Email { get; set; }
            public Guid IdSexo { get; set; }
            public Guid PaisNac { get; set; }
            public Guid DepartamentoNac { get; set; }
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
        }*/

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _pacienteid = Guid.NewGuid();
                Debug.WriteLine(_pacienteid);
                var pais = new TblPaciente
                {
                    IdPaciente = _pacienteid,
                    IdIdentificacion = request.IdIdentificacion,
                    NumIdentificacion = request.NumIdentificacion,
                    NumInss = request.NumInss,
                    IdEstadoCivil = request.IdEstadoCivil,
                    Email = request.Email,
                    IdSexo = request.IdSexo,
                    IdPaisNac = request.PaisNac,
                    IdDepartamentoNac = request.DepartamentoNac,
                    IdPaisRes = request.IdPaisRes,
                    IdDepartamentoRes = request.IdDepartamentoRes,
                    IdTipoSangre = request.IdTipoSangre,
                    IdProfesiones = request.IdProfesiones,
                    PrimerNombre = request.PrimerNombre,
                    SegundoNombre = request.SegundoNombre,
                    PrimerApellido = request.PrimerApellido,
                    SegundoApellido = request.SegundoApellido,
                    FechaNac = request.FechaNac,
                    DireccionDomiciliar = request.DireccionDomiciliar,
                    TelefonoDomiciliar = request.TelefonoDomiciliar,
                    TelefonoMovil = request.TelefonoMovil,
                    Religion = request.Religion,
                    Activo = request.Activo,
                    Emabrazada = request.Emabrazada,
                    Fallecido = request.Fallecido,
                    Estado = request.Estado

                };

                _context.TblPacientes.Add(pais);

                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el pais");
            }
        }
    }
}
