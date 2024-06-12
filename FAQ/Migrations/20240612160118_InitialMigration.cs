using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FAQ.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                values: new object[]
                {
                    "General",
                    "History",
                    "Maintenance"
                });

            migrationBuilder.InsertData(
                table: "Topics",
                column: "Name",
                values: new object[]
                {
                    "Chihuahua",
                    "Pomeranian",
                    "Retriever"
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Answer", "CategoryId", "QuestionText", "TopicId" },
                values: new object[,]
                {
                    { 1, "They are very intelligent..", "General", "How intellegent are Retreivers?", "Retriever" },
                    { 2, "Regular grooming and vet check-ups are essential...", "Maintenance", "How do I maintain my Retriever?", "Retriever" },
                    { 3, "Retrievers were originally bred as hunting dogs...", "History", "What is the history of the Retriever breed?", "Retriever" },
                    { 4, "Chihuahuas typically weigh between 2-6 pounds...", "General", "How big do Chihuahuas get?", "Chihuahua" },
                    { 5, "Adult Chihuahuas should be fed 2-3 times a day...", "Maintenance", "How often should I feed my Chihuahua?", "Chihuahua" },
                    { 6, "Chihuahuas are believed to have originated in Mexico...", "History", "What is the origin of the Chihuahua breed?", "Chihuahua" },
                    { 7, "Pomeranians can be good with kids if socialized early...", "General", "Are Pomeranians good with kids?", "Pomeranian" },
                    { 8, "Regular brushing and occasional baths are recommended...", "Maintenance", "How do I groom my Pomeranian?", "Pomeranian" },
                    { 9, "Pomeranians are descended from large sled dogs...", "History", "What is the history of the Pomeranian breed?", "Pomeranian" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CategoryId",
                table: "Questions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
