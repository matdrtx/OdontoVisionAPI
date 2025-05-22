using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoVision.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnosticos_Pacientes_PacienteId",
                table: "Diagnosticos");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Pacientes_PacienteId",
                table: "Procedimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedimentos",
                table: "Procedimentos");

            migrationBuilder.DropIndex(
                name: "IX_Procedimentos_PacienteId",
                table: "Procedimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diagnosticos",
                table: "Diagnosticos");

            migrationBuilder.DropIndex(
                name: "IX_Diagnosticos_PacienteId",
                table: "Diagnosticos");

            migrationBuilder.DropColumn(
                name: "DataProcedimento",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Procedimentos");

            migrationBuilder.RenameTable(
                name: "Procedimentos",
                newName: "PROCEDIMENTOS");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                newName: "PACIENTES");

            migrationBuilder.RenameTable(
                name: "Diagnosticos",
                newName: "DIAGNOSTICOS");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PROCEDIMENTOS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "PACIENTES",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "PACIENTES",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PACIENTES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "PACIENTES",
                newName: "DATA_NASCIMENTO");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "DIAGNOSTICOS",
                newName: "DESCRICAO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DIAGNOSTICOS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DataDiagnostico",
                table: "DIAGNOSTICOS",
                newName: "Data");

            migrationBuilder.AlterColumn<decimal>(
                name: "Custo",
                table: "PROCEDIMENTOS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO",
                table: "PROCEDIMENTOS",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "DIAGNOSTICOS",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddColumn<int>(
                name: "DentistaId",
                table: "DIAGNOSTICOS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PROCEDIMENTOS",
                table: "PROCEDIMENTOS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PACIENTES",
                table: "PACIENTES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DIAGNOSTICOS",
                table: "DIAGNOSTICOS",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "DENTISTAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ESPECIALIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENTISTAS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DENTISTAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PROCEDIMENTOS",
                table: "PROCEDIMENTOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PACIENTES",
                table: "PACIENTES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DIAGNOSTICOS",
                table: "DIAGNOSTICOS");

            migrationBuilder.DropColumn(
                name: "DESCRICAO",
                table: "PROCEDIMENTOS");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "PACIENTES");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "PACIENTES");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "PACIENTES");

            migrationBuilder.DropColumn(
                name: "DentistaId",
                table: "DIAGNOSTICOS");

            migrationBuilder.RenameTable(
                name: "PROCEDIMENTOS",
                newName: "Procedimentos");

            migrationBuilder.RenameTable(
                name: "PACIENTES",
                newName: "Pacientes");

            migrationBuilder.RenameTable(
                name: "DIAGNOSTICOS",
                newName: "Diagnosticos");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Procedimentos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "Pacientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Pacientes",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Pacientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DATA_NASCIMENTO",
                table: "Pacientes",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "DESCRICAO",
                table: "Diagnosticos",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Diagnosticos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Diagnosticos",
                newName: "DataDiagnostico");

            migrationBuilder.AlterColumn<decimal>(
                name: "Custo",
                table: "Procedimentos",
                type: "DECIMAL(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProcedimento",
                table: "Procedimentos",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Procedimentos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Procedimentos",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pacientes",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Pacientes",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Diagnosticos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedimentos",
                table: "Procedimentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diagnosticos",
                table: "Diagnosticos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_PacienteId",
                table: "Procedimentos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_PacienteId",
                table: "Diagnosticos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnosticos_Pacientes_PacienteId",
                table: "Diagnosticos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Pacientes_PacienteId",
                table: "Procedimentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
