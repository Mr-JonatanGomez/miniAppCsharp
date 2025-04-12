using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Tareas",
            //    columns: table => new
            //    {
            //        IdTarea = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tareas", x => x.IdTarea);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //creamos la migracion sin cambios
            //migrationBuilder.DropTable(
            //    name: "Tareas");
        }
    }
}
