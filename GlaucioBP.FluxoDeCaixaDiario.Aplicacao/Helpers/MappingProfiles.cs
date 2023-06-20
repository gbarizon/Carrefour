using AutoMapper;
using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.DTOs;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Lancamento, LancamentoDTO>().ReverseMap()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => (src.Data.Date)));
        }
    }
}
