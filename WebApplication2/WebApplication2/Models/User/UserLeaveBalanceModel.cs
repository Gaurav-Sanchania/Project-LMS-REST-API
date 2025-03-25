namespace WebApplication2.Models.User
{
    public class UserLeaveBalanceModel
    {
        public string? UserName { get; set; }
        public string? LeaveType { get; set; }
        public int LeaveBalance { get; set; }
        public int LeaveTypeId { get; set; }
        public int MaxLeave { get; set; }
    }
}
