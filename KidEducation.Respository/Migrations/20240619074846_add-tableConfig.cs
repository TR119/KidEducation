using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidEducation.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addtableConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableShowConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ColumnName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ColumnDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ColumnWidth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColumnDataType = table.Column<int>(type: "int", nullable: true),
                    ColumnSTT = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    IsShow = table.Column<bool>(type: "bit", nullable: true),
                    IsSort = table.Column<bool>(type: "bit", nullable: true),
                    ColumnAlign = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableShowConfigs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableShowConfigs");
        }
    }
}
