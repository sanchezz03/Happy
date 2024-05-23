using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Happy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Data_Into_Week_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DateTime startDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc); 
            DateTime endDate = startDate.AddDays(4); 
            int weekNumber = 1;

            while (startDate.Year == 2024)
            {
                migrationBuilder.InsertData(
                    table: "Weeks",
                    columns: new[] { "StartDate", "EndDate", "Year", "WeekNumber" },
                    values: new object[] { startDate, endDate, startDate.Year, weekNumber });

                startDate = endDate.AddDays(3); 
                endDate = startDate.AddDays(4);
                weekNumber++;

                if (startDate.Year > 2024)
                    break;
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
