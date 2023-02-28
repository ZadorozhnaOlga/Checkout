using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Db.Migrations
{
    public class _202302262030_CardDetailsInitial : MigrationBase
    {
        internal override string TableName => "CardDetails";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: TableName,
                columns: table => new
                {
                    CardDetailsId = table.Column<int>()
                        .Annotation("SqlServer: Identity", "1, 1"),
                    CardNumber = table.Column<string>(),
                    Cvv = table.Column<string>(),
                    AccountName = table.Column<string>(),
                    ExpiryDay = table.Column<string>(),
                    ExpiryMonth = table.Column<string>(),
                    ExpiryYear = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.CardDetailsId);
                });
        }
    }
}
