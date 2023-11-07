using FluentMigrator;
using Nop.Core.Domain.Customers;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.Development
{
    [NopMigration("2023-10-07 13:07:00", "Add Zohold Field to customer table", MigrationProcessType.Update)]
    public class AddCustomerZoholdFieldMigration : Migration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            var tableName = NameCompatibilityManager.GetTableName(typeof(Customer));
            var columnName = nameof(Customer.Zohold);

            if (Schema.Table(tableName).Exists() && !Schema.Table(tableName).Column(columnName).Exists())
            {
                Alter.Table(tableName).AddColumn(columnName).AsString().Nullable();
            }
        }

        public override void Down()
        {
            var tableName = NameCompatibilityManager.GetTableName(typeof(Customer));
            var columnName = nameof(Customer.Zohold);


            if (Schema.Table(tableName).Exists() && Schema.Table(tableName).Column(columnName).Exists())
            {
                Delete.Column(columnName).FromTable(tableName);
            }
        }
    }
}
