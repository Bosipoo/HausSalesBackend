using AutoMapper;
using HausSalesBackend.Models.DTOs;
using HausSalesBackend.Models;

namespace HausSalesBackend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GLedgerDto, GeneralLedger>();
            CreateMap<PropertyDto, Property>();
        }
    }
}
