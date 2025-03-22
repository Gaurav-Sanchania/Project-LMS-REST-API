namespace WebApplication2.Models.Leave
{
    public class AddLeaveModel
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Reason { get; set; }
        public int UserId { get; set; }
        public string? AdminEmail { get; set; }
        public int LeaveType { get; set; }
        public string? CC { get; set; }
        public string? BCC { get; set; }
    }
}
