using CloudNDevOps.Newtonsoft.Extensions;
using System;
using System.Collections.Generic;

namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Factory Class for creating Newtonsoft Converters related to Contracts
    /// </summary>
    public static class ConverterFactory
    {
        /// <summary>
        /// Creates new <see cref="TypeFamilyConverter{TBase, TBaseClassifier}"/> for <see cref="ColumnDefinition"/>
        /// </summary>
        /// <returns>Instance of <see cref="TypeFamilyConverter{TBase, TBaseClassifier}"/></returns>
        public static TypeFamilyConverter<ColumnDefinition, DataTypes> CreateColumnDefinitionConverter()
        {
            return new TypeFamilyConverter<ColumnDefinition, DataTypes>(
                new Func<ColumnDefinition, DataTypes>(cd => cd.DataType),
                new Dictionary<DataTypes, Type>
                {
                    { DataTypes.VarChar2, typeof(VarChar2ColumnDefinition) },
                    { DataTypes.NVarChar2, typeof(NVarChar2ColumnDefinition) },
                    { DataTypes.Number, typeof(NumberColumnDefinition) },
                    { DataTypes.Date, typeof(DateColumnDefinition) },
                    { DataTypes.Raw, typeof(RawColumnDefinition) },
                    { DataTypes.Char, typeof(CharColumnDefinition) },
                    { DataTypes.NChar, typeof(NCharColumnDefinition) },
                    { DataTypes.Clob, typeof(ClobColumnDefinition) },
                    { DataTypes.NClob, typeof(NClobColumnDefinition) },
                });
        }
    }
}
