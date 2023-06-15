using System.ComponentModel.DataAnnotations;

namespace ConnectHealthApi.Models
{
    public class AgendaProfessionalModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório")]
        public DateTime Date { get; set; }
        public TimeSpan TimeTable { get; set; }
        public int Duration { get; set; }
        public string Local { get; set; } = null!;

        //Foreign Key
        public int ProfessionalId { get; set; }
        public UserModel? Professional { get; set; }
    }
}