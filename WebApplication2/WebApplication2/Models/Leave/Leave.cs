namespace WebApplication2.Models.Leave
{
    public class Leave
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Reason { get; set; }
        public string? User_Name { get; set; }
        public string? User_Department { get; set; }
        public int TotalDays { get; set; }
        public string? Admin_Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Status { get; set; }
        public string? Leave_Type { get; set; }
        public string? CC { get; set; }
        public string? BCC { get; set; }
    }
}
