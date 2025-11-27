using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using PortalAcademico.Aplicacao.ViewModels;
using PortalAcademico.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Aplicacao.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.NewConfig<Aluno, AlunoViewModel>()
                .Map(dest => dest.TurmaNome, src => src.Turma != null ? src.Turma.Nome : null);

            TypeAdapterConfig.GlobalSettings.NewConfig<AlunoViewModel, Aluno>();
            TypeAdapterConfig.GlobalSettings.NewConfig<Turma, TurmaViewModel>();
            TypeAdapterConfig.GlobalSettings.NewConfig<TurmaViewModel, Turma>();
        }
    }


}
