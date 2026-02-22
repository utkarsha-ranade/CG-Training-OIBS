using System;

namespace IBS.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
