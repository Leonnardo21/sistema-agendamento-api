using System.ComponentModel.DataAnnotations;

namespace ConnectHealthApi.Models
{
    public class AgendaProfessionalModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeTable { get; set; }
        public int Duration { get; set; }
        public string Local { get; set; } = null!;

        //Foreign Key
        public int ProfessionalId { get; set; }
        public ProfessionalModel? Professional { get; set; }
    }
}