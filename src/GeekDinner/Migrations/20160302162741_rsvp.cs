using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace GeekDinner.Migrations
{
    public partial class rsvp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rsvp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DinnerId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsWaitlist = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rsvp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rsvp_Dinner_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<int>(
                name: "MaxAttendees",
                table: "Dinner",
                nullable: true);
            migrationBuilder.AddColumn<TimeSpan>(
                name: "RsvpDeadline",
                table: "Dinner",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "MaxAttendees", table: "Dinner");
            migrationBuilder.DropColumn(name: "RsvpDeadline", table: "Dinner");
            migrationBuilder.DropTable("Rsvp");
        }
    }
}
