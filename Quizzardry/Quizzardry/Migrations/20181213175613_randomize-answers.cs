using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizzardry.Migrations
{
    public partial class randomizeanswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Answer4", "CorrectAnswer" },
                values: new object[] { "Nobody!", "d" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Answer3", "Answer4", "CorrectAnswer" },
                values: new object[] { "Haddaway", "The Baha Men", "c" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Answer2", "Answer4", "CorrectAnswer" },
                values: new object[] { "The Supremes", "The Shirellas", "b" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Answer1", "Answer4", "CorrectAnswer" },
                values: new object[] { "George Takei", "Leonard Nemoy", "a" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Answer4", "CorrectAnswer" },
                values: new object[] { "The Gateway Arch", "d" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Answer3", "Answer4", "CorrectAnswer" },
                values: new object[] { "Computer Space", "Asteroids", "c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Answer4", "CorrectAnswer" },
                values: new object[] { "Who Cares", "Nobody!" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Answer3", "Answer4", "CorrectAnswer" },
                values: new object[] { "The Baha Men", "Who Cares", "Haddaway" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Answer2", "Answer4", "CorrectAnswer" },
                values: new object[] { "The Shirellas", "Who Cares", "The Supremes" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Answer1", "Answer4", "CorrectAnswer" },
                values: new object[] { "Leonard Nemoy", "Who Cares", "George Takei" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Answer4", "CorrectAnswer" },
                values: new object[] { "Who Cares", "The Gateway Arch" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Answer3", "Answer4", "CorrectAnswer" },
                values: new object[] { "Asteroids", "Who Cares", "Computer Space" });
        }
    }
}
