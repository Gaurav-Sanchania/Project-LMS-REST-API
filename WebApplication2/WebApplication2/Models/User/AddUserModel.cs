namespace WebApplication2.Models.User
{
    public class AddUserModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int Department { get; set; }
        public int UserType { get; set; }
        public int LeaveBalance { get; set; }
        public string? Password { get; set; }
    }
}
