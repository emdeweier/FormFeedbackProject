using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormFeedbackAPI.Migrations
{
    public partial class addingctorquestionmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "TB_T_Feedback",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDate",
                table: "TB_T_Feedback",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TB_T_Feedback",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "TB_T_Feedback",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "TB_R_Reports",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDate",
                table: "TB_R_Reports",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TB_R_Reports",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "TB_R_Reports",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "TB_M_Questions",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDate",
                table: "TB_M_Questions",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TB_M_Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "TB_M_Questions",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "TB_M_Points",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDate",
                table: "TB_M_Points",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TB_M_Points",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "TB_M_Points",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "TB_M_Options",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDate",
                table: "TB_M_Options",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TB_M_Options",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "TB_M_Options",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TB_T_Feedback");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TB_T_Feedback");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TB_T_Feedback");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TB_T_Feedback");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TB_R_Reports");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TB_R_Reports");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TB_R_Reports");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TB_R_Reports");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TB_M_Questions");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TB_M_Questions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TB_M_Questions");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TB_M_Questions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TB_M_Points");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TB_M_Points");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TB_M_Points");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TB_M_Points");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TB_M_Options");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TB_M_Options");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TB_M_Options");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TB_M_Options");

            migrationBuilder.RenameColumn(
                name: "Q_Name",
                table: "TB_M_Questions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "O_Name",
                table: "TB_M_Options",
                newName: "Name");
        }
    }
}
