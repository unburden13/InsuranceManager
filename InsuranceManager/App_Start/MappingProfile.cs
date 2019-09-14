using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsuranceManager.Models;
using InsuranceManager.Dtos;
using AutoMapper;

namespace InsuranceManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Policy, PolicyDto>();
            Mapper.CreateMap<TypeOfRisk, TypeOfRiskDto>();

            //Dto to Domain
            Mapper.CreateMap<PolicyDto, Policy>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}