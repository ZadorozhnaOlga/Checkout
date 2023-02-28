using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.Db.Migrations
{
   public abstract class MigrationBase : Migration
    {
        abstract internal string TableName { get; }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(TableName);
        }
    }
}
