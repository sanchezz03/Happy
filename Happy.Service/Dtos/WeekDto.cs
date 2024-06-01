namespace Happy.Service.Dtos
{
    public class WeekDto
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Year { get; set; }
        public int WeekNumber { get; set; }
    }
}
