using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "Pending");

            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "Decline");

            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "Approved");

            migrationBuilder.RenameColumn(
                name: "RequestPhase",
                table: "Pending",
                newName: "ReimbursementType");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Pending",
                newName: "EmployeeMail");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Decline",
                newName: "ReimbursementType");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Approved",
                newName: "ReimbursementType");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeMail",
                table: "Reimbursement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reciept",
                table: "Reimbursement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Pending",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Pending",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "RequestedValue",
                table: "Pending",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Decline",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Decline",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeMail",
                table: "Decline",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "RequestedValue",
                table: "Decline",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Approved",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ApprovedValue",
                table: "Approved",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Approved",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Approved",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeMail",
                table: "Approved",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "RequestedValue",
                table: "Approved",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeMail",
                table: "Reimbursement");

            migrationBuilder.DropColumn(
                name: "Reciept",
                table: "Reimbursement");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Pending");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Pending");

            migrationBuilder.DropColumn(
                name: "RequestedValue",
                table: "Pending");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Decline");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Decline");

            migrationBuilder.DropColumn(
                name: "EmployeeMail",
                table: "Decline");

            migrationBuilder.DropColumn(
                name: "RequestedValue",
                table: "Decline");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Approved");

            migrationBuilder.DropColumn(
                name: "ApprovedValue",
                table: "Approved");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Approved");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Approved");

            migrationBuilder.DropColumn(
                name: "EmployeeMail",
                table: "Approved");

            migrationBuilder.DropColumn(
                name: "RequestedValue",
                table: "Approved");

            migrationBuilder.RenameColumn(
                name: "ReimbursementType",
                table: "Pending",
                newName: "RequestPhase");

            migrationBuilder.RenameColumn(
                name: "EmployeeMail",
                table: "Pending",
                newName: "EmployeeID");

            migrationBuilder.RenameColumn(
                name: "ReimbursementType",
                table: "Decline",
                newName: "EmployeeID");

            migrationBuilder.RenameColumn(
                name: "ReimbursementType",
                table: "Approved",
                newName: "EmployeeID");

            migrationBuilder.AddColumn<int>(
                name: "ClaimId",
                table: "Pending",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClaimId",
                table: "Decline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClaimId",
                table: "Approved",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
