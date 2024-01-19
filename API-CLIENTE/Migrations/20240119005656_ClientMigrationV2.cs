using Microsoft.EntityFrameworkCore.Migrations;

namespace API_CLIENTE.Migrations
{
    public partial class ClientMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Contatos_ContatosId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Enderecos_EnderecosId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enderecos",
                newName: "EnderecoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contatos",
                newName: "ContatoID");

            migrationBuilder.RenameColumn(
                name: "EnderecosId",
                table: "Cliente",
                newName: "EnderecosEnderecoID");

            migrationBuilder.RenameColumn(
                name: "ContatosId",
                table: "Cliente",
                newName: "ContatosContatoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cliente",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_EnderecosId",
                table: "Cliente",
                newName: "IX_Cliente_EnderecosEnderecoID");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_ContatosId",
                table: "Cliente",
                newName: "IX_Cliente_ContatosContatoID");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Enderecos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DDD",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Contatos_ContatosContatoID",
                table: "Cliente",
                column: "ContatosContatoID",
                principalTable: "Contatos",
                principalColumn: "ContatoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Enderecos_EnderecosEnderecoID",
                table: "Cliente",
                column: "EnderecosEnderecoID",
                principalTable: "Enderecos",
                principalColumn: "EnderecoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Contatos_ContatosContatoID",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Enderecos_EnderecosEnderecoID",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "EnderecoID",
                table: "Enderecos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContatoID",
                table: "Contatos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EnderecosEnderecoID",
                table: "Cliente",
                newName: "EnderecosId");

            migrationBuilder.RenameColumn(
                name: "ContatosContatoID",
                table: "Cliente",
                newName: "ContatosId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Cliente",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_EnderecosEnderecoID",
                table: "Cliente",
                newName: "IX_Cliente_EnderecosId");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_ContatosContatoID",
                table: "Cliente",
                newName: "IX_Cliente_ContatosId");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "DDD",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Contatos_ContatosId",
                table: "Cliente",
                column: "ContatosId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Enderecos_EnderecosId",
                table: "Cliente",
                column: "EnderecosId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
