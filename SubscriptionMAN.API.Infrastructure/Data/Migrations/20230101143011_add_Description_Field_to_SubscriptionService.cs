using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriptionMAN.API.Infrastructure.Data.Migrations
{
    public partial class add_Description_Field_to_SubscriptionService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SubscriptionServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SubscriptionServices");
        }
    }
}
