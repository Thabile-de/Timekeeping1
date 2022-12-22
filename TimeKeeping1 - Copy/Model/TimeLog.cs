namespace TimeKeeping1.Model
{
    public class TimeLog
    {
        public int TimeLogId { get; set; }
        public int UserId { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime BreakTime { get; set; }
        public DateTime LunchTime { get; set; }
        public DateTime ClockOut { get; set; }
    

}
}
