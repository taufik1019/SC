using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileMahasiswas",
                columns: table => new
                {
                    ProfileMahasiswaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    Prodi = table.Column<string>(nullable: true),
                    Semester = table.Column<int>(nullable: false),
                    TanggalLahir = table.Column<DateTime>(nullable: false),
                    Alamat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileMahasiswas", x => x.ProfileMahasiswaId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Respons",
                columns: table => new
                {
                    ResponId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TanggalRespon = table.Column<DateTime>(nullable: false),
                    ResponKeluhan = table.Column<string>(nullable: true),
                    KeluhanId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respons", x => x.ResponId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ProfileMahasiswaId = table.Column<int>(nullable: true),
                    User = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_ProfileMahasiswas_ProfileMahasiswaId",
                        column: x => x.ProfileMahasiswaId,
                        principalTable: "ProfileMahasiswas",
                        principalColumn: "ProfileMahasiswaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Respons_User",
                        column: x => x.User,
                        principalTable: "Respons",
                        principalColumn: "ResponId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Keluhans",
                columns: table => new
                {
                    KeluhanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TanggalKeluhan = table.Column<DateTime>(nullable: false),
                    KeluhanMahasiswa = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keluhans", x => x.KeluhanId);
                    table.ForeignKey(
                        name: "FK_Keluhans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keluhans_UserId",
                table: "Keluhans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Respons_KeluhanId",
                table: "Respons",
                column: "KeluhanId");

            migrationBuilder.CreateIndex(
                name: "IX_Respons_UserId",
                table: "Respons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileMahasiswaId",
                table: "Users",
                column: "ProfileMahasiswaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User",
                table: "Users",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Respons_Users_UserId",
                table: "Respons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respons_Keluhans_KeluhanId",
                table: "Respons",
                column: "KeluhanId",
                principalTable: "Keluhans",
                principalColumn: "KeluhanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keluhans_Users_UserId",
                table: "Keluhans");

            migrationBuilder.DropForeignKey(
                name: "FK_Respons_Users_UserId",
                table: "Respons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProfileMahasiswas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Respons");

            migrationBuilder.DropTable(
                name: "Keluhans");
        }
    }
}
