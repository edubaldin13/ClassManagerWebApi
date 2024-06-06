namespace class_management_web_api.src.Entities
{
    public class ClassTime
    {
        public Guid ClassTimeId { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime EndingHour { get; set; }
        public string? Duration { get; set; }
        public string? WeekDay { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
