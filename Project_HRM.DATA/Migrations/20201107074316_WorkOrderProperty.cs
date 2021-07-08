using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_HRM.DATA.Migrations
{
    public partial class WorkOrderProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsActiveId",
                table: "WorkOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_IsActiveId",
                table: "WorkOrders",
                column: "IsActiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_AspNetUsers_IsActiveId",
                table: "WorkOrders",
                column: "IsActiveId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_AspNetUsers_IsActiveId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_IsActiveId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "IsActiveId",
                table: "WorkOrders");
        }
    }
}
