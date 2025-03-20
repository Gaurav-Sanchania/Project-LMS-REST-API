namespace WebApplication2.Models.Leave
{
    public class GetLeavesModel
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? LeaveType { get; set; }
        //public string? Reason { get; set; }
        public string? Status { get; set; }
    }
}
