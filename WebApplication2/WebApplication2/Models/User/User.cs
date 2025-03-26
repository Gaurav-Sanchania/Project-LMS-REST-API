﻿namespace WebApplication2.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Department { get; set; }
        public int Depart_Id { get; set; }
        public string? UserType { get; set; }
        public int UserType_Id { get; set; }
        //public int LeaveBalance { get; set; }
        public string? Password { get; set; }

    }
}
