namespace TimeKeeping1.Model
{
    public class Leave
    {
        public int LeaveId { get; set; }
        public int UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Types { get; set; }

    }
}
