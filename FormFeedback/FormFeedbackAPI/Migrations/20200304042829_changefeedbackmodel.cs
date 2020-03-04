using Microsoft.EntityFrameworkCore.Migrations;

namespace FormFeedbackAPI.Migrations
{
    public partial class changefeedbackmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "TB_T_Feedback",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Feedback_EventId",
                table: "TB_T_Feedback",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_T_Events_EventId",
                table: "TB_T_Feedback",
                column: "EventId",
                principalTable: "TB_T_Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_T_Events_EventId",
                table: "TB_T_Feedback");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Feedback_EventId",
                table: "TB_T_Feedback");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "TB_T_Feedback");
        }
    }
}
