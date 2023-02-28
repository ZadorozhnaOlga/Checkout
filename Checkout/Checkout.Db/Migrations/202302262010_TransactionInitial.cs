using Checkout.Db.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Db.Migrations
{
    public class _202302262010_TransactionInitial : MigrationBase
    {
        internal override string TableName => "Transaction";
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: TableName,
                columns: table => new
                {
                    TransactionId = table.Column<int>().Annotation("SqlServer: Identity", "1, 1"),
                    Created = table.Column<DateTime>(),
                    Amount = table.Column<float>(),
                    Status = table.Column<string>(),
                    CurrencyId = table.Column<int>(),
                    CardDetailsId = table.Column<int>(),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_CardDetails_CardId",
                        column: x => x.CardDetailsId,
                        principalTable: "CardDetails",
                        principalColumn: "CardDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
