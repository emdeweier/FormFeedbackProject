using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormFeedbackAPI.Migrations
{
    public partial class changequestionmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Questions_TB_M_Options_OptionId",
                table: "TB_M_Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_R_Reports_TB_T_Feedback_FeedbackId",
                table: "TB_R_Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Points_PointId",
                table: "TB_T_Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Questions_QuestionId",
                table: "TB_T_Feedback");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Questions_OptionId",
                table: "TB_M_Questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "TB_T_Feedback",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PointId",
                table: "TB_T_Feedback",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_T_Feedback",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "FeedbackId",
                table: "TB_R_Reports",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_R_Reports",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "OptionId",
                table: "TB_M_Questions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_M_Questions",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_M_Points",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_M_Options",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_R_Reports_TB_T_Feedback_FeedbackId",
                table: "TB_R_Reports",
                column: "FeedbackId",
                principalTable: "TB_T_Feedback",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Points_PointId",
                table: "TB_T_Feedback",
                column: "PointId",
                principalTable: "TB_M_Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Questions_QuestionId",
                table: "TB_T_Feedback",
                column: "QuestionId",
                principalTable: "TB_M_Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_R_Reports_TB_T_Feedback_FeedbackId",
                table: "TB_R_Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Points_PointId",
                table: "TB_T_Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Questions_QuestionId",
                table: "TB_T_Feedback");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionId",
                table: "TB_T_Feedback",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PointId",
                table: "TB_T_Feedback",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TB_T_Feedback",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "FeedbackId",
                table: "TB_R_Reports",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TB_R_Reports",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "OptionId",
                table: "TB_M_Questions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TB_M_Questions",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TB_M_Points",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TB_M_Options",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Questions_OptionId",
                table: "TB_M_Questions",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Questions_TB_M_Options_OptionId",
                table: "TB_M_Questions",
                column: "OptionId",
                principalTable: "TB_M_Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_R_Reports_TB_T_Feedback_FeedbackId",
                table: "TB_R_Reports",
                column: "FeedbackId",
                principalTable: "TB_T_Feedback",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Points_PointId",
                table: "TB_T_Feedback",
                column: "PointId",
                principalTable: "TB_M_Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Questions_QuestionId",
                table: "TB_T_Feedback",
                column: "QuestionId",
                principalTable: "TB_M_Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
