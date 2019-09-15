using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using InsuranceManager.Models;
using InsuranceManager.Dtos;
using InsuranceManager.Domain;
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
            Mapper.CreateMap<Coverage, CoverageDto>();
            Mapper.CreateMap<CoverageByPolicy, CoverageByPolicyDto>();

            Mapper.CreateMap<Policy, PolicyDto>();


            //Dto to Domain
            Mapper.CreateMap<PolicyDto, Policy>()
                .ForMember(p => p.Id, opt => opt.Ignore());
            Mapper.CreateMap<CoverageByPolicyDto, CoverageByPolicy>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}