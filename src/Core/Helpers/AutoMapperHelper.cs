using AutoMapper;
using CloudNDevOps.TerraformAgentDbor.Contracts;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables;
using System;

namespace CloudNDevOps.TerraformAgentDbor.Core
{
    /// <summary>
    /// Houses all helper functions related to AutoMapper
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        /// Creates new Instance of <see cref="IMapper"/> and configures Mappings
        /// </summary>
        /// <returns>Instance of <see cref="IMapper"/></returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<TableDto, TableDefinition>()
                    .ForMember(dest => dest.Columns, opt => opt.Ignore());
                cfg.CreateMap<ColumnDto, VarChar2ColumnDefinition>()
                    .ForMember(dest => dest.MaximumLength, opt => opt.MapFrom(src => src.CharLength))
                    .ForMember(dest => dest.MaximumLengthUnit, opt => opt.MapFrom(src => LenghtUnits.Char));
                cfg.CreateMap<ColumnDto, NVarChar2ColumnDefinition>()
                    .ForMember(dest => dest.MaximumLength, opt => opt.MapFrom(src => src.CharLength))
                    .ForMember(dest => dest.MaximumLengthUnit, opt => opt.MapFrom(src => LenghtUnits.Char));
                cfg.CreateMap<ColumnDto, NumberColumnDefinition>();
                cfg.CreateMap<ColumnDto, DateColumnDefinition>();
                cfg.CreateMap<ColumnDto, RawColumnDefinition>()
                    .ForMember(dest => dest.MaximumLength, opt => opt.MapFrom(src => src.Length));
                cfg.CreateMap<ColumnDto, CharColumnDefinition>()
                    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.CharLength))
                    .ForMember(dest => dest.LengthUnit, opt => opt.MapFrom(src => LenghtUnits.Char));
                cfg.CreateMap<ColumnDto, NCharColumnDefinition>()
                    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.CharLength))
                    .ForMember(dest => dest.LengthUnit, opt => opt.MapFrom(src => LenghtUnits.Char));
                cfg.CreateMap<ColumnDto, ClobColumnDefinition>();
                cfg.CreateMap<ColumnDto, NClobColumnDefinition>();              
            });
#if DEBUG
            var plan = config.BuildExecutionPlan(typeof(TableDto), typeof(TableDefinition));
#endif
            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
