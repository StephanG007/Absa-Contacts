using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Absa.API.Migrations
{
  public partial class CreateUserTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Contacts",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            FirstName = table.Column<string>(nullable: true),
            LastName = table.Column<string>(nullable: true),
            DateOfBirth = table.Column<DateTime>(nullable: false),
            Gender = table.Column<string>(nullable: true),
            Email = table.Column<string>(nullable: true),
            Phone = table.Column<string>(nullable: true),
            Address = table.Column<string>(nullable: true),
            PhotoUrl = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Contacts", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Contacts");
    }
  }
}