using AutoMapper;
using CloudNDevOps.TerraformAgentDbor.Contracts;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables;
using System;

namespace CloudNDevOps.TerraformAgentDbor.Core
{
    internal static class ColumnMapperHelper
    {
        public static ColumnDefinition ToColumnDefinition(this ColumnDto columnDto, IMapper mapper)
        {
            if (!Enum.TryParse<DataTypes>(columnDto.DataType, true, out var dataType))
                throw new NotSupportedException($"Data Type {columnDto.DataType} is not supported in {nameof(ColumnMapperHelper)}::{nameof(ToColumnDefinition)}");

            switch (dataType)
            {
                case DataTypes.VarChar2:
                    return mapper.Map<VarChar2ColumnDefinition>(columnDto);
                case DataTypes.NVarChar2:
                    return mapper.Map<NVarChar2ColumnDefinition>(columnDto);
                case DataTypes.Number:
                    return mapper.Map<NumberColumnDefinition>(columnDto);
                case DataTypes.Date:
                    return mapper.Map<DateColumnDefinition>(columnDto);
                case DataTypes.Raw:
                    return mapper.Map<RawColumnDefinition>(columnDto);
                case DataTypes.Char:
                    return mapper.Map<CharColumnDefinition>(columnDto);
                case DataTypes.NChar:
                    return mapper.Map<NCharColumnDefinition>(columnDto);
                case DataTypes.Clob:
                    return mapper.Map<ClobColumnDefinition>(columnDto);
                case DataTypes.NClob:
                    return mapper.Map<NClobColumnDefinition>(columnDto);
                default:
                    throw new NotSupportedException($"Data Type {dataType} is not supported in {nameof(ColumnMapperHelper)}::{nameof(ToColumnDefinition)}");
            }
        }
    }
}
