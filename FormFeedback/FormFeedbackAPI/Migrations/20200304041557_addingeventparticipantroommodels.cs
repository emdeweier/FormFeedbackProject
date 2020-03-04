using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormFeedbackAPI.Migrations
{
    public partial class addingeventparticipantroommodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "TB_T_Feedback",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_M_Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    PresentatorId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_Events_TB_M_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "TB_M_Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Participant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Participant_TB_T_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "TB_T_Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Feedback_ParticipantId",
                table: "TB_T_Feedback",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Participant_EventId",
                table: "TB_M_Participant",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Events_RoomId",
                table: "TB_T_Events",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Participant_ParticipantId",
                table: "TB_T_Feedback",
                column: "ParticipantId",
                principalTable: "TB_M_Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Participant_ParticipantId",
                table: "TB_T_Feedback");

            migrationBuilder.DropTable(
                name: "TB_M_Participant");

            migrationBuilder.DropTable(
                name: "TB_T_Events");

            migrationBuilder.DropTable(
                name: "TB_M_Room");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Feedback_ParticipantId",
                table: "TB_T_Feedback");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "TB_T_Feedback");
        }
    }
}
