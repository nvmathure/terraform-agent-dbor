using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Linq;

namespace CloudNDevOps.TerraformAgentDbor.Contracts.UnitTests.SerializationTests
{
    [TestClass]
    public class SerializationUnitTests
    {
        [TestMethod]
        public void MinimumTableTest()
        {
            var input = JsonResources.MinimumTable;

            // Act
            var table = input.ToTable();

            // Assert
            table.Should().NotBeNull();
            table.Should().BeOfType(typeof(TableDefinition));
            table.Name.Should().Be("Employees");
            table.Owner.Should().BeNullOrEmpty();
            table.Columns.Should().NotBeNull();
            table.Columns.Should().ContainSingle();
            var column = table.Columns.First();
            column.Should().NotBeNull();
            column.Should().BeOfType(typeof(RawColumnDefinition));
            column.Name.Should().Be("EmployeeId");
            column.DataType.Should().Be(DataTypes.Raw);
            ((RawColumnDefinition)column).MaximumLength.Should().Be(16);
        }
    }
}
