
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Status" },
                values: new object[] { new Guid("1a7dcb98-6a91-463d-8667-d66bc7d31e56"), null, new DateTime(2019, 5, 22, 18, 14, 59, 201, DateTimeKind.Utc).AddTicks(224), "Do it!", 1 });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Status" },
                values: new object[] { new Guid("792b8742-e4da-41ef-a045-2d487daa0cba"), null, new DateTime(2019, 5, 22, 18, 14, 59, 201, DateTimeKind.Utc).AddTicks(2768), "Finish project", 1 });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Status" },
                values: new object[] { new Guid("b6b2b8ee-6d12-4929-bbb5-8b83ff38fcfe"), null, new DateTime(2019, 5, 22, 18, 14, 59, 201, DateTimeKind.Utc).AddTicks(2807), "Go to work!", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");
        }
    }
}
