using Aplicacion.Examenes;
using Aplicacion.Perfil;
using AutoMapper;
using Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblExamenes, ExamenesDTO>()
                .ForMember(x=> x.Perfil, y => y.MapFrom(z => z.TblCatPerfilesExamenesLink.Select(a => a.IdPerfilesNavigation).ToList()));
            CreateMap<TblCatPerfiles, PerfilesDTO>();
            CreateMap<TblCatPerfilesExamenes, PerfilExamenDTO>();
        }
    }
}
