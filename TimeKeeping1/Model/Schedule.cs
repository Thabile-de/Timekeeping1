namespace TimeKeeping1.Model
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int UserId { get; set; }
        public DateTime DateRange { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime PayType { get; set; }
        public int PayAmount { get; set; }
    }
}
