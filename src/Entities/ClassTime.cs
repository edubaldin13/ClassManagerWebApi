namespace class_management_web_api.src.Entities
{
    public class ClassTime
    {
        public Guid ClassTimeId { get; set; }
                //horário de inicio do periodo curso de graduação
        public DateTime ClassStartingHour { get; set; }
        //horário de encerramento do periodo curso de graduação
        public DateTime ClassClosingHour { get; set; }
        //tempo de duração das aulas, usei int para depois transformar em minutos
        public int ClassDuration { get; set; }
        public string? WeekDay { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //quantidade de aulas do curso de graduação
        public int ClassesQuantity { get; set; }
    }
}
