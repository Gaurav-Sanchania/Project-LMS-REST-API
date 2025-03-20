namespace WebApplication2.Models.Leave
{
    public class HolidaysModel
    {
        public int Id { get; set; }
        public string? Event { get; set; }
        public DateOnly DateOfEvent { get; set; }
    }
}
