namespace ConnectHealthApi.Models
{
    public class SchedulingModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeTable { get; set; }
        public int Duration { get; set; }
        public string? Local { get; set; }

        //Foreign Keys
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public int ProfessionalId { get; set; }
        public ProfessionalModel? Professional { get; set; }
    }
}
