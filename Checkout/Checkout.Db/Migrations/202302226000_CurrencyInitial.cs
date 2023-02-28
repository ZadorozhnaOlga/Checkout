using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Db.Migrations
{
    public class _202302272000_CurrencyInitial : MigrationBase
    {
        internal override string TableName => "Currency";
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: TableName,
                columns: table => new
                {
                    CurrencyId = table.Column<int>().Annotation("SqlServer: Identity", "1, 1"),
                    CurrencyName = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            InsertAvailableCurrencies(migrationBuilder);
        }

        private void InsertAvailableCurrencies(MigrationBuilder migrationBuilder) {
            migrationBuilder.InsertData(TableName, new[] { "CurrencyId", "CurrencyName" }, new object[] { 1, "GBP" });
            migrationBuilder.InsertData(TableName, new[] { "CurrencyId", "CurrencyName" }, new object[] { 2, "USD" });
            migrationBuilder.InsertData(TableName, new[] { "CurrencyId", "CurrencyName" }, new object[] { 3, "EUR" });
        }
    }
}
